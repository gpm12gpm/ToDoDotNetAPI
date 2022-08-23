using EmployeeDataManager.DataManager;
using EmployeeDataManager.DTO;

namespace EmployeeDataManager
{
    public class EmployeeDataService: Contract.IEmployeeDataService
    {
        private EmployeeDBEntities employeeDB;
        public EmployeeDataService(EmployeeDBEntities employeeDB)
        {
            this.employeeDB = employeeDB;
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            var employees = this.employeeDB.Employee.Select(x => new EmployeeDto
            {
                Id = x.EmployeeID,
                EmployeeName = x.FirstName + " " + x.LastName
            }).ToList();

            return employees;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = this.employeeDB.Employee.Where(x => x.EmployeeID == id).Select(x => new EmployeeDto
            {
                Id = x.EmployeeID,
                EmployeeName = x.FirstName + " " + x.LastName
            }).FirstOrDefault();

            return employee;
        }

        public List<EmployeeDto> GetEmployeesByLastName(string lastName)
        {
            var employees = this.employeeDB.Employee.Where(
                x => x.LastName == lastName).Select(x => new EmployeeDto
                {
                    Id = x.EmployeeID,
                    EmployeeName = x.FirstName + " " + x.LastName
                }).ToList();

            return employees;
        }


    }
}
