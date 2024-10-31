using AutoMapper;
using crud_dotnet.Interface;
using Microsoft.EntityFrameworkCore;
using TodoAPI.AppDataContext;
using TodoAPI.Models;

namespace user.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserDbContext _context;
        private readonly ILogger<UserServices> _logger;
        private readonly IMapper _mapper;
        // Get all TODO Items from the database 
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var usuario = await _context.Users.ToListAsync();
            if (usuario == null)
            {
                throw new Exception("Nenhum usuário encontrado");
            }
            return usuario;

        }
        public async Task CreateUserAsync(CreateUserRequest request)
        {
            try
            {
                var todo = _mapper.Map<User>(request);
                _context.Users.Add(todo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Todo item.");
                throw new Exception("An error occurred while creating the Todo item.");
            }
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(Guid id, UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }

        Task IUserServices.DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserServices(UserDbContext context, ILogger<UserServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

    }
}