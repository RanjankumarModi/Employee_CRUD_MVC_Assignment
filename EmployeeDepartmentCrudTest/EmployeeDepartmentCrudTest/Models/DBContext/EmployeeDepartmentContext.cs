using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeDepartmentCrudTest.Models.DBContext
{
    public class EmployeeDepartmentContext:DbContext
    {
        public EmployeeDepartmentContext() : base("DBContext")
        {
            Database.SetInitializer<EmployeeDepartmentContext>(new CreateDatabaseIfNotExists<EmployeeDepartmentContext>());
            
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Salary> Salaries { get; set; }
    }
}