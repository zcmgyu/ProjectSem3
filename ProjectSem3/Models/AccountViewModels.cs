using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectSem3.Models
{
    public class AccountViewModels
    {
        public class LoginViewModel
        {
            [DisplayName("Email Address")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [DisplayName("Password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public class RegisterViewModel
        {
            [StringLength(50)]
            public string Email { get; set; }
            [StringLength(25)]
            public string Firstname { get; set; }
            [StringLength(25)]
            public string Lastname { get; set; }
            public int Gender { get; set; }
            public DateTime DOB { get; set; }
            [StringLength(50)]
            public string Address { get; set; }
            [StringLength(50)]
            public string Password { get; set; }
            [StringLength(20)]
            public string Country { get; set; }
            [StringLength(20)]
            public string City { get; set; }
            [StringLength(8)]
            public string PostCode { get; set; }

            [StringLength(50)]
            public string Phone { get; set; }

            public DateTime? CreatedDate { get; set; }

            [StringLength(50)]
            public string CreatedBy { get; set; }

            public DateTime? ModifiedDate { get; set; }

            [StringLength(50)]
            public string ModifiedBy { get; set; }

            public bool Status { get; set; }
        }
    }
}