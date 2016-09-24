using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSem3.Models
{
    public class OrderPaypal
    {
        public double GrossTotal { get; set; }
        public int InvoiceNumber { get; set; }
        public string PaymentStatus { get; set; }
        public string PayerFirstName { get; set; }
        public double PaymentFee { get; set; }
        public string BusinessEmail { get; set; }
        public string PayerEmail { get; set; }
        public string TxToken { get; set; }
        public string PayerLastName { get; set; }
        public string ReceiverEmail { get; set; }
        public string ItemName { get; set; }
        public string Currency { get; set; }
        public string TransactionId { get; set; }
        public string SubscriberId { get; set; }
        public string Custom { get; set; }

        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Memo { get; set; }
    }
}