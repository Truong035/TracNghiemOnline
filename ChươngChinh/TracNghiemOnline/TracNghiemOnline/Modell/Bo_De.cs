namespace TracNghiemOnline.Modell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bo_De
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bo_De()
        {
            CauHois = new HashSet<CauHoi>();
            De_Thi = new HashSet<De_Thi>();
            Phong_Thi = new HashSet<Phong_Thi>();
        }

        [Key]
        public long Ma_BoDe { get; set; }

        [Column(TypeName = "text")]
        public string NoiDung { get; set; }

        public long? Ma_NguoiTao { get; set; }

        public bool TrangThai { get; set; }

        public long? Ma_Mon { get; set; }

        public int? SoCau { get; set; }

        [StringLength(20)]
        public string ThoiGianThi { get; set; }

        public bool Xoa { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        public virtual MonHoc MonHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauHoi> CauHois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<De_Thi> De_Thi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phong_Thi> Phong_Thi { get; set; }
    }
}
