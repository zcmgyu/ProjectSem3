using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSem3.Models
{
    [Serializable]

    public class CartItem
    {
        public Product Product { set; get; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { set; get; }
    }

    public class CartItemViewModel
    {
        public long ProductID { set; get; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { set; get; }
        public decimal? ActualPrice { get; set; }
    }
}