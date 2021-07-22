using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TracNghiemOnline.Model;

namespace TracNghiemOnline.Modell.Dao
{
    public class TaoDeDao
    {
        internal void CreateTopic(De_Thi bo_De1, long mabai, TaiKhoan tk, LopHocPhan lopHocPhan)
        {
            bo_De1.CauHoiDeThis = new List<CauHoiDeThi>();
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            var danhgia = db.DS_BaiHoc.SingleOrDefault(x => x.Ma_Bai == mabai && x.MaSV.Equals(tk.TaiKhoan1));
            string[] ListCH = danhgia.ListCauHoi.Split('/');
            if ((ListCH.Length) == 40)
            {
                danhgia.SoCauDung = 0;
                danhgia.SoCauSai = 0;
                danhgia.ListCauHoi = "";
                ListCH = danhgia.ListCauHoi.Split('/');
                db.SaveChanges();
            }

            else if (danhgia.SoCauSai - danhgia.SoCauDung > 30 && danhgia.SoCauSai + danhgia.SoCauDung > 55)
            {
                danhgia.SoCauDung = 0;
                danhgia.SoCauSai = 0;
                danhgia.ListCauHoi = "";
                ListCH = danhgia.ListCauHoi.Split('/');
                db.SaveChanges();

            }
    
            Random(bo_De1, mabai, 2, "Nhận Biết", ListCH,  lopHocPhan);
            Random(bo_De1, mabai, 2, "Thông Hiểu", ListCH , lopHocPhan);
            Random(bo_De1, mabai, 1, "Vận Dụng", ListCH ,  lopHocPhan);
            Random(bo_De1, mabai, 1, "Vận Dụng Cao", ListCH, lopHocPhan);

        }
        private void Random(De_Thi De1, long mabai, int sl, string v, string[] ListCH, LopHocPhan lopHocPhan)
        {
            List<Kho_CauHoi> kho_CauHois = Nuberofquestion(mabai, v,lopHocPhan);

            Random random = new Random();
            if (kho_CauHois.Count > 0)
            {
                for (int i = 0; i < sl; i++)
                {
                    while (true)
                    {
                        int dem = 0;
                        int vt = random.Next(kho_CauHois.Count);
                        try
                        {
                        }
                        catch
                        {
                            for (int j = 0; j < ListCH.Length - 1; j++)
                            {
                                if (kho_CauHois[vt].Ma_CauHoi == long.Parse(ListCH[j]))
                                {
                                    dem++;
                                    break;
                                }
                            }
                        }

                        if (dem == 0)
                        {
                            CauHoiDeThi cauHoi = new CauHoiDeThi();
                            cauHoi.MaDeThi = De1.MaDeThi;
                            cauHoi.MaCauHoi = kho_CauHois[vt].Ma_CauHoi;
                            cauHoi.Kho_CauHoi = kho_CauHois[vt];
                            De1.CauHoiDeThis.Add(cauHoi);
                            kho_CauHois.RemoveAt(vt);
                            break;
                        }
                        kho_CauHois.RemoveAt(vt);

                    }

                }
            }

        }
        internal void TaoDe(DanhGia da, int sl, int mucdo, LopHocPhan lopHocPhan)
        {
            De_Thi deThi = new De_Thi();
            foreach (var item in da.DanhGiaMucDo1)
            {
                item.SoCau = sl / da.DanhGiaMucDo1.Count;
            }
            for (int i = 0; i < sl % da.DanhGiaMucDo1.Count; i++)
            {
                da.DanhGiaMucDo1[i].SoCau++;


            }
            foreach (var item in da.DanhGiaMucDo1)
            {
                if (mucdo == 1)
                {
                    LuuDe(deThi, item, 1, 0, lopHocPhan);
                }
                if (mucdo == 2)
                {
                    LuuDe(deThi, item, 2, 1, lopHocPhan);
                }
                if (mucdo == 3)
                {
                    LuuDe(deThi, item, 3, 2, lopHocPhan);
                }
                if (mucdo == 4)
                {
                    LuuDe(deThi, item, 3, 4, lopHocPhan);
                }
            }
            foreach (var item1 in da.DanhGiaMucDo1)
            {
                item1.noidung.Kho_CauHoi = new List<Kho_CauHoi>();
                foreach (var item in deThi.CauHoiDeThis)
                {
                    if (item.Kho_CauHoi.Ma_Chuong == item1.noidung.Ma_Chuong)
                    {
                        item1.noidung.Kho_CauHoi.Add(item.Kho_CauHoi);
                    }
                }

            }
            da.ketQuaThi1 = deThi;
        }

