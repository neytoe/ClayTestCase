using ClayTestCase.Core.Dtos;
using ClayTestCase.Core.Enitities;
using ClayTestCase.Core.Interfaces;
using ClayTestCase.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClayTestCase.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        private readonly IDoorRepository _doorRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHttpContextAccessor _httpContext;

        public DoorController(IDoorRepository doorRepository, IEmployeeRepository employeeRepository,
            IHttpContextAccessor httpContext)
        {
            _doorRepository = doorRepository;
            _employeeRepository = employeeRepository;
            _httpContext = httpContext;
        }


        [Authorize]
        [HttpPost("OpenDoor/{doorId}")]
        public async Task<ActionResult> OpenDoor(int doorId)
        {
            var role = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            var email = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            //var user = await _employeeRepository.Find(userid);
            var IsOpen = await _doorRepository.OpenDoor(doorId, role);

            if (IsOpen)
                return Ok();          

            return BadRequest();
        }

        //[Authorize]
        //[HttpPost("CreateDoor")]
        //public async Task<ActionResult> CreateDoor(CreateDoorDto model)
        //{
        //    if (model == null) return BadRequest();
        //    var door = new Door
        //    {
        //        Name = model.Name,
        //        AccessRoles = model.AccessRoles,
        //    };

        //    var accessRoles = new Access 
        //    var newdoor = _doorRepository.Save(


        //}




    }
}
