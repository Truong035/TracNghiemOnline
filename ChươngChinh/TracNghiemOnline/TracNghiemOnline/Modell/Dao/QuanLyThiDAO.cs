using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace TracNghiemOnline.Modell.Dao
{
    public class QuanLyThiDAO
    {
        TracNghiemOnlineDB db = new TracNghiemOnlineDB();
        public KetQuaThi Mark(De_Thi exam)
        {
            exam.Da_SVLuaChon=db.Da_SVLuaChon.Where(x => x.MaDeThi == exam.MaDeThi).ToList();
            int socauDung = 0;
            foreach (var item in exam.CauHoiDeThis)
            {
                item.Kho_CauHoi = new CauHoiDao().Question(item.Kho_CauHoi.Ma_CauHoi);
                foreach (var item1 in item.Kho_CauHoi.Dap_AN)
                {
                    if(exam.Da_SVLuaChon.ToList().Exists(x=>x.Ma_DAN==item1.MA_DAN&& item1.TrangThai == true))
                    {
                        socauDung++;
                    }

                }

            }
            double Hediem = (double)((double)10/(double)(exam.CauHoiDeThis.Count));
       
            KetQuaThi ketQuaThi = new KetQuaThi();
            ketQuaThi.Ma_DeThi = exam.MaDeThi;
            ketQuaThi.NgayThi = DateTime.Now;
            ketQuaThi.SoCauDung = socauDung;
            ketQuaThi.SoCauSai = exam.Da_SVLuaChon.Count - socauDung;
            ketQuaThi.DiemSo =  Math.Round((double)((double)(socauDung)*(double)(Hediem)),3);
            db.KetQuaThis.Add(ketQuaThi);
            db.SaveChanges();

            ketQuaThi.De_Thi = exam;
            return ketQuaThi;

        }
        public Phong_Thi ExamitionRoom(string MaPhong)
        {
            return db.Phong_Thi.Find(MaPhong);
        }

        internal DS_SVThi Check(string maPhong, long taiKhoan1)
        {
            return db.DS_SVThi.SingleOrDefault(x => x.MaPhong == maPhong && x.Ma_SV == taiKhoan1);
        }

        internal De_Thi SeachForTheExam(Phong_Thi phong,long Masv)
        {
         var   DSSV  = db.DS_SVThi.SingleOrDefault(x=>x.MaPhong==phong.MaPhong && x.Ma_SV==Masv);
            De_Thi de_Thi = new De_Thi();
          
                de_Thi = db.De_Thi.Find(DSSV.MaDeThi);
                if (de_Thi != null)
                {
                    de_Thi.CauHoiDeThis = db.CauHoiDeThis.Where(x => x.MaDeThi == de_Thi.MaDeThi).ToList();
                    de_Thi.Da_SVLuaChon = db.Da_SVLuaChon.Where(x => x.MaDeThi == de_Thi.MaDeThi).ToList();

                    foreach (var item1 in de_Thi.CauHoiDeThis)
                    {
                        item1.Kho_CauHoi = new CauHoiDao().Question(long.Parse(item1.MaCauHoi.ToString()));
                        foreach (var item2 in item1.Kho_CauHoi.Dap_AN)
                        {
                            if (de_Thi.Da_SVLuaChon.ToList().Exists(x => x.Ma_DAN == item2.MA_DAN))
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
            
            return de_Thi;
        }
    }
}