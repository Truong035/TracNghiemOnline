using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TracNghiemOnline.Modell;
using TracNghiemOnline.Modell.Dao;

namespace TracNghiemOnline.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            List<Modell.MonHoc> monHocs = new MonHocDao().lisALL(session.TaiKhoan1);
            return View(monHocs);
        }
        public ActionResult DSDeThi()
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var dsdethi = new TracNghiemOnlineDB().Bo_De.Where(x => x.TrangThai==true && x.NguoiDuyet.Equals(session.TaiKhoan1) ).ToList();
            return View(dsdethi);
            
        }


       

        public ActionResult Chonde(long id)
        {

          
            return View();
        }

        public string CreatePhongThi(string MaLop, string DS, string MaSV, string nd, string GV1, string GV2,DateTime Ngay)
        {
            var DSSV = new JavaScriptSerializer().Deserialize<List<DS_SVThi>>(DS);

            if (MaSV.Length == 0)
            {
                var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
                new QuanLyThiDAO().CreateExamitionRoom(MaLop, session.TaiKhoan1, DSSV, nd, GV1, GV2,Ngay);
            }
            else
            {
                new QuanLyThiDAO().CreateSinhVienRoom(MaSV, DSSV);
            }
            return "";
        }
        public ActionResult TaoPhong()
        {
            DateTime dateTime = (DateTime)Session["Gio"];

            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var PhongThi = new QuanLyThiDAO().ListAllClassRom(session.TaiKhoan1,dateTime);
            return View(PhongThi);
        }
    }
}