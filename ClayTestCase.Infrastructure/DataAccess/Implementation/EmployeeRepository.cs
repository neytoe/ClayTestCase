using ClayTestCase.Core.DataAccess.Interfaces;
using ClayTestCase.Core.Dtos;
using ClayTestCase.Core.Enitities;
using ClayTestCase.Core.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ClayTestCase.Infrastructure.DataAccess.Implementation
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly AuthSettings _settings;
        public EmployeeRepository(AssessmentDataContext dataContext, IOptions<AuthSettings> settings) : base(dataContext)
        {
            _settings = settings.Value;
        }



       
        public async Task<Employee> FindUserByEmail(string email)
        {
            var user = new Employee();
           if(string.IsNullOrEmpty(email)) return user;
           
           user = await _dataContext.Employees.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
           return user;
        }
    }
}
