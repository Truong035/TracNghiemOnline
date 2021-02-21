namespace TracNghiemOnline.Modell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [Column("TaiKhoan")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TaiKhoan1 { get; set; }

        [StringLength(10)]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string ChưcVu { get; set; }
    }
}
