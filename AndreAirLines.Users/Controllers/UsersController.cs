using ExampleJWTAuthentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelShare;
using System.Threading.Tasks;
using ModelShare.DTO;
using AndreAirLines.Users.Services;

namespace AndreAirLines.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserDTO modelDTO)
        {
            User model = new User(modelDTO.Login, modelDTO.Password, modelDTO.Section, modelDTO.Role, modelDTO.functionName);
            var user = await _userService.GetUser(model.Login, model.Password);

            if (user == null)
                return NotFound(new { message = "Invalid user" });

            var token = await TokenService.GenerateToken(user);

            user.Password = "";
            return new
            {
                user = user,
                token = token
            };

        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Post([FromBody] UserDTO modelDTO)
        {
            var register = await _userService.PostNewUser(modelDTO);
            return Ok();
        }
    }
}
