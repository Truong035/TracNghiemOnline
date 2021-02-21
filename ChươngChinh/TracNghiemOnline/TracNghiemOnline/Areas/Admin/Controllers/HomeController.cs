using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.WebPages;
using System.Windows.Forms;
using TracNghiemOnline.Model;
using TracNghiemOnline.Modell;
using TracNghiemOnline.Modell.Dao;
using FormCollection = System.Web.Mvc.FormCollection;

namespace TracNghiemOnline.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [HttpGet]
    
        public ActionResult Index()
        {
            reseach();
            return View();
          
        }
   
        public void reseach()
        {
            Model.BoDeThi boDeThi = new BoDeThi();
            bo_De1.Ma_Mon = 0;
            bo_De1.ThoiGianThi = "";
            boDeThi.LoaiDe1 = "";
            boDeThi.BoDeThi1 = bo_De1;
            Session[ComMon.ComMonStants.ChapterStudy] = boDeThi;
        }
        public ActionResult DSDETHI(string id)
        {
            reseach();
           List <Bo_De> bo_Des = new BoDeDao().ListALLChapterStudy();
            return View(bo_Des);
        }
      
        public ActionResult TaoDeThi()
        {
           
            var dao = new TracNghiemOnline.Modell.TracNghiemOnlineDB().MonHocs.Select(x => x).ToList();
            ViewBag.MonHoc = dao;
            ViewBag.A ="";
            ViewBag.B = "";
            ViewBag.C = "";
            reseach();
            return View();
         
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
            dethi.LoaiDe1=id;
            Session[ComMon.ComMonStants.ChapterStudy] = dethi;
            return Content("");
        }
        private static Bo_De bo_De1=new Bo_De();
        [HttpPost]
        public ActionResult MonHoc(Bo_De bo_De)
        {
            var dethi = (Model.BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];
            if (ModelState.IsValid && dethi.BoDeThi1.ThoiGianThi.Length>0 && dethi.LoaiDe1.Length>0 && dethi.BoDeThi1.Ma_Mon>0)
            {
                bo_De.ThoiGianThi = dethi.BoDeThi1.ThoiGianThi;
                bo_De.Ma_Mon = dethi.BoDeThi1.Ma_Mon;

                bo_De.MonHoc = new MonHocDao().Subject(long.Parse(bo_De.Ma_Mon.ToString()));
                 bo_De1 = bo_De;
                Session[ComMon.ComMonStants.ChapterStudy] = dethi;
                
               
                List<SoLuongChuong> sl = new List<SoLuongChuong>();
                foreach (var item in new TracNghiemOnline.Modell.TracNghiemOnlineDB().Chuong_Hoc.Where(x => x.Ma_Mon == bo_De.Ma_Mon).ToList())
                {
                    SoLuongChuong soLuong = new SoLuongChuong();
                    soLuong.Chuong = item;
                    soLuong.nhanBiet = new CauHoiDao().Nuberofquestion(item.Ma_Chuong, "Nhận Biết").Count()+"";
                    soLuong.thongHieu = new CauHoiDao().Nuberofquestion(item.Ma_Chuong, "Thông Hiểu").Count() + "";
                    soLuong.vandung = new CauHoiDao().Nuberofquestion(item.Ma_Chuong, "Vận Dụng").Count() + "";
                    soLuong.vandungcao = new CauHoiDao().Nuberofquestion(item.Ma_Chuong, "Vận Dụng Cao").Count() + "";

                    sl.Add(soLuong);
                }

                ViewBag.Chuong = (List<SoLuongChuong>)sl;


                return View(bo_De);
            
            }
            else
            {
                string mess = "";
                string mess1 = "";
                string mess2 = "";


                if (dethi.BoDeThi1.ThoiGianThi.Length <= 0)
                {
                    mess = "Bạn Vui Lòng Chọn Thời Gian Thi";
                }
                if (dethi.BoDeThi1.Ma_Mon<= 0)
                {
                    mess1 = "Bạn Vui Lòng Chọn Môn Học ";
                }
                if (dethi.LoaiDe1.Length<= 0)
                {
                    mess2 = "Bạn Vui Lòng Chọn Cách Tạo Đề";
                }
                ViewBag.A = mess;
                ViewBag.B = mess1;
                ViewBag.C = mess2;

            }
            reseach();

            var dao = new TracNghiemOnline.Modell.TracNghiemOnlineDB().MonHocs.Select(x => x).ToList();
            ViewBag.MonHoc = dao;
            return View("TaoDeThi");
      
        }

        public ActionResult LoadDeThi(string id)
        {
       
            return View(bo_De1);
        }
        public ActionResult AddChapterStudy(string id)
        {
            new BoDeDao().CreateChapterStudy(bo_De1);
            bo_De1 = new Bo_De();  
            return RedirectToAction("DSDETHI","Home");
        }



        public ActionResult NgânHangCauHoi(string id)
        {
            reseach();
            List<Modell.MonHoc> monHocs = new MonHocDao().lisALL();
            return View(monHocs);
        }

        public ActionResult ChuongHoc(string id)
        {
            reseach();
            List<Chuong_Hoc> chuong_Hocs = new MonHocDao().ListChapterStudy(long.Parse(id));
            return View(chuong_Hocs);
        }
        public JsonResult TaoDe( string SoLuong)
        {
            var soluong = new JavaScriptSerializer().Deserialize<List<SoLuongChuong>>(SoLuong);
            var sessetion = (BoDeThi)Session[ComMon.ComMonStants.ChapterStudy];
            bo_De1 = sessetion.BoDeThi1;
            new CauHoiDao().CreateTopic(bo_De1,soluong);
            return Json(new
            {
                status = true
            }) ;
        } 
    }
}