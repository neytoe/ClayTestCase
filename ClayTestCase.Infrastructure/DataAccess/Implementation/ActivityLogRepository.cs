using ClayTestCase.Core.DataAccess.Interfaces;
using ClayTestCase.Core.Enitities;
using Microsoft.EntityFrameworkCore;

namespace ClayTestCase.Infrastructure.DataAccess.Implementation
{
    public class ActivityLogRepository : GenericRepository<ActivityLog>, IActivityLogRepository
    {
        public ActivityLogRepository(AssessmentDataContext dataContext) : base(dataContext)
        {
        }
    }
}
