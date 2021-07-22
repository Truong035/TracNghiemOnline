using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemOnline.Modell.Dao
{
    public class DanhGia1
    {
        public long? MaChuong { get; set; }
        public double SoCauDung { get; set; }
        public double TongCau { get; set; }
        public string[] NhanXet { get; set; }
        public int DanhGia { get; set; }
    }
}