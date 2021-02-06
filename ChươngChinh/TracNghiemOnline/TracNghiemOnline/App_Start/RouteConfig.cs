using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TracNghiemOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "ThiThu",
               url: "ThiThu/{id}",
               defaults: new { controller = "TrangChu", action = "Loald", id = UrlParameter.Optional }
           );
     
      
            routes.MapRoute(
           name: "DeThi",
           url: "DeThi/{id}",
           defaults: new { controller = "Home", action = "DSDETHI", id = UrlParameter.Optional }, namespaces: new[] { "TracNghiemOnline.Areas.Admin.Controllers" }


       );


            routes.MapRoute(
               name: "TaoDe",
               url: "TaoDe/{id}",
               defaults: new { controller = "TrangChu", action = "TAODE", id = UrlParameter.Optional }
           );


            routes.MapRoute(
               name: "DanhGiaKetQuahocTap",
               url: "DanhGiaKetQuahocTap/{id}",
               defaults: new { controller = "TrangChu", action = "DanhGia", id = UrlParameter.Optional }
           );


            routes.MapRoute(
            name: "DSMONHOC",
            url: "DSMONHOC/{id}",
            defaults: new { controller = "TrangChu", action = "MonHoc", id = UrlParameter.Optional }
        );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
