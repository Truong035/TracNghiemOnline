using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows.Forms;
//using System.Windows.Forms;
using TracNghiemOnline.Modell;
using TracNghiemOnline.Modell.Dao;

namespace TracNghiemOnline.Controllers
{
    public class TrangChuController : BaseController
    {
        // GET: TrangChu
        [HttpGet]
        
        public ActionResult Index()
        {
            var list = new BoDeDao().ListALLChapterStudy();
            return View(list);
        }
      
        public ActionResult Loald( string id)
        {
            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var list = new BoDeDao().ChapterStudy(long.Parse(id));
            var Exem =new BoDeDao().MixExemQuestion(list,session.TaiKhoan1);
             Session[ComMon.ComMonStants.ExamQuesTion]=Exem;
            DateTime data = DateTime.Now.AddMinutes(double.Parse(list.ThoiGianThi));
            ViewBag.GioThi= data.ToString("yyyy/MM/dd HH:mm:ss");
            ViewBag.DeThi =(De_Thi) Exem;
            return View();
        }
        
        public  ActionResult LuaChon(string madethi ,string id)
        {
            var examQuestion = (De_Thi)Session[ComMon.ComMonStants.ExamQuesTion];
            foreach (var item in examQuestion.CauHoiDeThis)
            {
                foreach (var item1 in item.Kho_CauHoi.Dap_AN)
                {
                    if (item1.MA_DAN == long.Parse(id))
                    {
                        foreach (var item2 in item.Kho_CauHoi.Dap_AN)
                        {
                            if (item2.MA_DAN == long.Parse(id))
                            {
                                item2.TrangThai = true;
                            }
                            else
                            {
                                item2.TrangThai = false;
                            }
                        }
                    }

                  
                }

            }
          
            new BoDeDao().OptionStudent(examQuestion);
            Session[ComMon.ComMonStants.ExamQuesTion] = examQuestion;
            return Content("");

        }
        [ChildActionOnly]
        public ActionResult DangNhapPhongThi()
        {
            return PartialView();
        }
 
        public ActionResult VaoThi(string id)
        {
          
            var phong = new QuanLyThiDAO().ExamitionRoom(id);
            if(phong.TrangThai.Equals("Chưa Thi"))
            {
                ViewBag.MaPhong = id;
                return View("PhongCho");
            }

            var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
            var DeThi = new QuanLyThiDAO().SeachForTheExam(phong,session.TaiKhoan1);
            if (DeThi == null)
            {
          
                var list = new BoDeDao().ChapterStudy(long.Parse("10013"));
                DeThi = new BoDeDao().MixExemQuestion(list, session.TaiKhoan1);
           
                DateTime data = DateTime.Now.AddMinutes(double.Parse(list.ThoiGianThi));

            }

            new BoDeDao().UpdateDsThi(phong, DeThi,session.TaiKhoan1);
            Session[ComMon.ComMonStants.ExamQuesTion] = DeThi;
            DateTime dateTime =DateTime.Parse(phong.ThoiGianDong.ToString());
            ViewBag.GioThi = dateTime.ToString("yyyy/MM/dd HH:mm:ss");
          
            return View(DeThi);
         
        }
        public JsonResult KiemTra(string MaPhong)
        {
            var phong = new QuanLyThiDAO().ExamitionRoom(MaPhong);
            try
            {
                if (phong.TrangThai.Contains("Chưa Thi"))
                {
                    return Json(new
                    {

                        status = false

                    });

                }
                return Json(new
                {

                    status = true

                });
            }
            catch {
                return Json(new
                {

                    status = true

                });
            }

          


        }

        public JsonResult PhongThi(string MaPhong)
        {
            var Phong = new QuanLyThiDAO().ExamitionRoom(MaPhong);
            if (Phong == null)
            {
                return Json(new
                {

                    status = "Mã Bạn Nhập Không Đúng Vui Lòng Kiểm Tra Lai"

                });

            }
            else
            {
                
                    if (Phong.TrangThai.Contains("Đã Đóng"))
                    {
                        return Json(new
                        {

                            status = "Phòng Thi Đã Kết Thúc Lúc" + Phong.ThoiGianDong.ToString()

                        });


                    }
               
                else
                {
                    var session = (TaiKhoan)Session[ComMon.ComMonStants.UserLogin];
                    var Check = new QuanLyThiDAO().Check(MaPhong, session.TaiKhoan1);
                    if (Check != null)
                    {
                        return Json(new
                        {

                            status = true

                        });
                    }
                    else
                    {
                        return Json(new
                        {

                            status = "Phòng Này Bạn Không Thể Thi"

                        });
                    }

                }
            }
         
            
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