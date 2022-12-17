using ClayTestCase.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClayTestCase.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        private readonly IEmployeeService _employeeService;
        private readonly IHttpContextAccessor _httpContext;

        public AuthController(IServiceProvider serviceProvider,
            IHttpContextAccessor httpContext)
        {
            _employeeService = serviceProvider.GetRequiredService<IEmployeeService>();
            _httpContext = httpContext;
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateUserRole")]
        public async Task<ActionResult> updateUserRole(int id, int roleId)
        {
            var isUserRoleUpdated = await _employeeService.UpdateUserRole(id, roleId);

            if (isUserRoleUpdated ) return Ok("Role Updated");

            return BadRequest("An error Occured");
        }

    }


       
    
}
