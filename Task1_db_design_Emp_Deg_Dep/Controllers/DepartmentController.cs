using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1_db_design_Emp_Deg_Dep.Data;
using Task1_db_design_Emp_Deg_Dep.Models;

namespace Task1_db_design_Emp_Deg_Dep.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetDepartment()
        {
            return Ok(_context.Departments.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetDepartments(int id)
        {
            var departmentFromDb = _context.Departments.Find(id);
            if (departmentFromDb == null) return NotFound();
            return Ok(departmentFromDb);
        }
        [HttpPost]
        public IActionResult SaveDepartment([FromBody] Department department)
        {
            if (department != null && ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateDepartment([FromBody] Department department)
        {
            if (department != null && ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteDepartment(int id)
        {
            var depfromdb = _context.Departments.Find(id);
            if (depfromdb == null) return NotFound();
            _context.Departments.Remove(depfromdb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
