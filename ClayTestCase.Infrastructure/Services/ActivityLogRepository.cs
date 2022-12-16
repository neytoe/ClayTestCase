using ClayTestCase.Core.Enitities;
using ClayTestCase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Infrastructure.Services
{
    public class ActivityLogRepository : BaseRepository<ActivityLog>, IActivityLogRepository
    {
        public ActivityLogRepository(AssessmentDataContext dataContext) : base(dataContext)
        {
        }

        public async Task<(bool, string)> SaveActivity(int doorId, Employee model, bool IsAccessGranted)
        {
            if(model != null)
            {
                var activitylog = new ActivityLog
                {
                    DoorId = doorId,
                    EmployeeId = model.Id,
                    EmployeeEmail = model.Email,
                    EmployeeRole = model.Role,
                    Date = DateTime.Now,
                    IsAccessGranted = IsAccessGranted
                };

                try
                {
                    _dataContext.ActivityLogs.Add(activitylog);
                    var res = await _dataContext.SaveChangesAsync();
                    return (true, null);

                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            }
            return (false, null);    
        }

       
    }
}
