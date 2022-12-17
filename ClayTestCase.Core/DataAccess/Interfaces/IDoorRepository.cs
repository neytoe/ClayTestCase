using ClayTestCase.Core.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.DataAccess.Interfaces
{
    public interface IDoorRepository : IGenericRepository<Door>
    {
        Task<bool> OpenDoor(int doorId, string role);
    }
}
