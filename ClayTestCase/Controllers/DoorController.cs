using ClayTestCase.Core.Dtos;
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
        private readonly AssessmentDataContext _ctx;

        public DoorController(AssessmentDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("")]
        public Action OpenDoor(int userid, int doorId)
        {
            var User = _ctx.
        }
    }
}
