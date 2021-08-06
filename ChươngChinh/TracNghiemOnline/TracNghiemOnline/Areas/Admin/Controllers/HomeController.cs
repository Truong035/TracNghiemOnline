using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TracNghiemOnline.Model;
using TracNghiemOnline.Modell;
using TracNghiemOnline.Modell.Dao;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;
using System.Net;
using System.Web.Script.Serialization;
using EXCELL = Microsoft.Office.Interop.Excel;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields.OMath;
using Spire.Doc.Fields;
using System.IO;
using System.Data;

namespace TracNghiemOnline.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {

       
        // GET: Admin/Home
        [HttpGet]
        public ActionResult Index()
        {
            reseach();
            return View();
          
        }
        public ActionResult Save()
        {
            string maphong ="";
            List<DS_SVThi> dssv = ((List<DS_SVThi>)Session["Sinhvien"]);
            foreach (var item in dssv)
            {


                TracNghiemOnlineDB db = new TracNghiemOnlineDB();
                var LopHP = db.LopHocPhans.Find(item.MaPhong);

                if (LopHP != null)
                {
                    maphong = LopHP.MaLop;
                    if(!db.DS_LopHP.ToList().Exists(x=>x.MA_SV.Equals(item.Ma_SV) && x.TrangThai != false && x.Ma_LOP.Equals(LopHP.MaLop)))
                    {
                        DS_LopHP DS = new DS_LopHP();
                        DS.MA_SV = item.Ma_SV;
                        DS.Ma_LOP = LopHP.MaLop;
                        DS.TrangThai = true;
                        db.DS_LopHP.Add(DS);
                       
                        db.SaveChanges();
                    }

                }
                else
                {
                    try
                    {
                        var phong = db.Phong_Thi.Find(item.MaPhong);
                        if(db.DS_LopHP.ToList().Exists(x => x.MA_SV.Equals(item.Ma_SV) && !x.TrangThai == false && x.Ma_LOP.Equals(phong.MaLopHP))){

                            if (!db.DS_SVThi.ToList().Exists(x => x.Ma_SV.Equals(item.Ma_SV) && x.MaPhong.Equals(item.MaPhong)))
                            {
                                db.DS_SVThi.Add(item);
                                db.SaveChanges();
                            }
                        }

                    }
                    catch
                    {

                    }

                }

                Session["Sinhvien"]=null;

            }
            Session["Maphong"] = "";
            if (maphong.Length > 0)
            {
                return Redirect("/Admin/QuanLyThi/DSSinhVen/" + maphong.Trim());
            }
            else
            {
                var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
                return Redirect("/Admin/Home/DSSVThi/" +dssv.ToList()[0].MaPhong);
                

            }

           
        }
        public ActionResult Delete(long made)
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            var de = db.Shares.SingleOrDefault(x => x.MA == made && x.MaGV.Equals(session.TaiKhoan1) && x.Loai == 0);
            db.Shares.Remove(de);
            db.SaveChanges();
            return RedirectToAction("DeBM");
        }
        public ActionResult DeBM()
        {
            List<Bo_De> bodes = new List<Bo_De>();
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            foreach (var item in db.Shares.Where(x=>x.MaGV.Equals(session.TaiKhoan1)&&x.Loai==0))
            {
               
                    var bode = db.Bo_De.Where(x => x.Ma_BoDe == item.MA).ToList();
                if (bode.Count > 0)
                {
                    bodes.Add(bode[0]);
                }
                  
             
                
            }
            return View(bodes);
        }

        public JsonResult UploadExcel(string arr)
        {
            List<DS_SVThi> sinhViens = new List<DS_SVThi>();
            string [] mang = arr.Split('/');

            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            for (int i = 0; i < mang.Length; i++)
            {
                try
                {

                    string masv = mang[i];
                    var sv = db.SinhViens.Where(x => x.MaSV.Trim().Equals(masv)).ToList();
                  
                    if (sv.ToList().Count > 0)
                    {
                        DS_SVThi dS_SVThi = new DS_SVThi();
                        dS_SVThi.Ma_SV = sv.ToList()[0].MaSV;

                        sinhViens.Add(dS_SVThi);

                    }
                }
                catch
                {

                }

            }
              

           
         
            Session["Sinhvien"] = sinhViens;
            return Json(new
            {
                status = true,
                
                sl = sinhViens.Count
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadData(string id)
        {
           
            List<DS_SVThi> dssv = ((List<DS_SVThi>)Session["Sinhvien"]);
            foreach (var item in dssv)
            {
                item.MaPhong = id;
            }
            Session["Sinhvien"] = dssv;
            return View();

        }

        public ActionResult ChonDe1(long id)
        {
            Session["mads"] = id;
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var ds = new TracNghiemOnlineDB().DSGV_ThucHien.Find(id);

            var dethi = new TracNghiemOnlineDB().Bo_De.Where(x => x.Ma_NguoiTao == session.TaiKhoan1 && x.Xoa == true && x.NguoiDuyet == null).ToList();
            return View(dethi);
        }
        public void save_file_from_url(string file_name, string url)
        {
            byte[] content;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();


            Stream stream = response.GetResponseStream();

            using (BinaryReader br = new BinaryReader(stream))
            {
                content = br.ReadBytes(500000);
                br.Close();
            }
            response.Close();

            FileStream fs = new FileStream(file_name, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(content);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
        }

        public string copyanh(string path)
        {

            DateTime aDateTime = DateTime.Now;
            int sas = Convert.ToInt32(aDateTime.Year * 12 * 30 * 24 * 60 * 60 + aDateTime.Month * 30 * 24 * 60 * 60 + aDateTime.Day * 24 * 60 * 60 + aDateTime.Hour * 60 * 60 + aDateTime.Minute * 60 + aDateTime.Second);
            string Filename = "Anh" + sas+".jpg";
            string saveLocation = "~/Content/Img/" + Filename;
            string file_name = Server.MapPath(saveLocation);
            if (path.Contains("http"))
            {

                save_file_from_url(file_name, path);
                

            }
            else
            {
                // path = Server.MapPath(path);
                string path1 = System.IO.Path.GetFullPath(path);
                Image png = Image.FromFile(path1);
                png.Save(file_name, System.Drawing.Imaging.ImageFormat.Jpeg);
                png.Dispose();

            }

            return "/Content/Img/" + Filename; ;
        }

        public List<String> tachcongthuc(string s)
        {
            List<String> list = new List<String>();
            if (!s.Contains("<mml:math"))
            {
                list.Add(s);
                return list;
            }
            while (true)
            {
                if (!s.Contains("<mml:math"))
                {
                    list.Add(s);
                    break;
                }
                else
                {
                    if (s.IndexOf("<mml:math") != 0)
                    {
                        var s1 = s.Substring(0, s.IndexOf("<mml:math"));
                        if (s1.Length > 0)
                        {
                            list.Add(s1);


                        }

                        var a = s.Remove(0, s1.Length);
                        s = a;


                    }
                    else
                    {
                        var s1 = s.Substring(0, s.IndexOf("/mml:math>") + 10);
                        list.Add(s1);
                        var a = s.Remove(0, s1.Length);
                        s = a;

                    }
                }
            }
            return list;
        }

        public string xuatpdf(long id, string tenmon)
        {
            Document doc = new Document();
            Section section = doc.AddSection();
            section.PageSetup.Borders.BorderType = BorderStyle.DoubleWave;

            section.PageSetup.Borders.Color = Color.Black;

            section.PageSetup.Borders.Left.Space = 50;

            section.PageSetup.Borders.Right.Space = 50;
            section.PageSetup.Borders.Top.Space = 20;
            section.PageSetup.Borders.Bottom.Space = 20;

            //title
            Paragraph paratitle = section.AddParagraph();
            paratitle.Format.HorizontalAlignment = HorizontalAlignment.Center;
            paratitle.AppendText("TRƯỜNG ĐẠI HỌC GIAO THÔNG VẬN TẢI PHÂN HIỆU TẠI TP HỒ CHÍ MINH");
            ParagraphStyle styletitle = new ParagraphStyle(doc);
            styletitle.Name = "titleStyle";
            styletitle.CharacterFormat.Bold = true;
            styletitle.CharacterFormat.TextColor = Color.Black;
            styletitle.CharacterFormat.FontName = "Arial";
            styletitle.CharacterFormat.FontSize = 16f;
            doc.Styles.Add(styletitle);
            paratitle.ApplyStyle("titleStyle");


            // tne  mon de thi
            Paragraph paratenmon = section.AddParagraph();

            paratenmon.Format.HorizontalAlignment = HorizontalAlignment.Left;
            paratenmon.AppendText("\n\nĐề thi môn:" + tenmon);

            ParagraphStyle styleleft = new ParagraphStyle(doc);
            styleleft.Name = "left";
            styleleft.CharacterFormat.Bold = true;
            styleleft.CharacterFormat.TextColor = Color.Black;
            styleleft.CharacterFormat.FontName = "Arial";
            styleleft.CharacterFormat.FontSize = 12f;
            doc.Styles.Add(styleleft);
            paratenmon.ApplyStyle("left");


            // ma de thi
            Paragraph paramade = section.AddParagraph();

            paramade.Format.HorizontalAlignment = HorizontalAlignment.Right;
            paramade.AppendText("\tMã đề:" + id + "\n\n\n");

            ParagraphStyle styleright = new ParagraphStyle(doc);
            styleright.Name = "right";
            styleright.CharacterFormat.Bold = true;
            styleright.CharacterFormat.TextColor = Color.Black;
            styleright.CharacterFormat.FontName = "Arial";
            styleright.CharacterFormat.FontSize = 12f;

            doc.Styles.Add(styleright);
            paramade.ApplyStyle("right");

            int slcau = 0;
            var khoch = new Bode().listkhocauhoi(id);
          




            foreach (var item in khoch)
            {
                Paragraph para1 = section.AddParagraph();
                slcau++;
                int slda = 0;
                var s = tachcongthuc(item.NoiDung);
                para1.AppendText("\n");
                para1.AppendText("Câu " + slcau + ":");
                foreach (var item2 in s)
                {
                    if (item2.Contains("<mml:math"))
                    {

                        try
                        {
                            OfficeMath officeMath;
                            officeMath = new OfficeMath(doc);
                            officeMath.FromMathMLCode(item2);
                            para1.Items.Add(officeMath);
                        }
                        catch
                        {

                        }


                    }
                    else
                    {
                        para1.AppendHTML(item2);

                    }

                }
                para1.AppendText("\n\n");

                if (item.HinhAnh.Length > 0)
                {
                    try
                    {


                        Image image = Image.FromFile(Server.MapPath(item.HinhAnh));


                        DocPicture pic = para1.AppendPicture(image);

                        pic.Height = pic.Height;
                        if (pic.Height > pic.Width)
                        {
                            pic.Height = 180;
                            pic.Width = 120;
                        }
                        else if (pic.Height < pic.Width)
                        {
                            pic.Height = 120;
                            pic.Width = 150;
                        }
                        else if (pic.Height == pic.Width)
                        {
                            pic.Height = 150;
                            pic.Width = 150;
                        }



                        para1.AppendText("\n");
                    }
                    catch { }

                }


                foreach (var da in item.Dap_AN)
                {
                    var s1 = tachcongthuc(da.NoiDung);
                    para1.AppendText("\n");
                    if (da.TrangThai == true)
                    {
                        para1.AppendText("*");

                    }
                    else
                    {
                        para1.AppendText("");

                    }
                    slda++;
                    foreach (var item2 in s1)
                    {
                        if (item2.Contains("<mml:math"))
                        {

                            try
                            {
                                OfficeMath officeMath;
                                officeMath = new OfficeMath(doc);
                                officeMath.FromMathMLCode(item2);
                                para1.Items.Add(officeMath);
                            }
                            catch
                            {

                            }


                        }
                        else
                        {
                            para1.AppendHTML(item2);

                        }

                    }

                    if (da.HinhAnh.Length > 0)
                    {
                        try
                        {
                            para1.AppendText("\n\n");
                            Image image = Image.FromFile(Server.MapPath(da.HinhAnh));


                            DocPicture pic = para1.AppendPicture(image);

                            if (pic.Height > pic.Width)
                            {
                                pic.Height = 120;
                                pic.Width = 100;
                            }
                            else if (pic.Height < pic.Width)
                            {
                                pic.Height = 100;
                                pic.Width = 120;
                            }
                            else if (pic.Height == pic.Width)
                            {
                                pic.Height = 120;
                                pic.Width = 120;
                            }

                            para1.AppendText("\n");
                        }
                        catch { }

                    }


                }

            }
            Paragraph paragraph = section.Paragraphs[section.Count - 1];
            Footnote footnote = paragraph.AppendFootnote(FootnoteType.Footnote);
            TextRange text = footnote.TextBody.AddParagraph().AppendText("HẾT");
            text.CharacterFormat.FontName = "Arial Black";
            text.CharacterFormat.FontSize = 12;
            text.CharacterFormat.TextColor = Color.SlateGray;

            doc.SaveToFile(Server.MapPath("~/Content/" + "De_" + id + ".docx"));
            doc.SaveToFile(Server.MapPath("~/Content/" + "De_" + id + ".pdf"));

            return "/Content/" + "De_" + id + ".pdf";



        }



        public ActionResult Menull()
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
           
            if (session.ChưcVu.Equals("Admin"))
            {
              
                
                return PartialView();
            }
            else if (session.ChưcVu.Equals("BoMon"))
            {
                return View("MenuBM");
            }

            return View("menulCanBo");         
        }
        public ActionResult BoMon()
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];

            var ds = new TracNghiemOnlineDB();
            DateTime dateTime = (DateTime)Session["Gio"];
            foreach (var item in new TracNghiemOnlineDB().LichNops.Where(x=>x.ThoiGian<dateTime&&x.ThoiGian!=null))
            {
                var lich = ds.LichNops.Find(item.id);
              
                ds.SaveChanges();
                foreach (var item1 in new TracNghiemOnlineDB().DSGV_ThucHien.Where(X=>X.MaDE==null && X.MaLich==item.id))
                {
                    var gv = ds.DSGV_ThucHien.Find(item1.id);
                    gv.trangthai = "Đã hết hạn nộp";
                    ds.SaveChanges();
                }

            }
            return View();
        }
     
       public ActionResult DeleteSV(int id)
        {
            List<DS_SVThi> dssv = ((List<DS_SVThi>)Session["Sinhvien"]);
            var sinhvien = dssv[id];
            dssv.Remove(sinhvien);
            Session["Sinhvien"]= dssv;
            return RedirectToAction("LoadData/" + sinhvien.MaPhong);
        }
        public ActionResult PhongThi()
        {
            var ds = new TracNghiemOnlineDB();
            DateTime dateTime = (DateTime)Session["Gio"];
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var phong = db.Phong_Thi.Where(x => !x.TrangThai.Equals("Đã Đóng") && x.Xoa == true && (x.MaCanBo1==session.TaiKhoan1|| x.MaCanBo2==session.TaiKhoan1) && x.MaBoDe!=null).ToList();
            foreach (var item in phong)
            {
             if (item.ThoiGianDong <= dateTime)
                {
                    var p = db.Phong_Thi.Find(item.MaPhong);
                    p.TrangThai = "Đã Đóng";
                    db.SaveChanges();

                }

            }
            phong = db.Phong_Thi.Where(x => !x.TrangThai.Equals("Đã Đóng") && x.Xoa == true && (x.MaCanBo1 == session.TaiKhoan1 || x.MaCanBo2 == session.TaiKhoan1) && x.MaBoDe != null).ToList();
            return View(phong);
        }
        public JsonResult Update(long maDe,bool trangthai)
        {
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            var Bode = db.Bo_De.Find(maDe);
            //  Bode.TrangThai = trangthai;
            Bode.TrangThai = false;
            db.SaveChanges();
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
           
            List<Bo_De> bo_Des = new TracNghiemOnlineDB().Bo_De.Where(x => x.Ma_NguoiTao.Equals(session.TaiKhoan1) && x.Xoa == true && x.TrangThai == false || (x.TrangThai == true && x.NguoiDuyet.Equals(session.TaiKhoan1))).ToList();


            if (session.ChưcVu.Equals("Cán Bộ"))
            {
                bo_Des = new TracNghiemOnlineDB().Bo_De.Where(x => x.Ma_NguoiTao == session.TaiKhoan1 && x.Xoa == true && x.NguoiDuyet == null).ToList();
            }

            var bode1 = (from n in bo_Des
                         select new
                         {
                             Ten = n.NoiDung,
                             MaDe = n.Ma_BoDe,
                             SoCau = n.SoCau,
                             ThoiGian = n.ThoiGianThi,
                             TenMon = n.MonHoc.TenMon,
                             Giaovien = n.GiaoVien.TenGV,
                             TrangThai = n.TrangThai,
                         }).ToList();
            return Json(new
            {
                Bode = bode1

            }, JsonRequestBehavior.AllowGet); 
        }

        public JsonResult UpdateDethi(long maDe ,string nd,string tg,bool xoa )
        {
  
          

            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            var Bode = db.Bo_De.Find(maDe); 
            Bode.ThoiGianThi = tg;
            Bode.NoiDung = nd;
            Bode.Xoa = xoa;
            db.SaveChanges();
             var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];

            List<Bo_De> bo_Des = new TracNghiemOnlineDB().Bo_De.Where(x => x.Ma_NguoiTao.Equals(session.TaiKhoan1) && x.Xoa == true && x.TrangThai == false || (x.Xoa == true && x.NguoiDuyet.Equals(session.TaiKhoan1))).ToList();


            if (session.ChưcVu.Equals("Cán Bộ"))
           {
                bo_Des = new TracNghiemOnlineDB().Bo_De.Where(x => x.Ma_NguoiTao == session.TaiKhoan1 && x.Xoa==true && x.NguoiDuyet==null).ToList();
          }
            
            var bode1 = (from n in bo_Des
                         select new
                         {
                             Ten = n.NoiDung,
                             MaDe = n.Ma_BoDe,
                             SoCau = n.CauHois.Count,
                             ThoiGian = n.ThoiGianThi,
                             TenMon = n.MonHoc.TenMon,
                             Giaovien=n.GiaoVien.TenGV,
                             TrangThai=n.TrangThai,
                         }).ToList();
            return Json(new
            {
                Bode = bode1

            }, JsonRequestBehavior.AllowGet); ;

        }

        public ActionResult DSSVThi(string id)
        {

            Session["Maphong"] = id;
            Phong_Thi phong_Thi = new TracNghiemOnlineDB().Phong_Thi.Where(x=>x.MaPhong.Equals(id)).ToList().First();
            return View(phong_Thi);

        }



        public void reseach()
        {
            Model.BoDeThi boDeThi = new BoDeThi();
            bo_De1.Ma_Mon = 0;
            bo_De1.ThoiGianThi = "";
            boDeThi.LoaiDe1 = "";
            boDeThi.BoDeThi1 = bo_De1;
            Session[ComMon.ComMonStants.ChapterStudy] = boDeThi;
        }
        public ActionResult DSDETHI(string id)
        {
            reseach();
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
           List<Bo_De> bo_Des = new BoDeDao().ListALLChapterStudy();

                bo_Des = new TracNghiemOnlineDB().Bo_De.Where(x => x.Ma_NguoiTao == session.TaiKhoan1 && x.Xoa == true && x.NguoiDuyet == null).ToList();

            Session["mads"]=null;
            return View(bo_Des);
        }
      
        public ActionResult TaoDeThi()
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var gv = new TracNghiemOnlineDB().GiaoViens.Find(session.TaiKhoan1);
            var dao = new TracNghiemOnline.Modell.TracNghiemOnlineDB().MonHocs.Where(x => x.MaBoMon.Equals(gv.MaBoMon)).ToList();
            ViewBag.MonHoc = dao;
            ViewBag.A ="";
            ViewBag.B = "";
            ViewBag.C = "";
            reseach();
            return View();
         
        }
   
        public ActionResult ChonMon(string id)
        {
            var dethi = (Model.BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];

            try
            {
                dethi.BoDeThi1.Ma_Mon = long.Parse(id);
            }
            catch { dethi.BoDeThi1.Ma_Mon = 0; }
          
            Session[ComMon.ComMonStants.ChapterStudy] = dethi;
            return Content("");
        }
        public ActionResult ChonTG(string tg)
        {
           var dethi = (Model.BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];
            dethi.BoDeThi1.ThoiGianThi = tg;
            Session[ComMon.ComMonStants.ChapterStudy] = dethi;
            return Content("");
        }

        public ActionResult ChonDe(string id)
        {
            var dethi = (Model.BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];
            dethi.LoaiDe1=id;
            Session[ComMon.ComMonStants.ChapterStudy] = dethi;
            return Content("");
        }

       public void ChonCauHoi(String CauHoi)
        {


            var khocauhoi = new JavaScriptSerializer().Deserialize<List<Kho_CauHoi>>(CauHoi);
            var sessetion = (BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];
            var bo_De = sessetion.BoDeThi1;
            foreach (var item in khocauhoi)
            {
                Modell.CauHoi cau = new Modell.CauHoi();
                cau.Ma_CauHoi = item.Ma_CauHoi;
                cau.Ma_BoDe = bo_De.Ma_BoDe;
                cau.Kho_CauHoi = new CauHoiDao().Question(item.Ma_CauHoi);
                bo_De.CauHois.Add(cau);

            }
            sessetion.BoDeThi1 = bo_De;
            Session[ComMon.ComMonStants.ChapterStudy] = sessetion;


        }

        private static Bo_De bo_De1=new Bo_De();
        [HttpPost]
        public ActionResult MonHoc(Bo_De bo_De)
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var dethi = (Model.BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];
            if (ModelState.IsValid && dethi.BoDeThi1.ThoiGianThi.Length>0 && dethi.LoaiDe1.Length>0 && dethi.BoDeThi1.Ma_Mon>0)
            {
                bo_De.ThoiGianThi = dethi.BoDeThi1.ThoiGianThi;
                bo_De.Ma_Mon = dethi.BoDeThi1.Ma_Mon;

                bo_De.MonHoc = new MonHocDao().Subject(long.Parse(bo_De.Ma_Mon.ToString()));
              
                dethi.BoDeThi1 = bo_De;

                Session[ComMon.ComMonStants.ChapterStudy] = dethi;
                if (session.ChưcVu.Equals("BoMon") || (bo_De.LoaiDe == true))
                {
                    if (dethi.LoaiDe1.Equals("Tự Chọn"))
                    {
                        List<Kho_CauHoi> kho_CauHois = new List<Kho_CauHoi>();
                        foreach (var item in new MonHocDao().ListChapterStudy(long.Parse(dethi.BoDeThi1.Ma_Mon.ToString())))
                        {
                            kho_CauHois.AddRange(new CauHoiDao().ListQuestion(long.Parse(item.Ma_Chuong.ToString())));
                        }
                        ViewBag.Question = kho_CauHois;
                        return View("ChonCauhoi");

                    }
                    else
                    {

                        var chuong = new TracNghiemOnlineDB().Chuong_Hoc.Where(x => x.Ma_Mon == bo_De.Ma_Mon).ToList();
                        ViewBag.Chuong = chuong;

                        return View(bo_De);

                    }

                }
                else
                {
                    if (dethi.LoaiDe1.Equals("Tự Chọn"))
                    {
                        List<Kho_CauHoi> kho_CauHois = new List<Kho_CauHoi>();
                        foreach (var item in new MonHocDao().ListChapterStudy(long.Parse(dethi.BoDeThi1.Ma_Mon.ToString())))
                        {
                            kho_CauHois.AddRange(new CauHoiDao().ListQuestion(long.Parse(item.Ma_Chuong.ToString())));
                        }
                        ViewBag.Question = kho_CauHois;
                        return View("TuChon");

                    }
                    else
                    {
                        var chuong = new TracNghiemOnlineDB().Chuong_Hoc.Where(x => x.Ma_Mon == bo_De.Ma_Mon).ToList();
                        ViewBag.Chuong = chuong;
                        ViewBag.bode = bo_De;
                        return View("TaoCau");

                    }

                }

            }
            else
            {
                string mess = "";
                string mess1 = "";
                string mess2 = "";


                if (dethi.BoDeThi1.ThoiGianThi.Length <= 0)
                {
                    mess = "Bạn Vui Lòng Chọn Thời Gian Thi";
                }
                if (dethi.BoDeThi1.Ma_Mon<= 0)
                {
                    mess1 = "Bạn Vui Lòng Chọn Môn Học ";
                }
                if (dethi.LoaiDe1.Length<= 0)
                {
                    mess2 = "Bạn Vui Lòng Chọn Cách Tạo Đề";
                }
                ViewBag.A = mess;
                ViewBag.B = mess1;
            var dao = new TracNghiemOnline.Modell.TracNghiemOnlineDB().MonHocs.Select(x => x).ToList();
            ViewBag.MonHoc = dao;
                ViewBag.C = mess2;

            }
            reseach();

            return View("TaoDeThi");
      
        }

        public void GuiboMon(long id,string tgbd)
        {
            string[] ngay = tgbd.Split('/');
            long id1 = (long)Session["mads"];
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            var bode = db.DSGV_ThucHien.Find(id1);
         DateTime date=   new DateTime(int.Parse(ngay[0]), int.Parse(ngay[1]), int.Parse(ngay[2]), int.Parse(ngay[3]), int.Parse(ngay[4]), int.Parse(ngay[5]));
            bode.MaDE = id;
            var lich = db.LichNops.Find(bode.MaLich);
            try
            {
                if (date > lich.ThoiGian)
                {
                    bode.trangthai = "Nộp Muộn";
                }
                else
                {
                    bode.trangthai = "Đang xử lý";
                }
            }
            catch {
                bode.trangthai = "Đang xử lý";
            }

            bode.NgayNop = date;
            Session["mads"]=null;
            db.SaveChanges();
        }
        public void HuyGui(long id)
        {
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            var bode = db.Bo_De.Find(id);
            if (!bode.PheDuyet.Contains("Đã"))
            {
                bode.TrangThai = false;
                bode.PheDuyet = null;
                bode.NguoiDuyet = null;
                db.SaveChanges();
            }
        }

        public ActionResult LoadDeThi(string id)
        {
            try { 
                if (id.Length > 0)
                {
                    var BODETHI = new BoDeThi();
                    BODETHI.BoDeThi1 = new BoDeDao().ChapterStudy(long.Parse(id));
                    Session[ComMon.ComMonStants.ChapterStudy] = BODETHI;
                    ViewBag.Mess = id;
                   ViewBag.linkpdf = xuatpdf(long.Parse(id), BODETHI.BoDeThi1.MonHoc.TenMon);
                    //var de = new TracNghiemOnlineDB().Bo_De.Where(x => x.Ma_BoDe == long.Parse(id)).FirstOrDefault();
                    
                }
                else
                {
                    ViewBag.Mess = "";
                }
            }
            catch
            {
                ViewBag.Mess = "";
            }
           var dethi = (Model.BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];
            ViewBag.TenDe = dethi.BoDeThi1.NoiDung;
            ViewBag.MonThi = dethi.BoDeThi1.MonHoc.TenMon;
            ViewBag.ThoiGianThi = dethi.BoDeThi1.ThoiGianThi;
            return View(dethi.BoDeThi1);
        }
       
        public void ChiaSeDe(bool s,long dethi)
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            var GV = db.GiaoViens.Find(session.TaiKhoan1);
            var Bode = db.Bo_De.Find(dethi);
            Bode.Share = s;
            db.SaveChanges();

            if (s == true)
            {
                DateTime dateTime = (DateTime)Session["Gio"];
                foreach (var item in db.GiaoViens.Where(x => x.MaBoMon.Equals(GV.MaBoMon) && 
                !x.MaGV.Equals(GV.MaGV)))
                {
                    TracNghiemOnlineDB db1 = new TracNghiemOnlineDB();
                    Share share = new Share();
                    share.MA = dethi;
                    share.MaGV = item.MaGV;
                    share.Loai = 0;
                    share.NgayDang = dateTime;
                    db1.Shares.Add(share);
                    db1.SaveChanges();

                }
            }
            else
            {
                foreach (var item in db.Shares.Where(x=>x.MA==dethi&&x.Loai==0))
                {
                    TracNghiemOnlineDB db1 = new TracNghiemOnlineDB();
                    var s1 = db1.Shares.Find(item.id);
                    db1.Shares.Remove(s1);
                    db1.SaveChanges();

                }
            }
          
        }



        public ActionResult AddChapterStudy()
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var dethi = (Model.BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];
            dethi.BoDeThi1.Ma_NguoiTao = session.TaiKhoan1;
            if (session.ChưcVu.Equals("BoMon"))
            {
                new Bode().themde(dethi.BoDeThi1);
                return RedirectToAction("DSDethi", "Bomon");

            }
            new BoDeDao().CreateChapterStudy(dethi.BoDeThi1);
            return RedirectToAction("DSDETHI","Home");
        }

      
        public ActionResult NgânHangCauHoi(string id)
        {
            Session["Kho"] = id;
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var canbo = new TracNghiemOnlineDB().GiaoViens.Find(session.TaiKhoan1);

            reseach();
            return View(new TracNghiemOnlineDB().MonHocs.Where(x=>x.MaBoMon.Equals(canbo.MaBoMon)).ToList());
        }

        public ActionResult ChuongHoc(string id)
        {
            bool check = true;
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            Session[ComMon.ComMonStants.Cauhoi]= null;
            if (session.ChưcVu.Equals("BoMon"))
            {
                check = false;
            }
            ViewBag.id = id;
            ViewBag.check = check;
            reseach();
            List<Chuong_Hoc> chuong_Hocs = new MonHocDao().ListChapterStudy(long.Parse(id));
            return View(chuong_Hocs);
        }

       

        public JsonResult TaoDe( string SoLuong)
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var soluong = new JavaScriptSerializer().Deserialize<List<SoLuongChuong>>(SoLuong);
            var bode = (BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];
          var  bo_De1 = bode.BoDeThi1;
            if (session.ChưcVu.Equals("BoMon") || (bo_De1.LoaiDe == true))
            {
                var gv = new TracNghiemOnlineDB().GiaoViens.Find(session.TaiKhoan1);
                new CauHoiDao().CreateTopic(bo_De1, soluong, gv.MaBoMon);
            }
            else
            {
              
                new CauHoiDao().CreateTopic(bo_De1, soluong, session.TaiKhoan1);
            }
               
            return Json(new
            {
                status = true
            }) ;
        } 
        public ActionResult DoiMatKhau()
        {
            return View();
        }
        public JsonResult DoiMK(string matkhaucu, string matkhaumoi)
        {
            try
            {
                TracNghiemOnlineDB db = new TracNghiemOnlineDB();
                var taikhoan = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
                var tk = db.TaiKhoans.Where(x => x.TenDangNhap.Equals(taikhoan.TenDangNhap) && x.MatKhau.Equals(matkhaucu)).FirstOrDefault();
                int trangthai = 0;
                if (tk != null)
                {
                    tk.MatKhau = matkhaumoi;
                    db.SaveChanges();
                }
                else
                {
                    trangthai = 1;
                }
                return Json(new { code = 200, trangthai = trangthai }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}