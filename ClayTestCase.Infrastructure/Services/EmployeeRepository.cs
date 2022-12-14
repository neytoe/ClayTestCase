using ClayTestCase.Core.Enitities;
using ClayTestCase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Infrastructure.Services
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AssessmentDataContext dataContext) : base(dataContext)
        {
        }
    }
}
