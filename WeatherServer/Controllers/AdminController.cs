using CountryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WeatherServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<WorldCitiesUsers> userManager,
        JwtHandler jwtHandler) : ControllerBase
    {
        [HttpPost]
        public void Login()
        {

        }
    }
}
