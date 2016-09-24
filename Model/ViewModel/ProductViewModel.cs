using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ProductDetailViewModel
    {
        public ProductDetailGeneral ProductGeneral { get; set; }
        public List<SizeColorQuantity> SizeColorQuantities { get; set; }
    }

    public class ProductDetailGeneral
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public string MoreImages { get; set; }
        public List<Image> ListImage{ get; set; }
    }
    public class TempSizeColorQuantity
    {
        public string ColorID { get; set; }
        public string SizeID { get; set; }
        public int Quantity { get; set; }
    }

    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Url { get; set; }
    }
    public class SizeColorQuantity
    {
        public string ColorId { get; set; }
        public List<SizeAndQuantity> SizeAndQuantities { get; set; }
    }
    public class SizeAndQuantity
    {
        public string SizeId { get; set; }
        public int Quantity { get; set; }
    }

    // 
    public class ProductViewModel
    {
        public string ForCheckbox
        {
            get { return "<input type='checkbox' name='" + ID + "' value='" + ID + "'>"; }
        }
        public long ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? SumQuantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public string DateDisplay { get { return CreatedDate.Date.ToString("dd/MM/yyyy"); } }
        public int Status { get; set; }
        public string DisplayStatus
        {
            get
            {
                if(Status == 0)
                    return "<span class='label label-sm label-default'> Not Published </span>";
                else if (Status == 1)
                    return "<span class='label label-sm label-default'> Published </span>"; 
                else
                    return "<span class='label label-sm label-default'> Delected </span>";
            }
        }
        public string ForAction
        {
            get { return "<a href = '?p=ecommerce_products_edit' class='btn btn-sm btn-default btn-circle btn-editable'><i class='fa fa-pencil'></i> Edit</a>"; }

        }
    }

    public class ProductFilterViewModel
    {
        
        public long ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public decimal? PromotionPriceFrom { get; set; }
        public decimal? PromotionPriceTo { get; set; }
        public int? SumQuantityFrom { get; set; }
        public int? SumQuantityTo { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDateFrom { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDateTo { get; set; }
        public int? Status { get; set; }
    }

    public class SlideViewModel
    {
        public string ForCheckbox
        {
            get { return "<input type='checkbox' name='" + ID + "' value='" + ID + "'>"; }
        }
        public int ID { get; set; }
        public string Title { get; set; }

        public string Image { get; set; }
        public string DisplayImage
        {
            get
            {
                if (Image == null)
                    return "<img src='https://cdn.vhx.tv/assets/thumbnails/default-large.png' width='300'></img>";
                else
                    return "<img src='" + Image + "' width='300'></img>";
            }
        }
        public int DisplayOrder { get; set; }
        public int Status { get; set; }
        public string DisplayStatus
        {
            get
            {
                if (Status == 0)
                    return "<span class='label label-sm label-default'> Not Published </span>";
                else if (Status == 1)
                    return "<span class='label label-sm label-default'> Published </span>";
                else
                    return "<span class='label label-sm label-default'> Delected </span>";
            }
        }
        public string ForAction
        {
            get { return "<a href = '/Admin/Master/SlideDetail/" + ID + "' class='btn btn-sm btn-default btn-circle btn-editable'><i class='fa fa-binoculars'></i> Preview</a><a href = '/Admin/Master/EditSlide/" + ID + "' class='btn btn-sm btn-default btn-circle btn-editable'><i class='fa fa-pencil'></i> Edit</a>"; }

        }
    }
    public class SimpleProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string MetaTitle { get; set; }
        public decimal? PromotionPrice { get; set; }
        public List<string> MoreImages { get; set; }
        public string ShortDescription { get; set; }
    }
}
