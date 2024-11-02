using Microsoft.AspNetCore.Mvc;
using crud_dotnet.Interface;
using crud_dotnet.Services;

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
        [HttpPost]
        public async Task<IActionResult> CreateTodoAsync(CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {

                await _userServices.CreateUserAsync(request);
                return Ok(new { message = "Novo usuario criado!" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "houve algum erro e não foi possivel criar novo usuario", error = ex.Message });

            }
        }
        //////////////////////////////////////////////////////////////////////////////////// //////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////// //////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////// //////////////////////////////////////////
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var user = await _userServices.GetAllAsync();
                if (user == null || !user.Any())
                {
                    return Ok(new { message = "Não tem nenhum usuario cadastrado" });
                }
                return Ok(new { message = "Veja todos usuarios", data = user });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "houve um erro e não foi possivel mostrar todos usuarios", error = ex.Message });


            }
        }
        //////////////////////////////////////////////////////////////////////////////////// //////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////// //////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////// //////////////////////////////////////////
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var user = await _userServices.GetByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new { message = $"Nenhum usuario encontrado com este id:    {id} found." });
                }
                return Ok(new { message = $"Usuario do id:   {id}.", data = user });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Houve um erro e não encontramos nenhum usuario com este id: {id}.", error = ex.Message });
            }
        }
    }
}