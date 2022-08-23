using EmployeeDataManager.Contract;
using EmployeeDataManager.DTO;
using Rhino.Mocks;
using ToDoDotNetAPI.Controllers;

namespace ToDoDotNetAPITest
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private IEmployeeDataService employeeDataService;
        public EmployeeControllerTest()
        {
            this.employeeDataService = MockRepository.GenerateStub<IEmployeeDataService>();
        }

        [TestMethod]
        public void TestGetAllEmployees()
        {
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
            employeeDtos.Add(new EmployeeDto { Id = 1, EmployeeName = "Girija Mohanty" });
            EmployeeController employeeController = new EmployeeController(this.employeeDataService);
            
                this.employeeDataService.Expect(x => x.GetAllEmployees()).Return(employeeDtos);
                var response = employeeController.Get();
                Assert.IsNotNull(response);
                var empDto = response as List<EmployeeDto>;

                Assert.AreEqual(employeeDtos.Count, empDto.Count);
           
        }
    }
}