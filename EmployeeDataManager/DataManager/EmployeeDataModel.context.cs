using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManager.DataManager
{
    public partial class EmployeeDBEntities : DbContext
    {

        public EmployeeDBEntities(DbContextOptions<EmployeeDBEntities> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employee { get; set; }
    }
}
