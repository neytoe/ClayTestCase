using ClayTestCase.Core.Dtos;
using ClayTestCase.Core.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Services.Interfaces
{
    public interface IActivityLogService 
    {
        ValueTask<(bool, string)> SaveActivity(int doorId, bool IsAccessGranted, string email);
        Task<List<ActivityLogDto>> GetAllDoorHistory();
    }
}
