namespace TracNghiemOnline.Modell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DS_MonHoc
    {
        public long Ma_Mon { get; set; }

        public long Ma_Nganh { get; set; }

        [Key]
        public long MADS { get; set; }

        public virtual MonHoc MonHoc { get; set; }

        public virtual Nganh Nganh { get; set; }
    }
}
