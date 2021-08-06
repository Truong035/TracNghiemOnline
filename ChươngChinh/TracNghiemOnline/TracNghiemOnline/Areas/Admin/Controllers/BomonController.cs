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
using TracNghiemOnline.Controllers;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields.OMath;
using Spire.Doc.Fields;

namespace TracNghiemOnline.Areas.Admin.Controllers
{
    public class BomonController : BaseController
    {
        // GET: Admin/Bomon
        
        
        //moi themF
        public ActionResult DSDethitheobm()
        {

            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            ViewBag.Mabomon = session.TaiKhoan1;
           // List<Bo_De> bo_Des = new Bode().ListALLChapterBM(session.TaiKhoan1);
            List<Bo_De> bo_Des = new TracNghiemOnlineDB().Bo_De.Where(x => x.Xoa == true && x.NguoiDuyet.Equals(session.TaiKhoan1) && x.PheDuyet.Contains("Đang")).ToList();

            return View(bo_Des);

        }
        public ActionResult DSDEDUYET()
        {


            return View();

        }

        public ActionResult deletebomon(long id)
        {
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            var list = db.DSGV_ThucHien.Where(x => x.MaLich == id).ToList();
            foreach (var item in list)
            {
                db.DSGV_ThucHien.Remove(item);
                db.SaveChanges();
            }
            var lich = db.LichNops.Find(id);
            db.LichNops.Remove(lich);
            db.SaveChanges();
            return RedirectToAction("BoMON");

        }
        public ActionResult Updatebomon(long id)
        {
            var lich = new TracNghiemOnlineDB().LichNops.Find(id);
            string chuoi = "";
            foreach (var item in new TracNghiemOnlineDB().DSGV_ThucHien.Where(x => x.MaLich==id))
            {
                chuoi += item.MaGV + "/";
            }
            string[] arr = chuoi.Split('/');
            Session["dsgv"] = arr;
            return View(lich);
           
        }
        [HttpPost]
        public ActionResult Updatebomon(LichNop lichNop)
        {
            if (ModelState.IsValid) { 
                try
            {
                string[] ds = (string[])Session["dsgv"];
                var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
                if (ds.Length > 1)
                {
         
                    TracNghiemOnlineDB db = new TracNghiemOnlineDB();
                    var lich = db.LichNops.Find(lichNop.id);
                    lich.NoiDung = lichNop.NoiDung;
                    lich.ThoiGian = lichNop.ThoiGian;
                       lich.MaMon = lichNop.MaMon;
                    db.SaveChanges();
                    var list = db.DSGV_ThucHien.Where(x => x.MaLich == lichNop.id).ToList();
                    foreach (var item in list)
                    {
                        db.DSGV_ThucHien.Remove(item);
                        db.SaveChanges();
                    }

                    for (int i = 0; i < ds.Length - 1; i++)
                    {
                        DSGV_ThucHien GV = new DSGV_ThucHien();
                        GV.MaGV = ds[i];
                        GV.MaLich = lichNop.id;
                        db.DSGV_ThucHien.Add(GV);
                        db.SaveChanges();
                    }
                    return RedirectToAction("BoMON");

                }

            }
            catch
            {
                ModelState.AddModelError("", "Vui lòng chọn giáo viên ");

            }
        }
            return View(lichNop);


    }

        public void DSGV(string chuoi)
        {
            string[] dsgv= chuoi.Split('/');
            Session["dsgv"] = dsgv;
        }
        public ActionResult TaoLich()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult TaoLich(LichNop lichNop)
        {
            if (ModelState.IsValid)
            {
                try
                {
                string[]  ds=(string[])  Session["dsgv"];
                    var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
                    if (ds.Length > 1)
                    {
                        lichNop.TrangThai = true;
                        lichNop.xoa = true;
                        lichNop.MaBoMON = session.TaiKhoan1;
                        TracNghiemOnlineDB db = new TracNghiemOnlineDB();
                        db.LichNops.Add(lichNop);
                        db.SaveChanges();
                       
                        for (int i = 0; i < ds.Length-1; i++)
                        {
                            DSGV_ThucHien GV = new DSGV_ThucHien();
                            GV.MaGV = ds[i];
                            GV.MaLich= new TracNghiemOnlineDB().LichNops.ToList().Last().id;
                            db.DSGV_ThucHien.Add(GV);
                            db.SaveChanges();
                        }
                        return RedirectToAction("BoMON");

                    }

                }
                catch {
                    ModelState.AddModelError("", "Vui lòng chọn giáo viên ");

                }
            }

            return View(lichNop);
        }

        public ActionResult BoMON()
        {
            Session["dsgv"] = "";
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
           
 
            
            var lich=new TracNghiemOnlineDB().LichNops.Where(x=>x.MaBoMON.Equals(session.TaiKhoan1));
            return View(lich);
        }
        public ActionResult DSDethi()
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            ViewBag.Mabomon = session.TaiKhoan1;

