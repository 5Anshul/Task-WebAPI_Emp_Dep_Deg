using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task1_db_design_Emp_Deg_Dep.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeAddress { get; set; }
        [Required]
        public string EmployeeEmail { get; set; }
        public int EmployeeSalary { get; set; }
        public int EmployeeAge { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public ICollection<DepartmentEmployee> DepartmentEmployees { get; set; }
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
    }
}
