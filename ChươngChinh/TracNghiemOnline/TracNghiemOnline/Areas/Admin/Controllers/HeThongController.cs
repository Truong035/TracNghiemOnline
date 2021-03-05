using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TracNghiemOnline.Modell;
namespace TracNghiemOnline.Areas.Admin.Controllers
{
    public class HeThongController : Controller
    {
        TracNghiemOnlineDB db = new TracNghiemOnlineDB();
        // GET: Admin/HeThong
        
        public ActionResult NganhHoc()
        {
            
            return View();
        }        
        public JsonResult dsNganh()
        {
            try
            {
<<<<<<< HEAD
                   var dsNganh = (from n in db.Nganhs where n.DaXoa != 1 
                               select new
                               {
                                   MaNganh = n.Ma_Nganh,
                                   TenNganh = n.TenNganh }).ToList();
=======
                var dsNganh = (from n in db.Nganhs where n.DaXoa != 1 select new { MaNganh = n.Ma_Nganh, 
                    TenNganh = n.TenNganh }).ToList();
>>>>>>> df9173481f8a0f6734c9605cc86ca011ddeb6dcb
                    
                return Json(new { code = 200, dsNganh = dsNganh, msg="Lấy danh sách thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult AddNganh(int maNganh, string tenNganh)
        {
            try
            {
                var n = new Nganh();
                n.Ma_Nganh = maNganh;
                n.TenNganh = tenNganh;
                db.Nganhs.Add(n);
                db.SaveChanges();
                return Json(new { code = 200, msg = "Thêm mới thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message}, JsonRequestBehavior.AllowGet);
            }
        }              
        [HttpPost]
        public JsonResult UpdateNganh(int maNganh, string tenNganh)
        {
            try
            {
                var n = db.Nganhs.SingleOrDefault(x => x.Ma_Nganh == maNganh);
                n.TenNganh = tenNganh;
                db.SaveChanges();
                return Json(new { code = 200, msg = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult DeleteNganh(int maNganh)
        {
            try
            {
                var n = (from d in db.Nganhs where d.Ma_Nganh == maNganh select d).Single();
                n.DaXoa = 1;
                db.SaveChanges();
                return Json(new { code = 200, msg = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SinhVien()
        {
<<<<<<< HEAD
            List<Lop> ltsLop = db.Lops.Where(x=>x.DaXoa!=1).ToList();
=======
            List<Lop> ltsLop = db.Lops.Where(x => x.DaXoa != 1).ToList();
>>>>>>> df9173481f8a0f6734c9605cc86ca011ddeb6dcb
            ViewBag.lstLop = new SelectList(ltsLop, "Ma_Lop", "TenLop");
            return View();
        }
        public JsonResult dsSinhVien()
        {
            try
            {
<<<<<<< HEAD
                //    var dsSV = (from n in db.SinhViens where n.DaXoa != 1
                var dsSV = (from n in db.SinhViens
                            where n.DaXoa != 1
                            select new
=======
                var dsSV = (from n in db.SinhViens where n.DaXoa != 1
                               select new
>>>>>>> df9173481f8a0f6734c9605cc86ca011ddeb6dcb
                               {
                                    MaSV = n.MaSV,
                                    TenSV = n.Ten,
                                    NgaySinh = n.NgaySinh.ToString(),
                                    DiaChi = n.DiaChi,
                                    TenLop = n.Lop.TenLop,
                                    MaLop = n.Lop.Ma_Lop
                               }).ToList();

                return Json(new { code = 200, dsSinhVien = dsSV, msg = "Lấy danh sách thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult AddSinhVien(long maSV, string tenSV, DateTime ngaySinh, string diaChi, string maLop )
        {
            try
            {
                var n = new SinhVien();
                n.MaSV = maSV;
                n.Ten = tenSV;
                n.NgaySinh = ngaySinh;
                n.DiaChi = diaChi;               
                n.Ma_Lop = maLop;
                db.SinhViens.Add(n);             
                db.SaveChanges();
                return Json(new { code = 200, msg = "Thêm mới thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public JsonResult UpdateSinhVien(long maSV, string tenSV, DateTime ngaySinh, string diaChi, string maLop)
        {
            try
            {
                var n = db.SinhViens.SingleOrDefault(x => x.MaSV == maSV);
                n.Ten = tenSV;
                n.NgaySinh = ngaySinh;
                n.DiaChi = diaChi;
                n.Ma_Lop = maLop;
                db.SaveChanges();
                return Json(new { code = 200, msg = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult DeleteSinhVien(long maSV)
        {
            try
            {
                var n = (from d in db.SinhViens where d.MaSV == maSV select d).Single();
                n.DaXoa = 1;
                db.SaveChanges();
                return Json(new { code = 200, msg = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        //Quan li giao vien
        public ActionResult GiaoVien()
        {
            List<Nganh> lstNganh = db.Nganhs.Where(x => x.DaXoa != 1).ToList();
            ViewBag.lstNganh = new SelectList(lstNganh, "Ma_Nganh", "TenNganh");
            return View();
        }
        public JsonResult dsGiaoVien()
        {
            try
            {
                var dsGV = (from n in db.GiaoViens
                            select new
                            {
                                MaGV = n.MaGV,
                                TenGV = n.TenGV,
                                TenNganh = n.Nganh.TenNganh,
                                MaNganh = n.Nganh.Ma_Nganh
                               
                            }).ToList();

                return Json(new { code = 200, dsGiaoVien = dsGV, msg = "Lấy danh sách thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult AddGiaoVien(long maGV, string tenGV, long maNganh)
        {
            try
            {
                var n = new GiaoVien();
                n.MaGV = maGV;
                n.TenGV = tenGV;
                n.Ma_Nganh = maNganh;
                db.GiaoViens.Add(n);
                db.SaveChanges();
                return Json(new { code = 200, msg = "Thêm mới thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdateGiaoVien(long maGV, string tenGV, long maNganh)
        {
            try
            {
                var n = db.GiaoViens.SingleOrDefault(x => x.MaGV== maGV);
                n.TenGV = tenGV;
                n.Ma_Nganh = maNganh;
                db.SaveChanges();
                return Json(new { code = 200, msg = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult DeleteGiaoVien(int maGV)
        {
            try
            {
                var n = (from d in db.GiaoViens where d.MaGV == maGV select d).Single();
                db.GiaoViens.Remove(n);
                db.SaveChanges();
                return Json(new { code = 200, msg = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        //Quan li lop
        public ActionResult Lop()
        {
            List<Nganh> lstNganh = db.Nganhs.Where(x => x.DaXoa != 1).ToList();
            ViewBag.lstNganh = new SelectList(lstNganh, "Ma_Nganh", "TenNganh");
            return View();
        }
        public JsonResult dsLop()
        {
            try
            {
                var dsLop = (from n in db.Lops where n.DaXoa != 1
                            select new
                            {
                                MaLop = n.Ma_Lop,
                                TenLop = n.TenLop,
                                TenNganh = n.Nganh.TenNganh,
                                MaNganh = n.Nganh.Ma_Nganh

                            }).ToList();

                return Json(new { code = 200, dsLop = dsLop, msg = "Lấy danh sách thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult AddLop(string maLop, string tenLop, long maNganh)
        {
            try
            {
                var n = new Lop();
                n.Ma_Lop = maLop;
                n.TenLop = tenLop;
                n.Ma_Nganh = maNganh;
                db.Lops.Add(n);
                db.SaveChanges();
                return Json(new { code = 200, msg = "Thêm mới thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdateLop(string maLop, string tenLop, long maNganh)
        {
            try
            {
                var n = db.Lops.SingleOrDefault(x => x.Ma_Lop == maLop);
                n.TenLop = tenLop;
                n.Ma_Nganh = maNganh;
                db.SaveChanges();
                return Json(new { code = 200, msg = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult DeleteLop(string maLop)
        {
            try
            {
                var n = (from d in db.Lops where d.Ma_Lop == maLop select d).Single();
                n.DaXoa = 1;
                db.SaveChanges();
                return Json(new { code = 200, msg = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}