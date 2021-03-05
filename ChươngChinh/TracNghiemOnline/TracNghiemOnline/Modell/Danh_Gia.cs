namespace TracNghiemOnline.Modell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Danh_Gia
    {
        [Key]
        public long MaDG { get; set; }

        public long? MaDeThi { get; set; }

        public long? MaChuong { get; set; }

        public double SoCauDung { get; set; }

        public double TongCau { get; set; }

        [Column(TypeName = "text")]
        public string NhanXet { get; set; }

        [StringLength(20)]
        public string DanhGia { get; set; }

        public virtual Chuong_Hoc Chuong_Hoc { get; set; }

        public virtual De_Thi De_Thi { get; set; }
    }
}
