namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductColor")]
    public partial class ProductColor
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(10)]
        public string ColorName { get; set; }

        [StringLength(10)]
        public string RGBHex { get; set; }

        public bool? Status { get; set; }
    }
}
