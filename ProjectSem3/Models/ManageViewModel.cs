using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSem3.Models
{
    public class ManageViewModel
    {
        public AccountViewModel AccountInfo { get; set; }
        public Shipping ShippingInfo { get; set; }
    }
}