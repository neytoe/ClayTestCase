using ClayTestCase.Core.DataAccess.Interfaces;
using ClayTestCase.Core.Dtos;
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

        public async Task<List<ActivityLogDto>> GetAllDoorHistory()
        {
            var historyLogs = new List<ActivityLogDto>();
            var activityLogs = await _activityLogRepository.FindAll();
            if (activityLogs.Any())
            {
                foreach (var activity in activityLogs)
                {
                    historyLogs.Add(new ActivityLogDto
                    {
                        DoorId = activity.DoorId,
                        EmployeeId = activity.EmployeeId,
                        EmployeeEmail = activity.EmployeeEmail,
                        EmployeeRole = activity.EmployeeRole,
                        IsAccessGranted = activity.IsAccessGranted,
                        Date = activity.Date
                    });
                }                
                return historyLogs;
            } 
            return historyLogs;
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
