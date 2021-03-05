using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using TracNghiemOnline.Model;
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

        public JsonResult KiemTraPhongThi()
        {
            var classRoom = (Phong_Thi)Session[ComMon.ComMonStants.ExamRoom];
            var KiemTra= new QuanLyThiDAO().ExamitionRoom(classRoom.MaPhong);
            foreach (var item in classRoom.DS_SVThi)
            {
                if (KiemTra.DS_SVThi.ToList().Exists(x => x.Ma_SV == item.Ma_SV && x.TrangThai != item.TrangThai)) {
                    classRoom = KiemTra;
                    Session[ComMon.ComMonStants.ExamRoom] = classRoom;
                    var  DSSV = (from c in classRoom.DS_SVThi select new
                    {
                        MaSV=c.Ma_SV,
                        Ten=c.SinhVien.Ten,
                        TenLop=c.SinhVien.Lop.TenLop,
                        TrangThai=c.TrangThai,

                    }).ToList();
                    return Json(new
                    {
                        Status = true,
                        data=DSSV,

                    }, JsonRequestBehavior.AllowGet) ;
                   
                }

            }

            return Json(new
            {
                Status = false,
            }, JsonRequestBehavior.AllowGet);



        }
        public ActionResult DiemSo(string id)
        {
            var exam = new QuanLyThiDAO().SearDethi(long.Parse(id));
                //(De_Thi)Session[ComMon.ComMonStants.ExamQuesTion];  
         var mark=  new QuanLyThiDAO().Mark(exam);
            return View(mark);
        }
        public ActionResult DanhGiaKetQuahocTap()
        {
            var phonghoc = new QuanLyThiDAO().DanhGiaKetQua();
            return View(phonghoc);
     
        }
        [HttpPost]
       public JsonResult XoaSVPhongThi(string Maphong,long Masv) {
     
            try {
                var phong = new QuanLyThiDAO().ExamitionRoom(Maphong);
                if(phong.TrangThai.Equals("Chưa Thi"))
                {
                    var db = new TracNghiemOnlineDB();
                     var sv=  db.DS_SVThi.SingleOrDefault(x => x.Ma_SV==Masv&& x.MaPhong.Equals(Maphong));
                    db.DS_SVThi.Remove(sv);
                    db.SaveChanges();

                    return Json(new
                    {
                        status = true

                    }) ; 
                }
             
            }
            catch(Exception e)
            {
                return Json(new
                {
                    status = "Không Thể Xóa SV Này"

                }) ;
            }

            return Json(new
            {
                status = "Phòng Đang Thi Không Thể Xóa"

            });

        } 
        public ActionResult KetQuaphongthi(string id)
        {
            var Ketqua = (List<DanhGia>)(new QuanLyThiDAO().ListALLexam(id));

            var DanhGia = new List<Danh_Gia>();
            foreach (var item in Ketqua)
            {
                foreach (var item1 in item.ketQuaThi.De_Thi.Danh_Gia)
                {
                    Danh_Gia danh_Gia = new Danh_Gia();
                    danh_Gia.MaChuong = item1.MaChuong;
                    danh_Gia.Chuong_Hoc = item1.Chuong_Hoc;
                    danh_Gia.SoCauDung = item1.SoCauDung;
                    danh_Gia.TongCau += item1.TongCau; ;
                      danh_Gia.DanhGia = "" + ((double)(item1.SoCauDung / item1.TongCau) * 100)  ;

                    DanhGia.Add(danh_Gia);
                }
                break;
            }
            for (int i = 1; i < Ketqua.Count; i++)
            {
                foreach (var item1 in DanhGia)
                {
                    foreach (var item in Ketqua[i].ketQuaThi.De_Thi.Danh_Gia)
                    {
                        if (item1.MaChuong == item.MaChuong)
                        {
                            item1.SoCauDung += item.SoCauDung;
                            item1.TongCau += item.TongCau;
                            item1.DanhGia= ""+((double)(item1.SoCauDung/item1.TongCau)*100);
                        }

                    }

                }
               
            }
            ViewBag.Maphong = id;
            ViewBag.DanhGia = DanhGia;
            return View(Ketqua);
        }

     

        public ActionResult LopHocPhan()
        {
            var LopHoc = new QuanLyThiDAO().ListClassRom();
            return View(LopHoc);
        }
        public ActionResult PhongThi()
        {
            var PhongThi = new QuanLyThiDAO().ListAllClassRom();
          
            return View(PhongThi);
        }
        public ActionResult CreateClassRoom()
        {
            var monhoc = new MonHocDao().lisALL();
            return View(monhoc);
        }
        public ActionResult ChonDe(string id)
        {
            var classRoom = (Phong_Thi)Session[ComMon.ComMonStants.ExamRoom];
            classRoom.MaBoDe = long.Parse(id);
             classRoom.Bo_De = new BoDeDao().ChapterStudy(long.Parse(id));
            ViewBag.Phong = classRoom;     
            return View("VaoThi1");
        }

        public JsonResult VaoThi(string id)
        {
          
            var classRom = new QuanLyThiDAO().ExamitionRoom(id);
             Session[ComMon.ComMonStants.ExamRoom] = classRom;
            var bode = new BoDeDao().ListALLChapterStudy(long.Parse(classRom.LopHocPhan.MaMon.ToString()));

            var bode1 = (from n in bode
                         select new
                         {
                             Ten=n.NoiDung,
                             MaDe=n.Ma_BoDe,
                             SoCau=n.SoCau,
                             ThoiGian=n.ThoiGianThi,
                             TenMon=n.MonHoc.TenMon,
                            
                             
                         }).ToList();

            return Json(new
            {


                Bode = bode1

            }, JsonRequestBehavior.AllowGet); ;
         
        


        }
        public void DeleteSinhVien(long maSV,string MaLop)
        {
        
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            var SV = db.DS_LopHP.SingleOrDefault(x => x.Ma_LOP.Equals(MaLop) && x.MA_SV == maSV);
            db.DS_LopHP.Remove(SV);
            db.SaveChanges();

        }


        public string CreateLopHoc( string malop ,string mamon )
        {
            new QuanLyThiDAO().CreateClassRoom(malop,mamon);
            return "";
        }
        public  string  CreatePhongThi (string MaLop, string DS , string MaSV)
        {

        
            var DSSV = new JavaScriptSerializer().Deserialize<List<DS_SVThi>>(DS);
            if (MaSV.Length == 0)
            {
                new QuanLyThiDAO().CreateExamitionRoom(MaLop, DSSV);
            }
            else
            {
                new QuanLyThiDAO().CreateSinhVienRoom(MaSV, DSSV);
            }


            return "";
        }

        public ActionResult ToChucThi(string id)
        {
            var classRom = new QuanLyThiDAO().ExamitionRoom(id);
            classRom.Bo_De = new BoDeDao().ChapterStudy(long.Parse(classRom.MaBoDe.ToString()));
            Session[ComMon.ComMonStants.ExamRoom] = classRom;
            DateTime dateTime = DateTime.Parse(classRom.ThoiGianDong.ToString());
            ViewBag.GioThi = dateTime.ToString("yyyy/MM/dd HH:mm:ss");
        
            return View(classRom);
        }

        public JsonResult UpdateExamRoom(string id)
        {
            try
            {
                if (id.Length > 0)
                {
                    TracNghiemOnlineDB db = new TracNghiemOnlineDB();
                    var claass = db.Phong_Thi.Find(id);
                    claass.Xoa = false;
                    db.SaveChanges();
                    return Json(new
                    {
                        status = true
                    });
                }

            }
            catch  { };
        
                var classRoom = (Phong_Thi)Session[ComMon.ComMonStants.ExamRoom];
                classRoom.TrangThai = "Đang Thi";
                new QuanLyThiDAO().UpDatePhongThi(classRoom);

            return Json(new
            {
                status = classRoom.MaPhong
            }) ;


        }
        public ActionResult DSSinhVen(string id)
        {
           var phong  = new QuanLyThiDAO().ClassRom(id);
           ViewBag.phong = phong;
           ViewBag.MaPhong =(string)"" ;
            return View();
        }

        public ActionResult DSSVPhongThi(string id)
        {
            Phong_Thi phong_Thi = new QuanLyThiDAO().ExamitionRoom(id);
              var phongthi = phong_Thi.LopHocPhan;
             
            foreach (var item in phong_Thi.LopHocPhan.DS_LopHP.ToList())
            {
                if (phong_Thi.DS_SVThi.ToList().Exists(x => x.Ma_SV == item.MA_SV))
                {
                    phongthi.DS_LopHP.Remove(item);
                }

            }
     
            ViewBag.phong = phongthi;
            ViewBag.MaPhong = (string)phong_Thi.MaPhong;
            return View("DSSinhVen");
        }

        public ActionResult ThemSinhVien(string id)
        { 
            var Lisv = new QuanLyThiDAO().LissAllSinhVien(id);
            ViewBag.MaPhong = id;
            return View(Lisv);
        }


      public string  LuuSinhVien (string DSlop)
        {
            var dS = new JavaScriptSerializer().Deserialize<List<DS_LopHP>>(DSlop);
            var db = new TracNghiemOnlineDB();
            db.DS_LopHP.AddRange(dS);
            db.SaveChanges();
            return "";
        }
    }
}