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
    [Route("api/designation")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DesignationController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetDesignation()
        {
            return Ok(_context.Designations.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetDesignations(int id)
        {
            var designationfromDb = _context.Designations.Find(id);
            if (designationfromDb == null) return NotFound();
            return Ok(designationfromDb);
        }
        [HttpPost]
        public IActionResult SaveDesignation([FromBody] Designation designation)
        {
            if (designation != null && ModelState.IsValid)
            {
                _context.Designations.Add(designation);
                _context.SaveChanges();
                return Ok();

            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateDesignation([FromBody] Designation designation)
        {
            if (designation != null && ModelState.IsValid)
            {
                _context.Designations.Update(designation);
                _context.SaveChanges();
                return Ok();

            }
            return BadRequest();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteDesignation(int id)
        {
            var desFromDb = _context.Designations.Find(id);
            if (desFromDb == null) return NotFound();
            _context.Designations.Remove(desFromDb);
            _context.SaveChanges();
            return Ok();

        }
    }
}
