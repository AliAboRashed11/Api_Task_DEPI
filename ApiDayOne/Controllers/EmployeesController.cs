using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiDayOne.Models;
namespace ApiDayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CompanyDBContext _context;
        public EmployeesController(CompanyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
          return Ok( _context.Employees.ToList());
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            var empFromDp = _context.Employees.Find(id);
            if (empFromDp == null)
            {
                return NotFound();
            }
            return Ok(empFromDp);
        }
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, new { message = "successfully created" });
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id ,Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            var empFromDp = _context.Employees.Find(id);
            if (empFromDp == null)
            {
                return NotFound();
            }
            empFromDp.Name = employee.Name;
            empFromDp.Age = employee.Age;
            empFromDp.Salary = employee.Salary;
            empFromDp.Address = employee.Address;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]

        public ActionResult Delete(int id)
        {
            var empFromDp = _context.Employees.Find(id);
            if (empFromDp == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(empFromDp);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
