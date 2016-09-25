using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectSem3.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public ProductGeneral ProductGeneral { get; set; }
        public List<SizeColorQuantityViewModel> SizeColorQuantities { get; set; }
        public IList<Image> ProductImages { get; set; }
    }
    public class ProductGeneral
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public string ShortDescription { get; set; }
        public string MetaTitle { get; set; }

        public ProductCategory Category { get; set; }
        [Required]
        public string SKU { get; set; }
        public int? ProductType { get; set; }
        [Required]
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        [Required]
        public int Status { get; set; }
    }
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Order { get; set; }
        public string Url { get; set; }
    }

    public class ProductCategoryViewModel
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public long? ParentID { get; set; }
        public bool IsSelected { get; set; }
    }
    public class SizeColorQuantityViewModel
    {
        public string ColorId { get; set; }
        public List<SizeAndQuantity> SizeAndQuantities { get; set; }
    }
    public class SizeAndQuantity
    {
        public string SizeId { get; set; }
        public int Quantity { get; set; }
    }
}