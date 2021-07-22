using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TracNghiemOnline.Modell;
using TracNghiemOnline.Model;
using TracNghiemOnline.ComMon;
using TracNghiemOnline.Modell.Dao;
using System.Web.Script.Serialization;
using PagedList;

namespace TracNghiemOnline.Controllers
{
    public class LopHPController : BaseController1Controller
    {
        // GET: LopHP
    
        public ActionResult OnTap()
        {
            LopHocPhan lopHocPhan = (LopHocPhan)Session["LopHP"];

          
            return View(new TracNghiemOnlineDB().Chuong_Hoc.Where(x => x.TrangThai == 1 && x.Ma_Mon==lopHocPhan.MaMon));
        }
        public ActionResult HocBai(long? id)
        {

            if (id == null)
            {
                return View("Error");
            }
            var session = (TaiKhoan)Session[ComMonStants.UserLogin];
       //     ViewBag.Name = session.;
            ViewBag.ID = id;
            return View();
        }

        public ActionResult QuanLy(int? page)
        {
            LopHocPhan lopHocPhan = (LopHocPhan)Session["LopHP"];
            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;
            TaiKhoan tk = (TaiKhoan)Session[ComMonStants.UserLogin];
            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = (from l in new TracNghiemOnlineDB().De_Thi.Where(x => x.Ma_SV.Equals(tk.TaiKhoan1) && x.MaMon==lopHocPhan.MaMon).ToList()
                         select l).OrderByDescending(x => x.NgayThi);

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 4;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
          
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));


        }

        public void TaoDe(string nd, string tgbd, int sl, int mucdo)
        {
            TaiKhoan tk = (TaiKhoan)Session[ComMonStants.UserLogin];
            LopHocPhan lopHocPhan = (LopHocPhan)Session["LopHP"];
            string[] list = nd.Split('/');
            string[] ngay = tgbd.Split('/');
            List<NoiDungThi> bai_Hocs = new List<NoiDungThi>();
            for (int i = 0; i < list.Length - 1; i++)
            {
                NoiDungThi noiDungthi = new NoiDungThi();
                noiDungthi.noidung = new TracNghiemOnlineDB().Chuong_Hoc.Find(int.Parse(list[i]));
                bai_Hocs.Add(noiDungthi);
            }
            DanhGia danhGia = new DanhGia();
            danhGia.DanhGiaMucDo1 = bai_Hocs;
            danhGia.ketQuaThi1 = new De_Thi();
            new TaoDeDao().TaoDe(danhGia, sl, mucdo,lopHocPhan) ;
            Session["noidung"] = bai_Hocs;
            danhGia.ketQuaThi1.NgayThi = new DateTime(int.Parse(ngay[0]), int.Parse(ngay[1]), int.Parse(ngay[2]), int.Parse(ngay[3]), int.Parse(ngay[4]), int.Parse(ngay[5])).AddMinutes(2 * sl);
            danhGia.ketQuaThi1.ThoiGianThi = 2 * sl;
            danhGia.ketQuaThi1.DiêmSo = 0;
            danhGia.ketQuaThi1.TrangThai = false;
            danhGia.ketQuaThi1.MaMon = lopHocPhan.MaMon;
            foreach (var item in danhGia.ketQuaThi1.CauHoiDeThis)
            {
                foreach (var item1 in item.Kho_CauHoi.Dap_AN)
                {
                    item1.TrangThai = false;
                }
            }
            DateTime dateTime = new DateTime(int.Parse(ngay[0]), int.Parse(ngay[1]), int.Parse(ngay[2]), int.Parse(ngay[3]), int.Parse(ngay[3]), int.Parse(ngay[4]));


            danhGia.ketQuaThi1.Ma_SV = tk.TaiKhoan1;
            Session["lambai"] = danhGia;
            Session["a"] = (int)1;

        }
        public ActionResult Thi()
        {
            try
            {
                TaiKhoan tk = (TaiKhoan)Session[ComMonStants.UserLogin];
              
                var danhGia = (DanhGia)Session["lambai"];
                DateTime dateTime = DateTime.Parse(danhGia.ketQuaThi1.NgayThi.ToString());
                ViewBag.GioThi = dateTime.ToString("yyyy/MM/dd HH:mm:ss");
                return View(danhGia.ketQuaThi1);
            }
            catch
            {
                return RedirectToAction("OnTap");
            }

        }
        public JsonResult CauHoi(long id)
        {
            try
            {
              LopHocPhan lopHocPhan=(LopHocPhan)Session["LopHP"] ;
                var session = (TaiKhoan)Session[ComMonStants.UserLogin];
              //  TaiKhoan tk = (TaiKhoan)Session["user"];
                De_Thi thi = new De_Thi();
                var danhgia = new TracNghiemOnlineDB().DS_BaiHoc.SingleOrDefault(x => x.Ma_Bai == id && x.MaSV.Equals(session.TaiKhoan1));
                string[] ListCH = danhgia.ListCauHoi.Split('/');
                if (new TracNghiemOnlineDB().Kho_CauHoi.Where(x => x.Ma_Chuong == id && (x.NguoiTao.Equals(lopHocPhan.MaGV) || x.TrangThai == false) && x.Xoa == true).ToList().Count - ListCH.Length < 6) {
                    return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
                };

                new TaoDeDao().CreateTopic(thi, id, session,lopHocPhan);
                var arr = from c in thi.CauHoiDeThis.ToList()
                          select new
                          {
                              Ma_CH = c.Kho_CauHoi.Ma_CauHoi,
                         NoiDung = c.Kho_CauHoi.NoiDung,
                              HinhAnh=   c.Kho_CauHoi.HinhAnh,
                              Dapan = from d in new TracNghiemOnlineDB().Dap_AN.Where(x => x.Ma_CauHoi == c.MaCauHoi).ToList()
                                      select new
                                      {
                                          Ma_Dan=d.MA_DAN,
                                          NoiDung=d.NoiDung,
                                          TrangThai = false,
                                          d.HinhAnh,

                                      }


                          };

                Session["dethi"] = thi;

                return Json(new { arr, code=100 }, JsonRequestBehavior.AllowGet);
            }
            catch { }
            return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);


        }
        public JsonResult KetQuaHocTap()
        {
            try
            {
                var session = (TaiKhoan)Session[ComMonStants.UserLogin];
                De_Thi thi = (De_Thi)Session["dethi"];
                var arr = from c in thi.CauHoiDeThis.ToList()
                          select new
                          {
                              Ma_CH = c.Kho_CauHoi.Ma_CauHoi,
                              NoiDung = c.Kho_CauHoi.NoiDung,
                              HinhAnh = c.Kho_CauHoi.HinhAnh,
                              Dapan = from d in new TracNghiemOnlineDB().Dap_AN.Where(x => x.Ma_CauHoi == c.MaCauHoi).ToList()
                                      select new
                                      {
                                          Ma_Dan = d.MA_DAN,
                                          NoiDung = d.NoiDung,
                                          d.HinhAnh,
                                          d.TrangThai,
                               
                                      }
                          };

                Session["dethi"] = "";
                return Json(new { arr, result = false }, JsonRequestBehavior.AllowGet);
            }
            catch { }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }
        public void Check(long id, long mabai)
        {
            var session = (TaiKhoan)Session[ComMonStants.UserLogin];
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            if (db.Dap_AN.ToList().Exists(x => x.MA_DAN == id && x.TrangThai == true))
            {
                var danhgia = db.DS_BaiHoc.SingleOrDefault(x => x.Ma_Bai == mabai && x.MaSV.Equals(session.TaiKhoan1));
                danhgia.SoCauDung++;
                danhgia.ListCauHoi = danhgia.ListCauHoi.Trim() + new TracNghiemOnlineDB().Dap_AN.Find(id).Ma_CauHoi + "/";
                db.SaveChanges();
            }
            else
            {
                var danhgia = db.DS_BaiHoc.SingleOrDefault(x => x.Ma_Bai == mabai && x.MaSV.Equals(session.TaiKhoan1));
                danhgia.SoCauSai++;
                db.SaveChanges();
            }

        }
        public void LuuDapAn(string listCH)
        {
            var option = new JavaScriptSerializer().Deserialize<List<Da_SVLuaChon>>(listCH);

            var danhGia = (DanhGia)Session["lambai"];

            foreach (var item in danhGia.ketQuaThi1.CauHoiDeThis)
            {
                foreach (var item1 in item.Kho_CauHoi.Dap_AN)
                {
                    if (option.Exists(x => x.Ma_DAN == item1.MA_DAN))
                    {
                        item1.TrangThai = true;
                    }
                    else
                    {
                        item1.TrangThai = false;
                    }
                }

            }
            danhGia.ketQuaThi1.Da_SVLuaChon = option;
            Session["lambai"] = danhGia;
        }
        public JsonResult kiemTrade()
        {
            if (Session["lambai"] == null)
            {
                return Json(new { startust = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { startust = true }, JsonRequestBehavior.AllowGet);
        }

        public void HuyDe()
        {
            Session["lambai"] = null;
        }
        public ActionResult DanhGia()
        {
            var session = (TaiKhoan)Session[ComMonStants.UserLogin];
            LopHocPhan lopHocPhan = (LopHocPhan)Session["LopHP"];
            return View(new TracNghiemOnlineDB().Chuong_Hoc.Where(x => x.TrangThai == 1 && x.Ma_Mon==lopHocPhan.MaMon).ToList());
        }
        public ActionResult KetQuathi()
        {
            try {

                var danhGia = (DanhGia)Session["lambai"];
                if (Session["lambai"] == null)
                {
                  return  RedirectToAction("OnTap");
                }

                int a = (int)Session["a"];
                var session = (TaiKhoan)Session[ComMonStants.UserLogin];
                new TaoDeDao().Mark(danhGia, a);
                Session["a"] = (int)0;
                Session["lambai"] = danhGia;
                return View(danhGia);

            } catch { }

            return RedirectToAction("OnTap");

        }
        public JsonResult ThongKe(int mabai)
        {
            LopHocPhan lopHocPhan = (LopHocPhan)Session["LopHP"];
            string startut = "";
            TaiKhoan tk = (TaiKhoan)Session[ComMonStants.UserLogin];
            List<De_Thi> deThis = new List<De_Thi>();
            foreach (var item in new TracNghiemOnlineDB().De_Thi.Where(x => x.Ma_SV.Equals(tk.TaiKhoan1)&&x.MaMon==lopHocPhan.MaMon).ToList())
            {
                if (new TracNghiemOnlineDB().Danh_Gia.Where(x => x.MaChuong == mabai).ToList().Exists(x => x.MaDeThi == item.MaDeThi))
                {
                    deThis.Add(item);
                }

            }

            if (deThis.Count == 0)
            {
                return Json(new
                {
                    arr = new int[0],
                    startut
                }, JsonRequestBehavior.AllowGet);
            }


            List<Danh_Gia> danhGias = new List<Danh_Gia>();

            DateTime dateTime = DateTime.Now;
            try
            {
                dateTime = deThis.Where(x =>x.Ma_SV.Equals(tk.TaiKhoan1) && x.MaMon == lopHocPhan.MaMon).Last().NgayThi.Value;
            }
            catch { }
            double[] DTB = new double[4];

            for (int i = 0; i < 3; i++)
            {
                List<Danh_Gia> danhGias1 = new List<Danh_Gia>();
                DateTime dateTime1 = dateTime.AddDays(-3);
                var dethi = deThis.Where(x => x.NgayThi <= dateTime && x.NgayThi > dateTime1);
                var decuoi = dethi.ToList().First();

                foreach (var item in dethi)
                {
                    var danhgia = new TracNghiemOnlineDB().Danh_Gia.SingleOrDefault(x => x.MaDeThi == item.MaDeThi && x.MaChuong == mabai);
                    if (danhgia != null)
                    {

                        if (!danhGias.Exists(x => x.MaDeThi == item.MaDeThi))
                        {
                            danhGias.Add(danhgia);
                        }
                        danhGias1.Add(danhgia);
                    }
                }
                double dtb = 0; ;
                foreach (var item in danhGias1)
                {
                    dtb += item.Diem.Value;
                }
                try
                {


                    dtb = dtb / (double)danhGias1.Count;
                    DTB[i] = dtb;

                }
                catch { dtb = 0; }
                try
                {
                    dateTime = deThis.Where(x => x.NgayThi.Value < decuoi.NgayThi.Value).ToList().Last().NgayThi.Value;
                }
                catch
                {
                    break;
                }

            }
            double NX1 = (DTB[0] + DTB[1] + DTB[2]) / (double)3;



            if (DTB[0] > DTB[1] && DTB[1] >= DTB[2])
            {
                startut = "Có sự tiến bộ ổn định trong thời gian qua.";
            }

            else if (DTB[0] < DTB[1] && DTB[1] <= DTB[2])
            {
                startut = "Bạn không có sự tiến bộ trong thời gian qua. Kết quả" +
  "các bài kiếm tra có chứa nội dung này đang giảm .";
            }
            else if (DTB[0] <= DTB[1] && DTB[1] >= DTB[2])
            {
                startut = " Trong thời gian gần đây bạn không có tiến bộ. Kết quả các bài kiểm tra có chứa nội dung này giảm xuống.";
            }
            else if (DTB[0] > DTB[1] && DTB[1] <= DTB[2])
            {
                startut = " Bạn có sự tiến bộ hơn trong thời gian trước.";
            }


            if (NX1 < 5)
            {
                startut += "Kiến thức phần này của bạn còn rất hạn chế điểm phần này bài test còn chưa cao.Bạn cần cố gắng cải thiện hơn nữa";
            }
            else if (NX1 >= 5 && NX1 < 7)
            {

                startut += "Kiến thức của bạn ở phần này chỉ ở mức trung bình. Bạn cần cố gắng hơn để cải thiện thành tích của mình";
            }

            else if (NX1 >= 7 && NX1 < 8.5)
            {
                startut += "Kiến thức của bạn ở phần này khá tốt. Bạn cố gắng thêm để đặt được số điểm cao hơn nữa";
            }
            else if (NX1 >= 8.5)
            {
                startut += "Kiến thức của bạn ở phần bạn rất làm rất tốt. Bạn cố gắng duy trì phong độ nhé";
            }



            var arr = from c in danhGias.ToList().OrderBy(x => x.MaDeThi)
                      select new
                      {
                          Ma_De=c.MaDeThi,
                          Diem=c.Diem

                      };

            return Json(new
            {
                arr,
                startut
            }, JsonRequestBehavior.AllowGet);
        }


    }
}