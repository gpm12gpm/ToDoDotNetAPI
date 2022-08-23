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
    }
}