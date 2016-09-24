namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductSize")]
    public partial class ProductSize
    {
        [StringLength(3)]
        public string ID { get; set; }

        [StringLength(3)]
        public string SizeName { get; set; }

        public int? Order { get; set; }

        public bool? Status { get; set; }
    }
}
