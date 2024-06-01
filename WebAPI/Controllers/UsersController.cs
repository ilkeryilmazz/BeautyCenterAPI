using Business.Abstracts;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = _userService.Login(userForLoginDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _userService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("Register")]
      
        public IActionResult Register ([FromForm] IFormFile image,[FromForm]UserForRegisterDto userForRegisterDto)
        {
            var result = _userService.Register(userForRegisterDto, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]

        public IActionResult Update([FromForm] IFormFile? image, [FromForm] UserForRegisterDto userForRegisterDto)
        {
            var result = _userService.Update(userForRegisterDto, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("RegisterEmployee")]

        public IActionResult RegisterEmployee([FromForm] IFormFile image, [FromForm] UserForRegisterDto userForRegisterDto)
        {
            var result = _userService.RegisterEmployee(userForRegisterDto, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetEmployeeWithServiceByServiceId")]

        public IActionResult GetEmployeeWithServiceByServiceId(int serviceId)
        {
            var result = _userService.GetEmployeeWithServiceByServiceId(serviceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
            [HttpGet("GetById")]

        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllEmployees")]

        public IActionResult GetAllEmployees()
        {
            var result = _userService.GetAllEmployees();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
