using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1_db_design_Emp_Deg_Dep.Models;

namespace Task1_db_design_Emp_Deg_Dep.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Employee>Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet <Designation> Designations{ get; set; }

        public DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentEmployee>().HasKey(sc => new { sc.EmployeeId, sc.DepartmentId });
        }


    }
}
