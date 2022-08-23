using EmployeeDataManager.Contract;
using EmployeeDataManager.DTO;
using Microsoft.AspNetCore.Mvc;
using Rhino.Mocks;
using System.Web.Http.Results;
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

        [TestMethod]
        public void TestSaveEmployeePass()
        {
            var  actualEmployeeDto = new EmployeeDto();
            actualEmployeeDto.LastName = "Mohanty";
            actualEmployeeDto.FirstName = "Girija";

            //employeeDtos.Add(new EmployeeDto { Id = 1, EmployeeName = "Girija Mohanty" });
            EmployeeController employeeController = new EmployeeController(this.employeeDataService);

            this.employeeDataService.Expect(x => x.SaveEmployee(actualEmployeeDto)).Return(1);
            var response = employeeController.Create(actualEmployeeDto) as OkObjectResult;
            Assert.IsNotNull(response);
            var expectedEmployeeDto = response.Value as EmployeeDto;

            Assert.AreEqual(actualEmployeeDto.FirstName, expectedEmployeeDto.FirstName);
            Assert.AreEqual(1, expectedEmployeeDto.Id);

        }

        [TestMethod]
        public void TestSaveEmployeeFail()
        {
            var actualEmployeeDto = new EmployeeDto();
            actualEmployeeDto.LastName = "Mohanty";
            actualEmployeeDto.FirstName = "Girija";

            EmployeeController employeeController = new EmployeeController(this.employeeDataService);

            this.employeeDataService.Expect(x => x.SaveEmployee(actualEmployeeDto)).Return(0);
            var response = employeeController.Create(actualEmployeeDto) as BadRequestObjectResult;
            Assert.IsNotNull(response);
            var expectedResult = response.Value as string;

            Assert.AreEqual("Duplicate Record", expectedResult);
            //Assert.AreEqual(1, expectedEmployeeDto.Id);

        }
    }
}