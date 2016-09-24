namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipping")]
    public partial class Shipping
    {
        public long ID { get; set; }

        [StringLength(25)]
        public string Firstname { get; set; }

        [StringLength(25)]
        public string Lastname { get; set; }

        public int? Gender { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(20)]
        public string District { get; set; }

        [StringLength(8)]
        public string PostCode { get; set; }

        public string PhoneNumber { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public string OrderNote { get; set; }

        [StringLength(128)]
        public string AccountID { get; set; }

        public int ShippingMethod { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
