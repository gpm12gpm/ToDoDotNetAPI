using EmployeeDataManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.Contract
{
    public interface IEmployeeDataService
    {
        List<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeById(int id);
    }
}
