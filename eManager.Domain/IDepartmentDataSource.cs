using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eManager.Domain
{
    public interface IDepartmentDataSource
    {
        IQueryable<Employee> Employees { get;}
        IQueryable<Department> Departments { get; }
        void Save();
    } 
}
