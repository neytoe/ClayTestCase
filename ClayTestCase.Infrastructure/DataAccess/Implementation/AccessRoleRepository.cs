using ClayTestCase.Core.DataAccess.Interfaces;
using ClayTestCase.Core.Enitities;

namespace ClayTestCase.Infrastructure.DataAccess.Implementation
{
    public class AccessRoleRepository : GenericRepository<AccessRole>, IAccessRoleRepository
    {
        public AccessRoleRepository(AssessmentDataContext dataContext) : base(dataContext)
        {
        }
    }
}
