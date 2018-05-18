namespace GoogleDrive.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiHat")]
    public partial class BaiHat
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string IdDrive { get; set; }

        [StringLength(150)]
        public string TenBaiHat { get; set; }

        [StringLength(150)]
        public string Author { get; set; }
    }
}
