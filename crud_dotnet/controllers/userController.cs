using Microsoft.AspNetCore.Mvc;
using crud_dotnet.Interface;
using TodoAPI.Models;

namespace crud_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

    }
}