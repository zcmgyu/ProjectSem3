using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Areas.Admin.Models
{
    public class FormMailViewModel
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public bool SendAll { get; set; }
        public string SendMailTo { get; set; }
    }
}