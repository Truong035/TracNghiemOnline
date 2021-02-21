namespace TracNghiemOnline.Modell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DS_SVThi
    {
        public long Ma_SV { get; set; }

        [Required]
        [StringLength(10)]
        public string MaPhong { get; set; }

        [Key]
        public long MaDS { get; set; }

        public long? MaDeThi { get; set; }

        public virtual Phong_Thi Phong_Thi { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
