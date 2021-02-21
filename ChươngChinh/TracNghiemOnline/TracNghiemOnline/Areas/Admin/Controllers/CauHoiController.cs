using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using TracNghiemOnline.Model;
using TracNghiemOnline.Modell;
using TracNghiemOnline.Modell.Dao;
using EXCELL = Microsoft.Office.Interop.Excel;

namespace TracNghiemOnline.Areas.Admin.Controllers
{
    public class CauHoiController : Controller
    {
        // GET: Admin/CauHoi
        static List<Kho_CauHoi> cauHois=new List<Kho_CauHoi>();
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

        public ActionResult CreateCauHoi(string id)
        {
            ViewBag.MaChuong = id;
   
            return View(cauHois);
        }
    
        public ActionResult LoadQuestion(string id)
        {
                foreach (var item in cauHois)
                {
                    item.Ma_Chuong = long.Parse(id);
                    new CauHoiDao().CreatrQuestion(item);
                }
                cauHois = new List<Kho_CauHoi>();

                return RedirectToAction("Index/" + id, "CauHoi");   
        }
        public ActionResult LoalFile(string id)
        {
           // return View("CreateCauHoi");
          
           return View(cauHois);
        }
        public ActionResult ChonMucDo(string MucDo)
        {
           
            foreach (var item in cauHois)
            {
                item.MucDo = MucDo;
            } 


            return Content("");
        }

        public JsonResult XuLyFile(HttpPostedFileBase file)
        {
            try
            {
                string path = Server.MapPath("~/Content/" + file.FileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                file.SaveAs(path);
                string LINK1 = "Sheet1";
                string conec = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;""", path);    
                string query = string.Format("Select * from  [{0}$]", LINK1);
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(query, conec);
                DataTable dataSet = new DataTable();
                oleDbDataAdapter.Fill(dataSet);
                 cauHois = new List<Kho_CauHoi>();
       
                foreach (DataRow item in dataSet.Rows)
                {
                    Kho_CauHoi cauHoi = new Kho_CauHoi();
                    cauHoi.NoiDung = item["CauHoi"].ToString();
     
                    cauHoi.HinhAnh= item["HinhAnh"].ToString();
                    cauHoi.Dap_AN = new List<Dap_AN>();
                    Dap_AN dapAn = new Dap_AN();
                    dapAn.NoiDung = item["A"].ToString();
                
                    if (item["CauTraLoi"].ToString().Equals("A"))
                    {
                        dapAn.TrangThai = true;
                    }
                    else { dapAn.TrangThai = false; }
                    cauHoi.Dap_AN.Add(dapAn);
                     dapAn = new Dap_AN();
                    dapAn.NoiDung = item["B"].ToString();

                    if (item["CauTraLoi"].ToString().Equals("B"))
                    {
                        dapAn.TrangThai = true;
                    }
                    else { dapAn.TrangThai = false; }
                    cauHoi.Dap_AN.Add(dapAn);
                     dapAn = new Dap_AN();
                    dapAn.NoiDung = item["C"].ToString();

                    if (item["CauTraLoi"].ToString().Equals("C"))
                    {
                        dapAn.TrangThai = true;
                    }
                    else { dapAn.TrangThai = false; }
                    cauHoi.Dap_AN.Add(dapAn);

                     dapAn = new Dap_AN();
                    dapAn.NoiDung= item["D"].ToString();

                    if (item["CauTraLoi"].ToString().Equals("D"))
                    {
                        dapAn.TrangThai = true;
                    }
                    else { dapAn.TrangThai = false; }
                    cauHoi.Dap_AN.Add(dapAn);

                    cauHois.Add(cauHoi);

                }

                return Json(new
                {
                    status = true
                }) ;


            }
            catch 
            {
                return Json(new
                {
                    status = false
                });
            }

            return Json(new
            {
                status = true
            }) ;
        }
    }
}