﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectSem3.Areas.Admin.Models
{
    
    public class AccountViewModel
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
        [StringLength(20)]
        public string City { get; set; }

        [StringLength(20)]
        [Required]
        public string District { get; set; }

        [StringLength(8)]
        [Required]
        public string PostCode { get; set; }

        [StringLength(50)]
        [Required]
        public string PhoneNumber { get; set; }
    }

    public class OrderAddressViewModel
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
        [StringLength(20)]
        public string City { get; set; }

        [StringLength(20)]
        [Required]
        public string District { get; set; }

        [StringLength(8)]
        [Required]
        public string PostCode { get; set; }

        [StringLength(50)]
        [Required]
        public string Phone { get; set; }
    }

    // Implement Identity

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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
        [Display(Name = "Birthday")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [StringLength(50)]
        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [StringLength(20)]
        [Required]
        public string District { get; set; }

        [StringLength(8)]
        public string PostCode { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Please read and agree to the Privacy Policy")]
        public bool AgreeTerm { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
