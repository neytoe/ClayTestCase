using ClayTestCase.Core.DataAccess.Interfaces;
using ClayTestCase.Core.Enitities;
using Microsoft.EntityFrameworkCore;

namespace ClayTestCase.Infrastructure.DataAccess.Implementation
{
    public class DoorRepository : GenericRepository<Door>, IDoorRepository
    {

        public DoorRepository(AssessmentDataContext dataContext) : base(dataContext)
        {
        }


        public async Task<bool> OpenDoor(int doorId, string role)
        {
            var door = _dataContext.Doors.Include(x => x.DoorAccessRoles).ThenInclude(x => x.AccessRole).FirstOrDefault(x => x.Id == doorId);
            if (String.IsNullOrEmpty(role) || door == null)
            {
                return false;
            }
            else
            {
                var allowedRoles = door.DoorAccessRoles.Select(x => x.AccessRole.Name);
                if (allowedRoles != null && allowedRoles.Any())
                {
                    if (allowedRoles.Contains(role))
                        return true;
                }                
            }
            return false;
        }

    }
}
