using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class OrderViewModel
    {
        public string ForCheckbox
        {
            get { return "<input type='checkbox' name='" + OrderID + "' value='" + OrderID + "'>"; }
        }
        public long OrderID { get; set; }
        [DataType(DataType.Date)]
        public DateTime PurchasedOn { get; set; }
        public string DisplayPurchasedOn { get { return PurchasedOn.Date.ToString("dd/MM/yyyy"); } }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Customer { get { return Firstname + " " + Lastname; } }
        public string ShipTo { get; set; }
        public string ShipEmail { get; set; }
        //public decimal? BasePrice { get; set; }
        //public decimal? PurchasedPrice { get; set; }
        public int PaymentType { get; set; }
        public string DisplayPaymentType
        {
            get
            {
                if (PaymentType == 1)
                    return "<span class='label label-sm label-default'> Normal </span>";
                else
                    return "<span class='label label-sm label-default'> Paypal </span>";

            }
        }
        public int Status { get; set; }
        public string DisplayStatus
        {
            get
            {
                if (Status == 0)
                    return "<span class='label label-sm label-default'> Ignore </span>";
                else if (Status == 1)
                    return "<span class='label label-sm label-default'> Waiting </span>";
                else if (Status == 2)
                    return "<span class='label label-sm label-default'> Sent </span>";
                else
                    return "<span class='label label-sm label-default'> Closed </span>";
            }
        }

        
        public string ForAction
        {
            get { return "<a href = '/Admin/Order/Detail/" + OrderID + "' class='btn btn-sm btn-default btn-circle btn-editable'><i class='fa fa-binoculars'></i> View </a>"; }

        }
    }

    public class OrderFilterViewModel
    {

        public long OrderID { get; set; }
        [DataType(DataType.Date)]
        public DateTime PurchasedOnFrom { get; set; }
        [DataType(DataType.Date)]
        public DateTime PurchasedOnTo { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ShipTo { get; set; }
        public string ShipEmail { get; set; }
        //public decimal? BasePriceFrom { get; set; }
        //public decimal? BasePriceTo { get; set; }
        //public decimal? PurchasedPriceFrom { get; set; }
        //public decimal? PurchasedPriceTo { get; set; }
        public int? PaymentType { get; set; }
        public int? Status { get; set; }
    }
}
