namespace GoogleDrive.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SoHuu")]
    public partial class SoHuu
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TenUser { get; set; }

        [StringLength(50)]
        public string Idbaihat { get; set; }
    }
}
