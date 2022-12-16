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
        private readonly IActivityLogRepository _activityLogRepository;

        public DoorController(IDoorRepository doorRepository, IEmployeeRepository employeeRepository,
            IHttpContextAccessor httpContext, IActivityLogRepository activityLogRepository)
        {
            _doorRepository = doorRepository;
            _employeeRepository = employeeRepository;
            _httpContext = httpContext;
            _activityLogRepository = activityLogRepository;
        }


        [Authorize]
        [HttpPost("OpenDoor/{doorId}")]
        public async Task<ActionResult> OpenDoor(int doorId)
        {
            var role = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            var email = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var user = await _employeeRepository.FindUserByEmail(email);
            var IsAccessGranted = await _doorRepository.OpenDoor(doorId, role);

            if (IsAccessGranted && user != null)
            {
                await _activityLogRepository.SaveActivity(doorId, user, IsAccessGranted);
                return Ok("Door Opened Successfully");
            }

            await _activityLogRepository.SaveActivity(doorId, user, IsAccessGranted);
            return BadRequest("Invalid Request");
        }

        [Authorize(Roles = "StoreKeeper")]
        [HttpGet("GetDoorHistory/{doorId}")]
        public async Task<ActionResult> GetDoorHistory(int doorId)
        {
            
            var history = await _activityLogRepository.Find(doorId);
            if (history != null) return Ok(history);

            return BadRequest("An error Occured");
        }

        [Authorize(Roles = "StoreKeeper")]
        [HttpGet("GetAllDoorHistory")]
        public async Task<ActionResult> GetAllDoorHistory()
        {

            var history = await _activityLogRepository.FindAll();
            if (history.Any()) return Ok(history);

            return BadRequest("An error Occured");
        }

        //[Authorize(Roles = "StoreKeeper")]
        //[HttpPost("GetDoorHistory/{doorId}")]
        //public async Task<ActionResult> GetAllDoorsHistory()
        //{
        //    var role = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
        //    var email = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
        //    //var user = await _employeeRepository.Find(userid);
        //    var IsOpen = await _doorRepository.OpenDoor(doorId, role);

        //    if (IsOpen)
        //        return Ok();

        //    return BadRequest();
        //}

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
