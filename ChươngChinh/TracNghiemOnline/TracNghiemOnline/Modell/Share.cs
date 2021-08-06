namespace TracNghiemOnline.Modell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Share")]
    public partial class Share
    {
        public long id { get; set; }

        [StringLength(10)]
        public string MaGV { get; set; }

        public long? MA { get; set; }

        public long? Loai { get; set; }

        public DateTime? NgayDang { get; set; }
    }
}
