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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductColor()
        {
            ProductSizeColors = new HashSet<ProductSizeColor>();
        }

        public int ID { get; set; }

        [StringLength(10)]
        public string ColorName { get; set; }

        [StringLength(10)]
        public string RGBHex { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSizeColor> ProductSizeColors { get; set; }
    }
}
