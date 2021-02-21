using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TracNghiemOnline.Modell;
using TracNghiemOnline.Modell.Dao;

namespace TracNghiemOnline.Areas.Admin.Controllers
{
    public class QuanLyThiController : Controller
    {
        // GET: Admin/QuanLyThi
        public ActionResult KiThi()
        {
            return View();
        }
        public ActionResult DiemSo(string id)
        {
        var exam =(De_Thi)Session[ComMon.ComMonStants.ExamQuesTion];
            int Diem=0;
         var mark=  new QuanLyThiDAO().Mark(exam);
          
            return View(mark);
        }
        public ActionResult LopHocPhan()
        {
            return View();
        }
        public ActionResult PhongThi()
        {
            return View();
        }
        public ActionResult ToChucThi()
        {
            return View();
        }
        public ActionResult DSSinhVen(string id)
        {
            return View();
        }
        public ActionResult ThemSinhVien(string id)
        {
            return View();
        }
    }
}