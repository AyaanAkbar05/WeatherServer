using CountryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.IdentityModel.Tokens.Jwt;
using WeatherServer.DTO;

namespace WeatherServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<WorldCitiesUsers> userManager,
        JwtHandler jwtHandler) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            WorldCitiesUsers? user = await userManager.FindByNameAsync(loginRequest.UserName);
            if (user == null)
            {
                return Unauthorized("Bad username :P");
            }
            bool success = await userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!success)
            {
                return Unauthorized("Bad password :P");
            }
           JwtSecurityToken token = await jwtHandler.GetTokenAsync(user);
            string jwtstring = new JwtSecurityTokenHandler().WriteToken(token); 

            return Ok(new LoginResult
            {
                Success = true,
                Message = ":O",
                Token = jwtstring
            });
        }
    }
}
