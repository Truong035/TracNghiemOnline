using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TracNghiemOnline.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DSDETHI(string id)
        {

            return View();
        }
        public ActionResult TaoDeThi(string id)
        {

            return View();
        }
        public ActionResult MonHoc(string id)
        {

            return View();
        }
        public ActionResult NgânHangCauHoi(string id)
        {

            return View();
        }

        public ActionResult CauHoi(string id)
        {

            return View();
        }

        public ActionResult ChuongHoc(string id)
        {

            return View();
        }
    }
}