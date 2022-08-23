using EmployeeDataManager.Contract;
using EmployeeDataManager.DataManager;
using EmployeeDataManager.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ToDoDotNetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeDataService employeeDataService;

       // private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeDataService employeeDataService)
        {
           // _logger = logger;
            this.employeeDataService = employeeDataService;
        }

        [HttpGet(Name = "GetEmployees")]
        public IEnumerable<EmployeeDto> Get()
        {
            return this.employeeDataService.GetAllEmployees();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            
            int id = this.employeeDataService.SaveEmployee(employee);
            
            if(id==0)
            {
                return BadRequest("Duplicate Record");
            }

            employee.EmployeeName = employee.FirstName + " " + employee.LastName;
            employee.Id = id;
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeDto employee)
        {
            this.employeeDataService.UpdateEmployee(id, employee);

            return Ok();
        }
    }
}