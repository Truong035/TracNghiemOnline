using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TracNghiemOnline.Modell;

namespace TracNghiemOnline.Controllers
{
    public class BaseController1Controller : Controller
    {
        // GET: BaseController1
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
               new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Login" }));
            }
            else
            {
                LopHocPhan lopHocPhan = (LopHocPhan)Session["LopHP"];
                if (lopHocPhan == null)
                {
                    filterContext.Result = new RedirectToRouteResult(
              new System.Web.Routing.RouteValueDictionary(new { controller = "TrangChu", action = "LopHocPhan" }));
                }
            }


            base.OnActionExecuting(filterContext);
        }
    }
}