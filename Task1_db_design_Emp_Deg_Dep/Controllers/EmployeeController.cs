using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1_db_design_Emp_Deg_Dep.Data;
using Task1_db_design_Emp_Deg_Dep.Models;

namespace Task1_db_design_Emp_Deg_Dep.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;   
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
            return Ok(_context.DepartmentEmployees.Include(n => n.Department).Include(n => n.Employee).ThenInclude(np => np.Designation).ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployees(int id)
        {
            var empfromDb = _context.Employees.Find(id);
            if (empfromDb == null) return NotFound();
            return Ok(empfromDb);
        }
        [HttpPost]
        public IActionResult SaveEmployee([FromBody] DepartmentEmployee departmentEmployee)
        {
            if (departmentEmployee != null && ModelState.IsValid)
            {
                
                _context.Employees.Add(departmentEmployee.Employee);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] DepartmentEmployee departmentEmployee)
        {
            if (departmentEmployee != null && ModelState.IsValid)
            { 
                _context.Employees.Update(departmentEmployee.Employee);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var empfromdb = _context.Employees.Find(id);
            if (empfromdb == null) return NotFound();
            _context.Employees.Remove(empfromdb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
