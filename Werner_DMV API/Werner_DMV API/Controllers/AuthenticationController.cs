using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Werner_DMV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JWTAuthenticationManager jwAuthenticationManager;
        public AuthenticationController(JWTAuthenticationManager jwAuthenticationManager)
        {
            this.jwAuthenticationManager = jwAuthenticationManager;
        }


        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody] User usr)
        {
            var token = jwAuthenticationManager.Authenticate(usr.username, usr.password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = token, Message = "Success" });
        }

        [Authorize]
        [Route("TestRoute")]
        [HttpGet]
        public IActionResult test()
        {
            return Ok("Authorized");
        }
    }
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