            var dsdethi = new TracNghiemOnlineDB().Bo_De.Where(x => x.Ma_NguoiTao.Equals(session.TaiKhoan1) && x.Xoa == true && x.TrangThai == false || (x.Xoa == true && x.NguoiDuyet.Equals(session.TaiKhoan1))).ToList();


            return View(dsdethi);
        }

        public ActionResult xemde(long id)
        {
            var khoch = new Bode().listkhocauhoi(id);
            ViewBag.linkpdf = xuatpdf(id, Request["tenmon"]);
            var de = new TracNghiemOnlineDB().Bo_De.Where(x => x.Ma_BoDe == id).FirstOrDefault();
            ViewBag.TenDe = de.NoiDung;
            ViewBag.MonThi = de.MonHoc.TenMon;
            ViewBag.ThoiGianThi = de.ThoiGianThi;
            return View(khoch);

        }

        public ActionResult KetquathiTungGVBM()
        {
            var tk = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var giaovien = new Bode().danhsachgiaovienbm(tk.TaiKhoan1);
    
            return View(giaovien);


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

        public  string xuatpdf(long id,string tenmon)
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
            string[] cau = { "", "", "", "" };





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

            return "/Content/" + "De_"+id + ".pdf";



        }


        public ActionResult DanhgiaketquatheoBoMon(string id)
        {
            ViewBag.sss = id;
            DateTime dateTime = (DateTime)Session["Gio"];
            var phonghoc = DanhGiaKetQuatheoBoMon(id,dateTime);
       

            return View(phonghoc);

        }
        internal object DanhGiaKetQuatheoBoMon(string id, DateTime dateTime)
        {
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            var tkbomon = db.TaiKhoans.SingleOrDefault(x => x.ChưcVu.Equals("Admin"));
            var lophocphan = db.LopHocPhans.Where(x => x.MaGV.Equals(id)).ToList();

            var phong = db.Phong_Thi.Where(x => x.TrangThai.Equals("Đang Thi") && x.Xoa == true && x.NguoiTao == tkbomon.TaiKhoan1).ToList();

            foreach (var item in phong)
            {
                if (item.ThoiGianDong < dateTime)
                {

                    var p = db.Phong_Thi.Find(item.MaPhong);
                    p.TrangThai = "Đã Đóng";
                    db.SaveChanges();

                }

            }

            phong = db.Phong_Thi.Where(x => x.TrangThai.Equals("Đã Đóng") && x.Xoa == true && x.NguoiTao == tkbomon.TaiKhoan1).ToList();


         

