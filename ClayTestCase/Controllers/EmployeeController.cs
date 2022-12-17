using ClayTestCase.Core.DataAccess.Interfaces;
using ClayTestCase.Core.Dtos;
using ClayTestCase.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClayTestCase.Controllers
{   

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var result = await _employeeService.LoginUser(model);
            if (result.Item2  != null) return Ok(new { Token = result.Item1 });
            return BadRequest(result);
        }


        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var result = await _employeeService.RegisterUser(model);
            if (result.Item2 != null) return Ok(new { Token = result.Item1 });
            return BadRequest(result);
        }
    }
}