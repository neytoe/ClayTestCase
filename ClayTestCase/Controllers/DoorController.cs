using ClayTestCase.Core.Services.Interfaces;
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
        private readonly IDoorService _doorService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IActivityLogService _activityLogService;

        public DoorController(IDoorService doorService, IHttpContextAccessor httpContext, IActivityLogService activityLogService)
        {
            _doorService = doorService;
            _httpContext = httpContext;
            _activityLogService = activityLogService;
        }


        [Authorize]
        [HttpPost("OpenDoor/{doorId}")]
        public async Task<ActionResult> OpenDoor(int doorId)
        {
            var role = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            var email = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var IsAccessGranted = await _doorService.OpenDoor(doorId, role);           

            if (IsAccessGranted)
            {
                await _activityLogService.SaveActivity(doorId, IsAccessGranted, email);
                return Ok("Door Opened Successfully");
            }

            await _activityLogService.SaveActivity(doorId,IsAccessGranted, email);
            return BadRequest("Invalid Request");
        }

        [Authorize(Roles = "StoreKeeper")]
        [HttpGet("GetDoorHistory/{doorId}")]
        public async Task<ActionResult> GetDoorHistory(int doorId)
        {
            
            var activityLog = await _activityLogService.GetDoorHistory(doorId);
            if (activityLog != null) return Ok(activityLog);

            return BadRequest("An error Occured");
        }

        [Authorize(Roles = "StoreKeeper")]
        [HttpGet("GetAllDoorHistory")]
        public async Task<ActionResult> GetAllDoorHistory()
        {

            var activityLogs = await _activityLogService.GetAllDoorHistory();
            if (activityLogs.Any()) return Ok(activityLogs);
            if (!activityLogs.Any()) return NoContent();

            return BadRequest("An error Occured");
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPost("CreateDoor")]
        //public async Task<ActionResult> CreateDoor(CreateDoorDto model)
        //{
        //    var role = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
        //    var email = _httpContext.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
        //    var IsAccessGranted = await _doorService.CreateDoor(model);

        //    if (IsAccessGranted)
        //    {
        //        await _activityLogService.SaveActivity(doorId, IsAccessGranted, email);
        //        return Ok("Door Opened Successfully");
        //    }

        //    await _activityLogService.SaveActivity(doorId, IsAccessGranted, email);
        //    return BadRequest("Invalid Request");
        //}

    }
}
