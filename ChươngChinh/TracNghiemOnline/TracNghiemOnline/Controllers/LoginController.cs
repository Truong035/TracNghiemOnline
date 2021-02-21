using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using TracNghiemOnline.Modell;

namespace TracNghiemOnline.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult DangNhap(TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                var TK = new Modell.Dao.LoginDao().Login(taiKhoan);
                if (TK != null)
                {
                    Session.Add(ComMon.ComMonStants.UserLogin,TK);
                    return RedirectToAction("Index", "TrangChu");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng Nhập Không Đúng ");
                }
             
            }
            return View("Login");
        }
    }
}