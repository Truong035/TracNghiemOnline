using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using TracNghiemOnline.Controllers;
using TracNghiemOnline.Model;
using TracNghiemOnline.Modell;
using TracNghiemOnline.Modell.Dao;
using EXCELL = Microsoft.Office.Interop.Excel;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Drawing;
using System.IO;
using System.Net;

namespace TracNghiemOnline.Areas.Admin.Controllers
{
    public class CauHoiController : BaseController
    {
        // GET: Admin/CauHoi
       // static List<Kho_CauHoi> cauHois=new List<Kho_CauHoi>();
        public ActionResult Index(string id)
        {
            ViewBag.MaChuong = id;
            List<Kho_CauHoi> kho_CauHois = new CauHoiDao().ListQuestion(long.Parse(id));
           
            return View(kho_CauHois);
           
        }
        public ActionResult DapAn(string Ma_CauHoi)
        {
           
            return View();
        }
       
        [HttpPost]
        public PartialViewResult docfileword(HttpPostedFileBase file, string id)
        {
            List<Kho_CauHoi> cauHois = new List<Kho_CauHoi>();
            ViewBag.MaChuong = id;
            DateTime aDateTime = DateTime.Now;
            object path = Server.MapPath("~/Content/" + file.FileName);
            if (System.IO.File.Exists(path.ToString()))
            {
                System.IO.File.Delete(path.ToString());
            }

            file.SaveAs(path.ToString());

            List<String> anh = new List<string>();
            string totalText = "";
            Document document = new Document(path.ToString());


            //Get Each Section of Document  
            foreach (Section section in document.Sections)
            {
                //Get Each Paragraph of Section  
                foreach (Paragraph paragraph in section.Paragraphs)
                {
                    //Get Each Document Object of Paragraph Items  
                    foreach (DocumentObject docObject in paragraph.ChildObjects)
                    {
                        //If Type of Document Object is Picture, Extract.  
                        if (docObject.DocumentObjectType == DocumentObjectType.Picture)
                        {
                            int sas = Convert.ToInt32(aDateTime.Year * 12 * 30 * 24 * 60 * 60 + aDateTime.Month * 30 * 24 * 60 * 60 + aDateTime.Day * 24 * 60 * 60 + aDateTime.Hour * 60 * 60 + aDateTime.Minute * 60 + aDateTime.Second);
                            DocPicture pic = docObject as DocPicture;
                            String imgName = Server.MapPath("~/Content/Img/Anh" + sas + String.Format(".png"));
                            anh.Add("/Content/Img/Anh" + sas + String.Format(".png"));
                            //Save Image  
                            pic.Image.Save(imgName, System.Drawing.Imaging.ImageFormat.Png);

                        }

                    }
                    totalText += paragraph.Text.ToString();

                }

            }
            int slanh = 0;
            List<Dap_AN> dapan2 = new List<Dap_AN>();
           cauHois = new List<Kho_CauHoi>();
            for (int i = 0; i < totalText.Length; i++)
            {
                if (totalText[i] == '$' && totalText[i + 1] == 'c' && totalText[i + 2] == '$')
                {
                    int slcau = 0;
                    Kho_CauHoi ch = new Kho_CauHoi();
                    int sldapa = 0;
                    int slda = 0;
                    List<Dap_AN> dapan = new List<Dap_AN>();

                    ch.Dap_AN = new List<Dap_AN>();
                    for (int j = i; j < totalText.Length; j++)
                    {

                        if ((totalText[j] == '$' && totalText[j + 1] == '*' && totalText[j + 2] == '$') || (totalText[j] == '$' && totalText[j + 1] == '$'))
                        {
                            slcau++;
                            Dap_AN da = new Dap_AN();
                            if (slcau == 1)
                            {
                                
                                ch.NoiDung = totalText.Substring(i + 3, j - i - 3);
                              if(ch.NoiDung[0] == '1')
                                {
                                    ch.MucDo = "Nhận Biết";
                                }
                                else if (ch.NoiDung[0] == '1')
                                {
                                    ch.MucDo = "Thông Hiểu";
                                }
                                else if (ch.NoiDung[0] == '1')
                                {
                                    ch.MucDo = "Vận Dụng";
                                }
                                else if (ch.NoiDung[0] == '1')
                                {
                                    ch.MucDo = "Vận Dụng Cao";
                                }
                                else ch.MucDo = "Chua có mức độ"; 
                                ch.NoiDung = ch.NoiDung.Substring(1, ch.NoiDung.Length-1);
                                ch.HinhAnh = "";
                                for (int z = 0; z < ch.NoiDung.Length - 2; z++)
                                {
                                    if (ch.NoiDung[z] == '#' && ch.NoiDung[z + 1] == 'h' && ch.NoiDung[z + 2] == '#')
                                    {

                                        ch.HinhAnh = anh[slanh];
                                        slanh++;
                                        ch.NoiDung = ch.NoiDung.Substring(0, z);
                                        break;
                                    }

                                }

                            }


                            if(ch.MucDo== "Chua có mức độ") break; 
                            for (int k = j + 2; k < totalText.Length; k++)
                            {


                                if (totalText[j] == '$' && totalText[j + 1] == '*' && totalText[j + 2] == '$')
                                {

                                    if (totalText[k] == '$' && totalText[k + 1] == '$')
                                    {
                                        da.HinhAnh = "";
                                        da.NoiDung = totalText.Substring(j + 3, k - j - 3);
                                        da.TrangThai = true;
                                        for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                        {
                                            if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                            {
                                                da.HinhAnh = anh[slanh];
                                                slanh++;
                                                da.NoiDung = da.NoiDung.Substring(0, z);
                                            }

                                        }
                                        j = k - 1;
                                        ch.Dap_AN.Add(da);


                                    }
                                    else if (totalText[k] == '$' && totalText[k + 1] == 'c' && totalText[k + 2] == '$')
                                    {
                                        da.HinhAnh = "";
                                        da.NoiDung = totalText.Substring(j + 3, k - 3 - j);
                                        da.TrangThai = true;
                                        for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                        {
                                            if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                            {
                                                da.HinhAnh = anh[slanh];
                                                slanh++;
                                                da.NoiDung = da.NoiDung.Substring(0, z);
                                            }

                                        }
                                        sldapa++;
                                        j = k - 1;
                                        ch.Dap_AN.Add(da);
                                        break;
                                    }
                                    else if (k == totalText.Length - 1)
                                    {
                                        da.HinhAnh = "";
                                        da.NoiDung = totalText.Substring(j + 3, totalText.Length - j - 3);
                                        da.TrangThai = true;
                                        for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                        {
                                            if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                            {
                                                da.HinhAnh = anh[slanh];
                                                slanh++;
                                                da.NoiDung = da.NoiDung.Substring(0, z);
                                            }

                                        }
                                        sldapa++;
                                        j = totalText.Length - 1;
                                        ch.Dap_AN.Add(da);
                                        break;
                                    }
                                }

                                else if (totalText[j] == '$' && totalText[j + 1] == '$')
                                {

                                    if (totalText[k] == '$' && totalText[k + 1] == '$')
                                    {
                                        da.HinhAnh = "";
                                        da.NoiDung = totalText.Substring(j + 2, k - j - 2);
                                        da.TrangThai = false;
                                        for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                        {
                                            if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                            {
                                                da.HinhAnh = anh[slanh];
                                                slanh++;
                                                da.NoiDung = da.NoiDung.Substring(0, z);
                                            }

                                        }
                                        j = k - 1;
                                        ch.Dap_AN.Add(da);


                                    }
                                    else if (totalText[k] == '$' && totalText[k + 1] == '*' && totalText[k + 2] == '$')
                                    {
                                        da.HinhAnh = "";
                                        da.NoiDung = totalText.Substring(j + 2, k - j - 2);
                                        da.TrangThai = false;
                                        for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                        {
                                            if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                            {
                                                da.HinhAnh = anh[slanh];
                                                slanh++;
                                                da.NoiDung = da.NoiDung.Substring(0, z);
                                            }

                                        }
                                        j = k - 1;
                                        ch.Dap_AN.Add(da);

                                    }
                                    else if (totalText[k] == '$' && totalText[k + 1] == 'c' && totalText[k + 2] == '$')
                                    {
                                        da.HinhAnh = "";
                                        da.NoiDung = totalText.Substring(j + 2, k - j - 2);
                                        da.TrangThai = false;
                                        for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                        {
                                            if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                            {
                                                da.HinhAnh = anh[slanh];
                                                slanh++;
                                                da.NoiDung = da.NoiDung.Substring(0, z);
                                            }

                                        }
                                        sldapa++;
                                        j = k - 1;
                                        ch.Dap_AN.Add(da);
                                        break;
                                    }
                                    else if (k == totalText.Length - 1)
                                    {
                                        da.HinhAnh = "";
                                        da.NoiDung = totalText.Substring(j + 2, totalText.Length - j - 2);
                                        da.TrangThai = false;
                                        for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                        {
                                            if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                            {
                                                da.HinhAnh = anh[slanh];
                                                slanh++;
                                                da.NoiDung = da.NoiDung.Substring(0, z);
                                            }

                                        }
                                        sldapa++;
                                        ch.Dap_AN.Add(da);
                                        j = totalText.Length - 1;
                                        break;
                                    }
                                }

                            }



                        }



                        if (sldapa != 0)
                        {
                            cauHois.Add(ch);
                            break;
                        }


                    }
                }


            }
            Session[ComMon.ComMonStants.Cauhoi] = cauHois;
            return PartialView(cauHois);

        }

