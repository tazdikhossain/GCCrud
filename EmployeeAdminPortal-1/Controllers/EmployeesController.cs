using EmployeeAdminPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers
{
    // localhost:port/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);
        }
    }
}
