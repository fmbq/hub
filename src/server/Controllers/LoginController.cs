using System;
using System.Threading.Tasks;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMBQ.Hub.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly UserService userService;

        public LoginController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            if (await userService.ValidateCredentials(request.Email, request.Password) is long id)
            {
                HttpContext.Session.SetString("userId", id.ToString());
                await HttpContext.Session.CommitAsync();

                return NoContent();
            }

            return new JsonResult(new Error
            {
                Message = "Invalid login"
            })
            {
                StatusCode = 403
            };
        }
    }
}
