namespace TracNghiemOnline.Modell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopHocPhan")]
    public partial class LopHocPhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopHocPhan()
        {
            DS_LopHP = new HashSet<DS_LopHP>();
        }

        [Key]
        [StringLength(10)]
        public string MaLop { get; set; }

        public string TenLop { get; set; }

        public long? MaGV { get; set; }

        [StringLength(10)]
        public string SiSo { get; set; }

        public long? MaMon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianHoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianKetThuc { get; set; }

        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DS_LopHP> DS_LopHP { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        public virtual MonHoc MonHoc { get; set; }
    }
}
