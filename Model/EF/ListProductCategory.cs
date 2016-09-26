namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListProductCategory")]
    public partial class ListProductCategory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CategoryID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? Status { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
