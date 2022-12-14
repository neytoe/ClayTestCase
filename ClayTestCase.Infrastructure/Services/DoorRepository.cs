using ClayTestCase.Core.Enitities;
using ClayTestCase.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Infrastructure.Services
{
    public class DoorRepository : BaseRepository<Door>, IDoorRepository
    {

        public DoorRepository(AssessmentDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<Door> Find(int? doorId )
        {
            var door = await _dataContext.Doors.Include(x => x.AccessRoles).FirstOrDefaultAsync(x => x.Id == doorId); 
            return door;
        }
    }
}
