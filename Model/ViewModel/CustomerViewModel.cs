using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class CustomerViewModel
    {
        public string ForCheckbox
        {
            get { return "<input type='checkbox' name='" + Id + "' value='" + Id + "'>"; }
        }
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get { return Firstname + " " + Lastname; } }
        public int Gender { get; set; }
        public string DisplayGender
        {
            get
            {
                if (Gender == 1)
                    return "Male";
                else if (Gender == 0)
                    return "Female";
                else
                    return "---";
            }
        }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string DisplayDOB { get { return DOB.Date.ToString("dd/MM/yyyy"); } }
        //<th width = "20%" > Address </ th >
        //                < th width="10%"> Email</th>
        //                <th width = "10%" > Phone </ th >
        //                < th width="10%"> Actions</th>

        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string FullAddress { get { return City + ", " + District + ", " + Address; }  }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? Status { get; set; }
        public string DisplayStatus
        {
            get
            {
                if (Status == false)
                    return "<span class='label label-sm label-danger'> Blocked </span>";
                else if (Status == true)
                    return "<span class='label label-sm label-success'> Usable </span>";
                else
                {
                    return "<span class='label label-sm label-default'> --- </span>";
                }
            }
        }


        public string ForAction
        {
            get { return "<a href = '/Admin/Customer/Detail/" + Id + "' class='btn btn-sm btn-default btn-circle btn-editable'><i class='fa fa-binoculars'></i> View </a>"; }

        }
    }
    public class CustomerFilterViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? Gender { get; set; }
        public DateTime DOB { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? Status { get; set; }
    }
}
