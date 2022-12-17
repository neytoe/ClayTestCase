using ClayTestCase.Core.Dtos;
using ClayTestCase.Core.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Services.Interfaces
{
    public interface IEmployeeService
    {
        ValueTask<(string, Employee, string)> RegisterUser(RegisterDto model);
        ValueTask<(string, Employee, string)> LoginUser(LoginDto model);
        Task<bool> UpdateUserRole(int userid, int newRoleId);
    }
}
