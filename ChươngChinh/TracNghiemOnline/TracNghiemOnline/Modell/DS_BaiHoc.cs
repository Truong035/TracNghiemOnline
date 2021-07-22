namespace TracNghiemOnline.Modell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DS_BaiHoc
    {
        [Key]
        public long Ma_CT { get; set; }

        public long? Ma_Bai { get; set; }

        [StringLength(10)]
        public string MaSV { get; set; }

        [StringLength(500)]
        public string ListCauHoi { get; set; }

        public int? SoCauDung { get; set; }

        public int? SoCauSai { get; set; }

        public virtual Chuong_Hoc Chuong_Hoc { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