        internal List<Kho_CauHoi> Nuberofquestion(long ma_Chuong, string v, LopHocPhan lopHocPhan)
        {
            List<Kho_CauHoi> kho_CauHois = new TracNghiemOnlineDB().Kho_CauHoi.Where(x => x.Ma_Chuong == ma_Chuong && x.MucDo.Equals(v)&&(x.NguoiTao.Equals(lopHocPhan.MaGV)||x.TrangThai==false)&& x.Xoa==true).ToList();
        
            return kho_CauHois;
        }
        private void LuuDe(De_Thi deThi, NoiDungThi noiDungThi, int max, int min, LopHocPhan lopHocPhan)
        {
            for (int i = min; i < max; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if (j == 0) { Random(deThi, (long)noiDungThi.noidung.Ma_Chuong, noiDungThi.BanMucDo()[i, j], "Nhận Biết", null, lopHocPhan); }
                    if (j == 1) { Random(deThi, (long)noiDungThi.noidung.Ma_Chuong, noiDungThi.BanMucDo()[i, j], "Thông Hiểu", null, lopHocPhan); }
                    if (j == 2) { Random(deThi, (long)noiDungThi.noidung.Ma_Chuong, noiDungThi.BanMucDo()[i, j], "Vận Dụng", null, lopHocPhan); }
                    if (j == 3) { Random(deThi, (long)noiDungThi.noidung.Ma_Chuong, noiDungThi.BanMucDo()[i, j], "Vận Dụng Cao", null, lopHocPhan); }

                }

            }
        }


