namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductSizeColor")]
    public partial class ProductSizeColor
    {
        [Key]
        [Column(Order = 0)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProductID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string ColorID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(3)]
        public string SizeID { get; set; }

        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
