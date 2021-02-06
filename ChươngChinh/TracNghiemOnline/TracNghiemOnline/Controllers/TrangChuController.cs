using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace TracNghiemOnline.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Loald( string id)
        {
            return View();
        }
        public  ActionResult LuaChon( string id)
        {
           
            return Content("");

        }

        public ActionResult BieuDo()
        {
            var c =new Array[1, 3, 4, 5, 1];
            return Content(c.ToString());
        }

        public ActionResult MonHoc(string id)
        {

            return View();
        }

        
             public ActionResult DanhGia(string id)
        {

            return View();
        }
        public ActionResult TAODE(string id)
        {

            return View();
        }

    }
}