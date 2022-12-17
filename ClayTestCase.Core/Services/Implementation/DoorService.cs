using ClayTestCase.Core.DataAccess.Interfaces;
using ClayTestCase.Core.Dtos;
using ClayTestCase.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Services.Implementation
{
    public class DoorService : IDoorService
    {
        private readonly IDoorRepository _doorRepository;
        private readonly IAccessRoleRepository _accessRoleRepository;

        public DoorService(IServiceProvider serviceProvider)
        {
            _doorRepository = serviceProvider.GetRequiredService<IDoorRepository>();
            _accessRoleRepository = serviceProvider.GetRequiredService<IAccessRoleRepository>();
        }

        //public Task<bool> CreateDoor(CreateDoorDto model)
        //{
        //    if (model != null)
        //    {

        //    }
        //}

        public async Task<bool> OpenDoor(int doorId, string role)
        {
            bool process = false;
            if(doorId != 0 && role != null)
            {
                process = await _doorRepository.OpenDoor(doorId, role);
                return process;
            }
            
            return process;
        }
    }
}
