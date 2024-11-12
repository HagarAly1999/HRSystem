using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using webapp.Models;

namespace webapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly HrDatabaseContext _context;
        public EmployeesController(HrDatabaseContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult GetEmployee()
        {
            var emp=_context.Employees.ToList();
            var recordTotal = emp.Count();
            var jsonData = new { recordsFiltered = recordTotal, recordTotal, Data = emp };
            return Ok(jsonData);
        }
    }
}
