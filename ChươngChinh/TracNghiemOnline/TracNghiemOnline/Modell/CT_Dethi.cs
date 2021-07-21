namespace TracNghiemOnline.Modell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_Dethi
    {
        [Key]
        public long id { get; set; }

        public long? MADETHI { get; set; }

        [StringLength(200)]
        public string LYDO { get; set; }

        public virtual De_Thi De_Thi { get; set; }
    }
}
