using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeDepartmentCrudTest.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(40, ErrorMessage = "Can't accept more than 40 characters")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Name")]
        [MinLength(3, ErrorMessage = "Name should contains atleast 3 Characters")]
        public  string DeptName { get; set; }
        
        [Required]
        public string Description { get; set; }
       public ICollection<Employee> Employees { get; set; }

    }
}