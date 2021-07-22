using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TracNghiemOnline.Modell;

namespace TracNghiemOnline.Model
{
    public class DanhGia
    {
     public  List<SoLuongChuong> DanhGiaMucDo{ get; set; }
     
        public List<NoiDungThi> DanhGiaMucDo1 { get; set; }
        public KetQuaThi ketQuaThi { get; set; }
        public De_Thi ketQuaThi1 { get; set; }

    }
}