        public ActionResult CreateCauHoi(string id)
        {
            ViewBag.MaChuong = id;
            List<Kho_CauHoi> cauHois = (List<Kho_CauHoi>)Session[ComMon.ComMonStants.Cauhoi];
            try
            {
                if (cauHois.Count == 0)
                {
                    cauHois = new List<Kho_CauHoi>();
                }

            }
            catch
            {
                cauHois = new List<Kho_CauHoi>();
            }
            return View(cauHois);
        }
    
        public ActionResult LoadQuestion(string id)
        {
            List<Kho_CauHoi> cauHois = (List<Kho_CauHoi>)Session[ComMon.ComMonStants.Cauhoi];
            foreach (var item in cauHois)
                {
                
                    item.Ma_Chuong = long.Parse(id);    
                    new CauHoiDao().CreatrQuestion(item);
                }
                cauHois = new List<Kho_CauHoi>();
            Session[ComMon.ComMonStants.Cauhoi]=cauHois;
            return RedirectToAction("Index/" + id, "CauHoi");   
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
            if (path.Contains("https"))
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

            return "/Content/Img/" + Filename; 
        }
        public ActionResult LoalFile(string id)
        {
            // return View("CreateCauHoi");
            List<Kho_CauHoi> cauHois = (List<Kho_CauHoi>)Session[ComMon.ComMonStants.Cauhoi];
            return View(cauHois);
        }
        public ActionResult ChonMucDo(string MucDo)
        {
            List<Kho_CauHoi> cauHois = (List<Kho_CauHoi>)Session[ComMon.ComMonStants.Cauhoi];
            foreach (var item in cauHois)
            {
                item.MucDo = MucDo;
            } 


            return Content("");
        }
        public JsonResult XuLyFile(HttpPostedFileBase file)
        {
            List<Kho_CauHoi> cauHois =new  List<Kho_CauHoi>();
            string strExtexsion = Path.GetFileName(file.FileName).Trim();

            if (strExtexsion.Contains(".xls"))
            {
                try
                {
                    string path = Server.MapPath("~/Content/" + file.FileName);
                    try
                    {
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        file.SaveAs(path);
                    }
                    catch { }


                    EXCELL.Application application = new EXCELL.Application();
                    EXCELL.Workbook workbook = application.Workbooks.Open(path);
                    EXCELL.Worksheet worksheet = workbook.ActiveSheet;


                    EXCELL.Range range = worksheet.UsedRange;

                    cauHois = new List<Kho_CauHoi>();

                    for (int i = 2; i <= range.Rows.Count; i++)
                    {
                        try
                        {

                            Kho_CauHoi cauHoi = new Kho_CauHoi();

                            cauHoi.NoiDung = ((EXCELL.Range)range.Cells[i, 1]).Text;

                            cauHoi.HinhAnh = ((EXCELL.Range)range.Cells[i, 8]).Text;


                            if (((EXCELL.Range)range.Cells[i, 7]).Text.Equals("1"))
                            {
                                cauHoi.MucDo = "Nhận Biết";
                            }
                            else if (((EXCELL.Range)range.Cells[i, 7]).Text.Equals("2"))
                            {
                                cauHoi.MucDo = "Thông Hiểu";
                            }
                            else if (((EXCELL.Range)range.Cells[i, 7]).Text.Equals("3"))
                            {
                                cauHoi.MucDo = "Vận Dụng";
                            }
                            else
                            {
                                cauHoi.MucDo = "Vận Dụng Cao";
                            }




                            cauHoi.Dap_AN = new List<Dap_AN>();
                            Dap_AN dapAn = new Dap_AN();
                            dapAn.NoiDung = ((EXCELL.Range)range.Cells[i, 2]).Text;
                            dapAn.HinhAnh = ((EXCELL.Range)range.Cells[i, 9]).Text;

                            if (((EXCELL.Range)range.Cells[i, 6]).Text.Equals("A"))
                            {
                                dapAn.TrangThai = true;
                            }


                            else { dapAn.TrangThai = false; }
                            cauHoi.Dap_AN.Add(dapAn);
                            dapAn = new Dap_AN();
                            dapAn.NoiDung = ((EXCELL.Range)range.Cells[i, 3]).Text;
                            dapAn.HinhAnh = ((EXCELL.Range)range.Cells[i, 10]).Text;

                            if (((EXCELL.Range)range.Cells[i, 6]).Text.Equals("B"))
                            {
                                dapAn.TrangThai = true;
                            }
                            else { dapAn.TrangThai = false; }
                            cauHoi.Dap_AN.Add(dapAn);
                            dapAn = new Dap_AN();
                            dapAn.NoiDung = ((EXCELL.Range)range.Cells[i, 4]).Text;
                            dapAn.HinhAnh = ((EXCELL.Range)range.Cells[i, 11]).Text;

                            if (((EXCELL.Range)range.Cells[i, 6]).Text.Equals("C"))
                            {
                                dapAn.TrangThai = true;
                            }
                            else { dapAn.TrangThai = false; }
                            cauHoi.Dap_AN.Add(dapAn);

                            dapAn = new Dap_AN();
                            dapAn.NoiDung = ((EXCELL.Range)range.Cells[i, 5]).Text;
                            dapAn.HinhAnh = ((EXCELL.Range)range.Cells[i, 12]).Text;

                            if (((EXCELL.Range)range.Cells[i, 6]).Text.Equals("D"))
                            {
                                dapAn.TrangThai = true;
                            }
                            else { dapAn.TrangThai = false; }
                            cauHoi.Dap_AN.Add(dapAn);

                            cauHois.Add(cauHoi);

                        }
                        catch
                        {

                        }
                    }


                    application.Workbooks.Close();
                    try
                    {
                        System.IO.File.Delete(path);
                    }
                    catch { }

                    foreach (var item in cauHois)
                    {


                        try
                        {
                            if (item.HinhAnh.Length > 0)
                            {
                                item.HinhAnh = copyanh(item.HinhAnh.Trim());

                            }
                            foreach (var item1 in item.Dap_AN)
                            {

                                if (item1.HinhAnh.Length > 0)
                                {
                                    item1.HinhAnh = copyanh(item1.HinhAnh.Trim());

                                }
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }



                    }
                    Session[ComMon.ComMonStants.Cauhoi] = cauHois;
                    return Json(new
                    {
                        status = true
                    });


                }
                catch
                {
                    return Json(new
                    {
                        status = false
                    });
                }
            }
            else
            {
                DateTime aDateTime = DateTime.Now;
                object path = Server.MapPath("~/Content/" + file.FileName);
                if (System.IO.File.Exists(path.ToString()))
                {
                    System.IO.File.Delete(path.ToString());
                }

                file.SaveAs(path.ToString());

                List<String> anh = new List<string>();
                string totalText = "";
                Document document = new Document(path.ToString());


                //Get Each Section of Document  
                foreach (Section section in document.Sections)
                {
                    //Get Each Paragraph of Section  
                    foreach (Paragraph paragraph in section.Paragraphs)
                    {
                        //Get Each Document Object of Paragraph Items  
                        foreach (DocumentObject docObject in paragraph.ChildObjects)
                        {
                            //If Type of Document Object is Picture, Extract.  
                            if (docObject.DocumentObjectType == DocumentObjectType.Picture)
                            {
                                int sas = Convert.ToInt32(aDateTime.Year * 12 * 30 * 24 * 60 * 60 + aDateTime.Month * 30 * 24 * 60 * 60 + aDateTime.Day * 24 * 60 * 60 + aDateTime.Hour * 60 * 60 + aDateTime.Minute * 60 + aDateTime.Second);
                                DocPicture pic = docObject as DocPicture;
                                String imgName = Server.MapPath("~/Content/Img/Anh" + sas + String.Format(".png"));
                                anh.Add("/Content/Img/Anh" + sas + String.Format(".png"));
                                //Save Image  
                                pic.Image.Save(imgName, System.Drawing.Imaging.ImageFormat.Png);

                            }

                        }
                        totalText += paragraph.Text.ToString();

                    }

                }
                int slanh = 0;
                List<Dap_AN> dapan2 = new List<Dap_AN>();
                cauHois = new List<Kho_CauHoi>();
                for (int i = 0; i < totalText.Length; i++)
                {
                    if (totalText[i] == '$' && totalText[i + 1] == 'c' && totalText[i + 2] == '$')
                    {
                        int slcau = 0;
                        Kho_CauHoi ch = new Kho_CauHoi();
                        int sldapa = 0;
                        int slda = 0;
                        List<Dap_AN> dapan = new List<Dap_AN>();

                        ch.Dap_AN = new List<Dap_AN>();
                        for (int j = i; j < totalText.Length; j++)
                        {

                            if ((totalText[j] == '$' && totalText[j + 1] == '*' && totalText[j + 2] == '$') || (totalText[j] == '$' && totalText[j + 1] == '$'))
                            {
                                slcau++;
                                Dap_AN da = new Dap_AN();
                                if (slcau == 1)
                                {

                                    ch.NoiDung = totalText.Substring(i + 3, j - i - 3);
                                    if (ch.NoiDung[0] == '1')
                                    {
                                        ch.MucDo = "Nhận Biết";
                                    }
                                    else if (ch.NoiDung[0] == '1')
                                    {
                                        ch.MucDo = "Thông Hiểu";
                                    }
                                    else if (ch.NoiDung[0] == '1')
                                    {
                                        ch.MucDo = "Vận Dụng";
                                    }
                                    else if (ch.NoiDung[0] == '1')
                                    {
                                        ch.MucDo = "Vận Dụng Cao";
                                    }
                                    else ch.MucDo = "Chua có mức độ";
                                    ch.NoiDung = ch.NoiDung.Substring(1, ch.NoiDung.Length - 1);
                                    ch.HinhAnh = "";
                                    for (int z = 0; z < ch.NoiDung.Length - 2; z++)
                                    {
                                        if (ch.NoiDung[z] == '#' && ch.NoiDung[z + 1] == 'h' && ch.NoiDung[z + 2] == '#')
                                        {

                                            ch.HinhAnh = anh[slanh];
                                            slanh++;
                                            ch.NoiDung = ch.NoiDung.Substring(0, z);
                                            break;
                                        }

                                    }

                                }


                                if (ch.MucDo == "Chua có mức độ") break;
                                for (int k = j + 2; k < totalText.Length; k++)
                                {


                                    if (totalText[j] == '$' && totalText[j + 1] == '*' && totalText[j + 2] == '$')
                                    {

                                        if (totalText[k] == '$' && totalText[k + 1] == '$')
                                        {
                                            da.HinhAnh = "";
                                            da.NoiDung = totalText.Substring(j + 3, k - j - 3);
                                            da.TrangThai = true;
                                            for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                            {
                                                if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                                {
                                                    da.HinhAnh = anh[slanh];
                                                    slanh++;
                                                    da.NoiDung = da.NoiDung.Substring(0, z);
                                                }

                                            }
                                            j = k - 1;
                                            ch.Dap_AN.Add(da);


                                        }
                                        else if (totalText[k] == '$' && totalText[k + 1] == 'c' && totalText[k + 2] == '$')
                                        {
                                            da.HinhAnh = "";
                                            da.NoiDung = totalText.Substring(j + 3, k - 3 - j);
                                            da.TrangThai = true;
                                            for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                            {
                                                if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                                {
                                                    da.HinhAnh = anh[slanh];
                                                    slanh++;
                                                    da.NoiDung = da.NoiDung.Substring(0, z);
                                                }

                                            }
                                            sldapa++;
                                            j = k - 1;
                                            ch.Dap_AN.Add(da);
                                            break;
                                        }
                                        else if (k == totalText.Length - 1)
                                        {
                                            da.HinhAnh = "";
                                            da.NoiDung = totalText.Substring(j + 3, totalText.Length - j - 3);
                                            da.TrangThai = true;
                                            for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                            {
                                                if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                                {
                                                    da.HinhAnh = anh[slanh];
                                                    slanh++;
                                                    da.NoiDung = da.NoiDung.Substring(0, z);
                                                }

                                            }
                                            sldapa++;
                                            j = totalText.Length - 1;
                                            ch.Dap_AN.Add(da);
                                            break;
                                        }
                                    }

                                    else if (totalText[j] == '$' && totalText[j + 1] == '$')
                                    {

                                        if (totalText[k] == '$' && totalText[k + 1] == '$')
                                        {
                                            da.HinhAnh = "";
                                            da.NoiDung = totalText.Substring(j + 2, k - j - 2);
                                            da.TrangThai = false;
                                            for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                            {
                                                if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                                {
                                                    da.HinhAnh = anh[slanh];
                                                    slanh++;
                                                    da.NoiDung = da.NoiDung.Substring(0, z);
                                                }

                                            }
                                            j = k - 1;
                                            ch.Dap_AN.Add(da);


                                        }
                                        else if (totalText[k] == '$' && totalText[k + 1] == '*' && totalText[k + 2] == '$')
                                        {
                                            da.HinhAnh = "";
                                            da.NoiDung = totalText.Substring(j + 2, k - j - 2);
                                            da.TrangThai = false;
                                            for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                            {
                                                if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                                {
                                                    da.HinhAnh = anh[slanh];
                                                    slanh++;
                                                    da.NoiDung = da.NoiDung.Substring(0, z);
                                                }

                                            }
                                            j = k - 1;
                                            ch.Dap_AN.Add(da);

                                        }
                                        else if (totalText[k] == '$' && totalText[k + 1] == 'c' && totalText[k + 2] == '$')
                                        {
                                            da.HinhAnh = "";
                                            da.NoiDung = totalText.Substring(j + 2, k - j - 2);
                                            da.TrangThai = false;
                                            for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                            {
                                                if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                                {
                                                    da.HinhAnh = anh[slanh];
                                                    slanh++;
                                                    da.NoiDung = da.NoiDung.Substring(0, z);
                                                }

                                            }
                                            sldapa++;
                                            j = k - 1;
                                            ch.Dap_AN.Add(da);
                                            break;
                                        }
                                        else if (k == totalText.Length - 1)
                                        {
                                            da.HinhAnh = "";
                                            da.NoiDung = totalText.Substring(j + 2, totalText.Length - j - 2);
                                            da.TrangThai = false;
                                            for (int z = 0; z < da.NoiDung.Length - 2; z++)
                                            {
                                                if (da.NoiDung[z] == '#' && da.NoiDung[z + 1] == 'h' && da.NoiDung[z + 2] == '#')
                                                {
                                                    da.HinhAnh = anh[slanh];
                                                    slanh++;
                                                    da.NoiDung = da.NoiDung.Substring(0, z);
                                                }

                                            }
                                            sldapa++;
                                            ch.Dap_AN.Add(da);
                                            j = totalText.Length - 1;
                                            break;
                                        }
                                    }

                                }



                            }



                            if (sldapa != 0)
                            {
                                cauHois.Add(ch);
                                break;
                            }


                        }
                    }


                }
                Session[ComMon.ComMonStants.Cauhoi] = cauHois;
            }

            return Json(new
            {
                status = true
            });

        }

        
    }
}