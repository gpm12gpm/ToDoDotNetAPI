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
                LastName = x.LastName,
                FirstName = x.FirstName,
                EmployeeName = x.FirstName + " " + x.LastName
            }).ToList();

            return employees;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = this.employeeDB.Employee.Where(x => x.EmployeeID == id).Select(x => new EmployeeDto
            {
                Id = x.EmployeeID,
                LastName= x.LastName,
                FirstName= x.FirstName,
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

        public int SaveEmployee(EmployeeDto employee)
        {
            Employee emp = new Employee();
            //emp.EmployeeID = employee.Id;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            this.employeeDB.Employee.Add(emp);
            this.employeeDB.SaveChanges();
            return emp.EmployeeID;
        }

        public void UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            var employee = this.employeeDB.Employee.Where(x => x.EmployeeID == id).FirstOrDefault();

            if(employee==null)
            {
                return;
            }

            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            this.employeeDB.SaveChanges();
        }
    }
}
