using Microsoft.AspNetCore.Mvc.Filters;
using ApiDayOne.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
namespace ApiDayOne.Filters
{
    public class ValidateLocationAttribute:ActionFilterAttribute
    {
        private readonly CompanyDBContext _contxt;
        public ValidateLocationAttribute(CompanyDBContext contxt)
        {
            _contxt = contxt;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Project? project = context.ActionArguments["project"] as Project;
            var regex = new Regex("^(USA|SA|EGY)$");
            if (project == null || !regex.IsMatch(project.Location))
            {
                context.ModelState.AddModelError("Location","This Location is not covered");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
