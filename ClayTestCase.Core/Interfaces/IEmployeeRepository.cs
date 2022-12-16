using ClayTestCase.Core.Dtos;
using ClayTestCase.Core.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        ValueTask<(string, Employee, string)> RegisterUser(RegisterDto model);
        ValueTask<(string, Employee, string)> LoginUser(LoginDto model);
        Task<Employee> FindUserByEmail(string email);
    }
}
