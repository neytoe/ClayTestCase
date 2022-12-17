using ClayTestCase.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Services.Interfaces
{
    public interface IDoorService
    {
        Task<bool> OpenDoor(int doorId, string role);
       // Task<bool> CreateDoor(CreateDoorDto model);
    }
}
