using ApiDayOne.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiDayOne.Filters;
namespace ApiDayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly CompanyDBContext _context;

        public ProjectsController(CompanyDBContext context) {
            _context = context;
        }
        [HttpPost("V1")]
        public ActionResult Add_V1(Project project)
        {
            project.Location = "Egy";
            _context.Add(project);
            _context.SaveChanges();
            return NoContent();

        }
        [HttpPost("V2")]
        [ServiceFilter(typeof(ValidateLocationAttribute))]
        public ActionResult Add_V2(Project project)
        {
            //if(project.Location !="egy"|| project.Location != "usa"|| project.Location != "sa")
            //{
            //    return BadRequest();
            //}
            _context.Add(project);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