            return phong;


        }
        public ActionResult DSDEGUI()
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var BoDe = new TracNghiemOnlineDB().Bo_De.Where(x => x.Ma_NguoiTao == session.TaiKhoan1 && x.Xoa == true
             && x.PheDuyet != null).ToList();
            return View(BoDe);
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
            dethi.LoaiDe1 = id;
            Session[ComMon.ComMonStants.ChapterStudy] = dethi;
            return Content("");
        }
        public JsonResult Taode(string SoLuong)
        {
            var soluong = new JavaScriptSerializer().Deserialize<List<SoLuongChuong>>(SoLuong);
            var sessetion = (BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];
            var bo_De1 = sessetion.BoDeThi1;
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
         
            new CauHoiDao().CreateTopic(bo_De1, soluong,session.TaiKhoan1);
            return Json(new
            {
                status = true
            });
        }
     

   
        public ActionResult themde()
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var dethi = (Model.BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];
            dethi.BoDeThi1.Ma_NguoiTao = session.TaiKhoan1;
            new Bode().themde(dethi.BoDeThi1);
            return RedirectToAction("DSDethi", "Bomon");
        }
        public ActionResult loaddethi(string id)
        {
            try
            {
                if (id.Length > 0)
                {
                    var BODETHI = (Model.BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];
                    BODETHI.BoDeThi1 = new BoDeDao().ChapterStudy(long.Parse(id));
                    Session[ComMon.ComMonStants.ChapterStudy] = BODETHI;
                    ViewBag.Mess = "Xem";
                }
                else
                {
                    ViewBag.Mess = "Tao";

                }
            }
            catch
            {
                ViewBag.Mess = "Tao";
            }

            var dethi = (Model.BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];

            return View(dethi.BoDeThi1);
        }

        [HttpPost]
        public JsonResult Updatepheduyet(long maDe, string Pheduyet ,string lydo)
        {
            var tk = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            if (tk.ChưcVu.Contains("Admin"))
            {
                TracNghiemOnlineDB db = new TracNghiemOnlineDB();
                var Bode = db.Bo_De.Where(x => x.Ma_BoDe.Equals(maDe));
                Bode.ToList()[0].PheDuyet = Pheduyet;
                Bode.ToList()[0].TrangThai = false;
                db.SaveChanges();
                if (Pheduyet.Equals("Đã duyệt"))
                {
                    try
                    {

                        Bo_De boDeThi = new Bo_De();
                        boDeThi.NoiDung = Bode.ToList()[0].NoiDung;
                        boDeThi.Ma_Mon = Bode.ToList()[0].Ma_Mon;
                        boDeThi.ThoiGianThi = Bode.ToList()[0].ThoiGianThi;
                        boDeThi.Ma_NguoiTao = Bode.ToList()[0].Ma_NguoiTao;
                        boDeThi.NguoiDuyet = tk.TaiKhoan1;
                        boDeThi.TrangThai = true;
                        boDeThi.Xoa = true;
                        foreach (var item in Bode.ToList()[0].CauHois)
                        {
                            Modell.CauHoi cauHoi = new Modell.CauHoi();
                            cauHoi.Ma_CauHoi = item.Ma_CauHoi;
                            boDeThi.CauHois.Add(cauHoi);
                        }
                        boDeThi.SoCau = boDeThi.CauHois.Count;
                        db.Bo_De.Add(boDeThi);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        string ess = e.Message;
                    }

                    var de = new TracNghiemOnlineDB().BoMons.Select(x => x).ToList().Last();
                }

                List<Bo_De> bo_Des = new TracNghiemOnlineDB().Bo_De.Where(x => x.Xoa == true && x.NguoiDuyet.Equals(tk.TaiKhoan1) && x.TrangThai == false && x.PheDuyet.Equals("Đang xử lý")).ToList();

                var bode1 = (from n in bo_Des
                             select new
                             {
                                 Ten = n.NoiDung,
                                 MaDe = n.Ma_BoDe,
                                 SoCau = n.SoCau,
                                 ThoiGian = n.ThoiGianThi,
                                 TenMon = n.MonHoc.TenMon,
                                 Giaovien = n.GiaoVien.TenGV,
                                 Pheduyet = n.PheDuyet,
                                 Trangthai = n.TrangThai,
                                 Ngay=n.NguoiDuyet,
                             }).ToList();
                return Json(new
                {
                    Bode = bode1

                }, JsonRequestBehavior.AllowGet); ;
            }

            else
            {
                TracNghiemOnlineDB db = new TracNghiemOnlineDB();
                var ds = db.DSGV_ThucHien.Find(maDe);
                ds.trangthai = Pheduyet;
                ds.LyDo = lydo;
                db.SaveChanges();

                if (Pheduyet.Equals("Đã duyệt"))
                {
                    try
                    {
                        var Bode = new TracNghiemOnlineDB().Bo_De.Where(x=>x.Ma_BoDe==ds.MaDE);
                        Bo_De boDeThi = new Bo_De();
                        boDeThi.NoiDung = Bode.ToList()[0].NoiDung;
                        boDeThi.Ma_Mon = Bode.ToList()[0].Ma_Mon;
                        boDeThi.ThoiGianThi = Bode.ToList()[0].ThoiGianThi;
                        boDeThi.Ma_NguoiTao = Bode.ToList()[0].Ma_NguoiTao;
                        boDeThi.NguoiDuyet = tk.TaiKhoan1;
                        boDeThi.TrangThai = true;
                        boDeThi.Xoa = true;
                        foreach (var item in Bode.ToList()[0].CauHois)
                        {
                            Modell.CauHoi cauHoi = new Modell.CauHoi();
                            cauHoi.Ma_CauHoi = item.Ma_CauHoi;
                            boDeThi.CauHois.Add(cauHoi);
                        }
                        boDeThi.SoCau = boDeThi.CauHois.Count;
                        db.Bo_De.Add(boDeThi);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        string ess = e.Message;
                    }

                    var de = new TracNghiemOnlineDB().BoMons.Select(x => x).ToList().Last();
                }

                return Json(new
                {
                  statust=  true,

                }, JsonRequestBehavior.AllowGet); ;


            }


        }
        public JsonResult guide(long maDe)
        {
            var admin = new TracNghiemOnlineDB().TaiKhoans.SingleOrDefault(x => x.ChưcVu.Equals("Admin"));
            var tk = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
          //  var bomon = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];

            

            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
        
            var Bode = db.Bo_De.Find(maDe);
           // var bomon = db.BoMons.Find(tk.TaiKhoan1);
            Bode.TrangThai = false;
            Bode.Ma_NguoiTao = tk.TaiKhoan1;
            DateTime dateTime =(DateTime)Session["Gio"];
            Bode.PheDuyet = "Đang xử lý";
            Bode.ThoiGianMo = dateTime;
            Bode.NguoiDuyet = admin.TaiKhoan1;
            db.SaveChanges();
          List<Bo_De> bo_Des = new Bode().ListALLChapterBM(tk.TaiKhoan1);

            var bode1 = (from n in bo_Des
                         select new
                         {
                             Ten = n.NoiDung,
                             MaDe = n.Ma_BoDe,
                             SoCau = n.CauHois.Count,
                             ThoiGian = n.ThoiGianThi,
                             TenMon = n.MonHoc.TenMon,
                             Giaovien = n.GiaoVien.TenGV,
                             Pheduyet = n.PheDuyet,
                             Trangthai =n.TrangThai,
                         }).ToList();
            return Json(new
            {
                Bode = bode1

            }, JsonRequestBehavior.AllowGet); ;


        }



    }
}