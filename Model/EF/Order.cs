namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long ID { get; set; }
        public int? PaymentType { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string CustomerID { get; set; }

        [StringLength(25)]
        public string ShipFirstname { get; set; }

        [StringLength(25)]
        public string ShipLastname { get; set; }

        public int? ShipGender { get; set; }

        [StringLength(50)]
        public string ShipMobile { get; set; }
        [StringLength(20)]
        public string ShipCountry { get; set; }
        [StringLength(20)]
        public string ShipState { get; set; }
        [StringLength(20)]
        public string ShipCity { get; set; }

        [StringLength(20)]
        public string ShipDistrict { get; set; }

        [StringLength(50)]
        public string ShipAddress { get; set; }

        [StringLength(50)]
        public string ShipEmail { get; set; }

        [StringLength(8)]
        public string ShipPostCode { get; set; }

        public string ShipNote { get; set; }

        public int? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
