using ClayTestCase.Core.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Interfaces
{
    public interface IActivityLogRepository : IRepository<ActivityLog>
    {
        Task<(bool, string)> SaveActivity(int doorId, Employee model, bool IsDoorOpen);
    }
}
