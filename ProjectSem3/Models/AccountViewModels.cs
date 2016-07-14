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
            [Required]
            public string Email { get; set; }

            [StringLength(25)]
            [Required]
            public string Firstname { get; set; }

            [StringLength(25)]
            [Required]
            public string Lastname { get; set; }

            [Required]
            public int Gender { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime DOB { get; set; }

            [StringLength(50)]
            [Required]
            public string Address { get; set; }

            [Required]
            [StringLength(50)]
            public string Password { get; set; }

            [StringLength(20)]
            [Required]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(20)]
            public string Country { get; set; }

            [StringLength(20)]
            [Required]
            public string City { get; set; }

            [StringLength(8)]
            [Required]
            public string PostCode { get; set; }

            [StringLength(50)]
            [Required]
            public string Phone { get; set; }
        }
    }
}