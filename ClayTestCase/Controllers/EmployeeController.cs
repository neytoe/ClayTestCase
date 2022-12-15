using ClayTestCase.Core.Dtos;
using ClayTestCase.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClayTestCase.Controllers
{   

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IDoorRepository _doorRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IDoorRepository doorRepository, IEmployeeRepository employeeRepository)
        {
            _doorRepository = doorRepository;
            _employeeRepository = employeeRepository;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var result = await _employeeRepository.LoginUser(model);
            if (result.Item2  != null) return Ok(new { Token = result.Item1 });
            return BadRequest(result);
        }


        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var result = await _employeeRepository.RegisterUser(model);
            if (result.Item2 != null) return Ok(new { Token = result.Item1 });
            return BadRequest(result);
        }
    }
}