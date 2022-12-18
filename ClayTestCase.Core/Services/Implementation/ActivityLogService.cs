using ClayTestCase.Core.DataAccess.Interfaces;
using ClayTestCase.Core.Enitities;
using ClayTestCase.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Services.Implementation
{
    public class ActivityLogService : IActivityLogService
    {

        private readonly IActivityLogRepository _activityLogRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ActivityLogService(IActivityLogRepository activityLogRepository, IEmployeeRepository employeeRepository)
        {
            _activityLogRepository = activityLogRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<ActivityLog>> GetAllDoorHistory()
        {
            IEnumerable<ActivityLog> activityLogs;
            activityLogs = await _activityLogRepository.FindAll();
            if (activityLogs.Any()) return activityLogs;

            return activityLogs;
        }

        public async ValueTask<(bool, string)> SaveActivity(int doorId, bool IsAccessGranted, string email)
        {
            if (doorId != null && email != null)
            {
                var user = await _employeeRepository.FindUserByEmail(email);
                if (user != null)
                {
                    var activitylog = new ActivityLog
                    {
                        DoorId = doorId,
                        EmployeeId = user.Id,
                        EmployeeEmail = user.Email,
                        EmployeeRole = user.Role,
                        Date = DateTime.Now,
                        IsAccessGranted = IsAccessGranted
                    };

                    try
                    {
                        _activityLogRepository.Save(activitylog);
                        return (true, null);

                    }
                    catch (Exception ex)
                    {
                        return (false, ex.Message);
                    }
                }
            }
            
            return (false, null);

        }

    }
}