        public void Mark(DanhGia exam, int a)
        {
            TracNghiemOnlineDB db = new TracNghiemOnlineDB();
            // exam.Da_SVLuaChon = db.Da_SVLuaChon.Where(x => x.MaDeThi == exam.MaDeThi).ToList();
            int socauDung = 0;
            var kho_CauHoi2 = new List<Kho_CauHoi>();
            var kho_CauHoi1 = new List<Kho_CauHoi>();
            var noiDungThis = new List<NoiDungThi>();
            foreach (var item in exam.ketQuaThi1.CauHoiDeThis)
            {
                var khocauhoi = db.Kho_CauHoi.Find(item.Kho_CauHoi.Ma_CauHoi);
                item.Kho_CauHoi = khocauhoi;
                kho_CauHoi2.Add(khocauhoi);
                foreach (var item1 in khocauhoi.Dap_AN)
                {
                    if (exam.ketQuaThi1.Da_SVLuaChon.ToList().Exists(x => x.Ma_DAN == item1.MA_DAN && item1.TrangThai == true))
                    {
                        socauDung++;
                        kho_CauHoi1.Add(khocauhoi);
                    }

                }

            }
            // Lay Ra So Cau sv da lam dung cua moi chuong
            foreach (var item0 in exam.DanhGiaMucDo1)
            {
                noiDungThis.Add(item0);

                item0.noidung.Kho_CauHoi = kho_CauHoi1.Where(x => x.Ma_Chuong == item0.noidung.Ma_Chuong).ToList();

            }
            DanhGia danhGia = new DanhGia();
            //danhGia.DanhGiaMucDo = new List<SoLuongChuong>();
            //danhGia.ketQuaThi = new KetQuaThi();
            exam.ketQuaThi1.Danh_Gia = new List<Modell.Danh_Gia>();
            for (int i = 0; i < exam.DanhGiaMucDo1.Count; i++)
            {
                db = new TracNghiemOnlineDB();
                double a1 = (double)(kho_CauHoi1.Where(X => X.MucDo.Equals("Nhận Biết") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) * (double)1;
                double a2 = (double)(kho_CauHoi1.Where(X => X.MucDo.Equals("Thông Hiểu") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) * (double)2;
                double a3 = (double)(kho_CauHoi1.Where(X => X.MucDo.Equals("Vận Dụng") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) * (double)3;
                double a4 = (double)(kho_CauHoi1.Where(X => X.MucDo.Equals("Vận Dụng Cao") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) * (double)4;

               


                exam.DanhGiaMucDo1[i].nhanbiet = (kho_CauHoi1.Where(X => X.MucDo.Equals("Nhận Biết") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) + "/" + (kho_CauHoi2.Where(X => X.MucDo.Equals("Nhận Biết") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count);
                exam.DanhGiaMucDo1[i].Thonghieu = (kho_CauHoi1.Where(X => X.MucDo.Equals("Thông Hiểu") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) + "/" + (kho_CauHoi2.Where(X => X.MucDo.Equals("Thông Hiểu") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count);
                exam.DanhGiaMucDo1[i].vandung = (kho_CauHoi1.Where(X => X.MucDo.Equals("Vận Dụng") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) + "/" + (kho_CauHoi2.Where(X => X.MucDo.Equals("Vận Dụng") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count);
                exam.DanhGiaMucDo1[i].vandungcao = (kho_CauHoi1.Where(X => X.MucDo.Equals("Vận Dụng Cao") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) + "/" + (kho_CauHoi2.Where(X => X.MucDo.Equals("Vận Dụng Cao") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count);

                double b1 = (double)(kho_CauHoi2.Where(X => X.MucDo.Equals("Nhận Biết") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) * (double)1;
                double b2 = (double)(kho_CauHoi2.Where(X => X.MucDo.Equals("Thông Hiểu") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) * (double)2;
                double b3 = (double)(kho_CauHoi2.Where(X => X.MucDo.Equals("Vận Dụng") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) * (double)3;
                double b4 = (double)(kho_CauHoi2.Where(X => X.MucDo.Equals("Vận Dụng Cao") && X.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) * (double)4;



                double DG = 0;
                double A = a1 + a2 + a3 + a4;
                double b = b1 + b2 + b3 + b4;
                DG = (double)(A / b) * 10;
                double tile = 0;

                tile = (double)((double)(kho_CauHoi1.Where(x => x.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) / (double)(kho_CauHoi2.Where(x => x.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) * (double)100);

                Danh_Gia  danhGia1 = new Danh_Gia();
                danhGia1.Diem = DG;
                danhGia1.MaChuong = exam.DanhGiaMucDo1[i].noidung.Ma_Chuong;
                exam.ketQuaThi1.Danh_Gia.Add(danhGia1);
                tile = Math.Round(tile, 3);
                exam.DanhGiaMucDo1[i].danh_Gia = new DanhGia1();
                exam.DanhGiaMucDo1[i].danh_Gia.NhanXet = new string[100];
                exam.DanhGiaMucDo1[i].danh_Gia.SoCauDung = (kho_CauHoi1.Where(x => x.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count);
                exam.DanhGiaMucDo1[i].danh_Gia.TongCau = kho_CauHoi2.Where(x => x.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count;

                exam.DanhGiaMucDo1[i].danh_Gia.NhanXet[0] = "Bạn làm đúng (" + (kho_CauHoi1.Where(x => x.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count) + "/" + kho_CauHoi2.Where(x => x.Ma_Chuong == exam.DanhGiaMucDo1[i].noidung.Ma_Chuong).ToList().Count + " đạt tỉ lệ " + tile + " %) \n";
                if (DG < 5)
                {
                    exam.DanhGiaMucDo1[i].danh_Gia.DanhGia = 1;

                    exam.DanhGiaMucDo1[i].danh_Gia.NhanXet[1] = "-Kiến thức phần này của bạn còn rất hạn chế điểm phần này bài test còn chưa cao.Bạn cần cố gắng cải thiện hơn nữa";
                }
                else if (DG >= 5 && DG < 7)
                {
                    exam.DanhGiaMucDo1[i].danh_Gia.DanhGia = 2;
                    exam.DanhGiaMucDo1[i].danh_Gia.NhanXet[1] = "Kiến thức của bạn ở phần này chỉ ở mức trung bình. Bạn cần cố gắng hơn để cải thiện thành tích của mình";
                }

                else if (DG >= 7 && DG < 8.5)
                {
                    exam.DanhGiaMucDo1[i].danh_Gia.DanhGia = 3;
                    exam.DanhGiaMucDo1[i].danh_Gia.NhanXet[1] = "Kiến thức của bạn ở phần này khá tốt. Bạn cố gắng thêm để đặt được số điểm cao hơn nữa";
                }
                else if (DG >= 8.5)
                {
                    exam.DanhGiaMucDo1[i].danh_Gia.DanhGia = 4;
                    exam.DanhGiaMucDo1[i].danh_Gia.NhanXet[1] = "Kiến thức của bạn ở phần bạn rất làm rất tốt. Bạn cố gắng duy trì phong độ nhé";
                }


            }

            db = new TracNghiemOnlineDB();

            double Hediem = (double)((double)10 / (double)(exam.ketQuaThi1.CauHoiDeThis.Count));

            exam.ketQuaThi1.DiêmSo = Math.Round((double)((double)(socauDung) * (double)(Hediem)), 3);
            if (a == 1)
            {
                De_Thi deThi = new De_Thi();
                deThi.Ma_SV = exam.ketQuaThi1.Ma_SV;
                deThi.NgayThi = exam.ketQuaThi1.NgayThi;
                deThi.DiêmSo = Math.Round((double)((double)(socauDung) * (double)(Hediem)), 3);
                deThi.ThoiGianThi = exam.ketQuaThi1.ThoiGianThi;
                deThi.MaMon = exam.ketQuaThi1.MaMon;
                db.De_Thi.Add(deThi);
                db.SaveChanges();
                deThi.MaDeThi = db.De_Thi.Where(x => x.Ma_SV.Equals(deThi.Ma_SV)).ToList().Last().MaDeThi;
                int i = 0;
                foreach (var item in exam.ketQuaThi1.Danh_Gia)
                {
                    Danh_Gia danhGia1 = new  Danh_Gia();
                    danhGia1.Diem = item.Diem;
                    danhGia1.MaDeThi= deThi.MaDeThi;
                    danhGia1.MaChuong = item.MaChuong;
                    danhGia1.TongCau = exam.DanhGiaMucDo1[i].danh_Gia.SoCauDung;
                    danhGia1.SoCauDung = exam.DanhGiaMucDo1[i].danh_Gia.TongCau;
                    db.Danh_Gia.Add(danhGia1);
                    i++;
                    db.SaveChanges();

                }

                foreach (var item in exam.ketQuaThi1.CauHoiDeThis)
                {
                    CauHoiDeThi cau_Hoi = new CauHoiDeThi();
                    cau_Hoi.MaDeThi = deThi.MaDeThi;
                    cau_Hoi.MaCauHoi = item.MaCauHoi;
                    db.CauHoiDeThis.Add(cau_Hoi);
                    db.SaveChanges();
                }
                foreach (var item in exam.ketQuaThi1.Da_SVLuaChon)
                {
                  Da_SVLuaChon da_Lua = new Da_SVLuaChon();
                    da_Lua.MaDeThi = deThi.MaDeThi;
                    da_Lua.Ma_DAN = item.Ma_DAN;
                    db.Da_SVLuaChon.Add(da_Lua);
                    db.SaveChanges();
                }


            }


        }

    }
}