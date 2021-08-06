using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TracNghiemOnline.Modell.Dao
{
    public class Bode
    {

        TracNghiemOnlineDB db = new TracNghiemOnlineDB();
        public List<Bo_De> ListALLChapterBM(string mabm)
        {

            var bode = db.Bo_De.Where( x=>x.PheDuyet.Contains("Đang")  && x.NguoiDuyet.Trim().Equals(mabm)).ToList();
         
            return bode;
        }
        public void themde(Bo_De bo_De1)
        {
            Bo_De bo_De = new Bo_De();
            bo_De.NoiDung = bo_De1.NoiDung;
            bo_De.ThoiGianThi = bo_De1.ThoiGianThi;
            bo_De.Ma_Mon = bo_De1.Ma_Mon;
            bo_De.Ma_NguoiTao = bo_De1.Ma_NguoiTao;
            bo_De.PheDuyet = "Đã phê duyệt";
            bo_De.NguoiDuyet = bo_De1.Ma_NguoiTao;
            bo_De.TrangThai = true;
            bo_De.Xoa = true;
            foreach (var item in bo_De1.CauHois)
            {
                item.Kho_CauHoi = null;
                bo_De.CauHois.Add(item);
            }
            bo_De.SoCau = bo_De.CauHois.Count;
            try
            {
                db = new TracNghiemOnlineDB();
                db.Bo_De.Add(bo_De);
                db.SaveChanges();

            }
            catch (Exception e)
            {
              
            }

        }

        public List<Kho_CauHoi> listkhocauhoi(long mabd)
        {

            var cauhoi = db.CauHois.Where(x => x.Ma_BoDe == mabd).ToList();
            List<Kho_CauHoi> khoch = new List<Kho_CauHoi>();
            var khocauhoi = db.Kho_CauHoi.Select(x => x).ToList();
            var dapan = db.Dap_AN.Select(x => x).ToList();

            
            foreach (var a in cauhoi)
            {
                Kho_CauHoi ch = new Kho_CauHoi();
                foreach (var b in khocauhoi)
                {
                    
                    
                    foreach(var c in dapan)
                    {
                        if(a.Ma_CauHoi==b.Ma_CauHoi && b.Ma_CauHoi == c.Ma_CauHoi)
                        {
                            Dap_AN da = new Dap_AN();
                            ch.NoiDung = b.NoiDung;
                            ch.HinhAnh = b.HinhAnh;
                            ch.MucDo = b.MucDo;
                            ch.Ma_Chuong = b.Ma_Chuong;
                            ch.TrangThai = b.TrangThai;
                            da.NoiDung = c.NoiDung;
                            da.TrangThai = c.TrangThai;
                            da.Ma_CauHoi = c.Ma_CauHoi;
                            da.MA_DAN = c.MA_DAN;
                            da.HinhAnh = c.HinhAnh;
                            ch.Dap_AN.Add(da);

                        }
                    }
                    
                }
                
                khoch.Add(ch);
            }
                

            return khoch;
        }
     
        internal object danhsachgiaovienbm(string id)
        {
            var giaovien = db.GiaoViens.Where(x => x.MaBoMon.Equals(id)).ToList();
            return giaovien;


        }
        internal object ClassRom(string MAlOP)
        {
            var Lop = db.LopHocPhans.Find(MAlOP);
            Lop.DS_LopHP = new List<DS_LopHP>();
            Lop.DS_LopHP = db.DS_LopHP.Where(X => X.Ma_LOP.Equals(MAlOP)).ToList();

            foreach (var item in Lop.DS_LopHP)
            {
                item.SinhVien = db.SinhViens.Find(item.MA_SV);
                item.SinhVien.Lop = db.Lops.Find(item.SinhVien.Ma_Lop);
            }

            return Lop;
        }

        

    }
}