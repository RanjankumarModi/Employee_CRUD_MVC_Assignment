using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeDepartmentCrudTest.Models
{
    public class Employee  
    {
        [Key]
        public int EmployeeId { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Department")]
        [Required]
        public int DeptId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(40, ErrorMessage = "Can't accept more than 40 characters")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Name")]
        [MinLength(3, ErrorMessage = "Name should contains atleast 3 Characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]

        public DateTime DOJ { get; set; }

        [Display(Name = "Mobile")]
        [StringLength(10,MinimumLength =10,ErrorMessage ="Mobile number can't be less or more than 10 digit")]
        public long Mobile { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        //public string DeptName { get; set; }

        public Salary Salary { get; set; }
    }

   
}