using ClayTestCase.Core.Dtos;
using ClayTestCase.Core.Interfaces;
using ClayTestCase.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClayTestCase.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        private readonly IDoorRepository _doorRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public DoorController(IDoorRepository doorRepository, IEmployeeRepository employeeRepository)
        {
            _doorRepository = doorRepository;
            _employeeRepository = employeeRepository;
        }


        [HttpPost("")]
        public async Task<ActionResult> OpenDoor(int userid, int doorId)
        {
            var user = await _employeeRepository.Find(userid);
            var door = await _doorRepository.Find(doorId);

            if (user == null || door == null)
                return NotFound();
            if (!door.AccessRoles.Select(x => x.Name).Contains(user.Role)){
                return Unauthorized();
            }

            return Ok();
        }




    }
}
