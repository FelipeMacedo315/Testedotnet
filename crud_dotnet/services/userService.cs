using AutoMapper;
using crud_dotnet.Interface;
using Microsoft.EntityFrameworkCore;

using crud_dotnet.entitys;

namespace crud_dotnet.Services
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
                _logger.LogError(ex, "Houve um erro e não foi possivel criar o usuario.");
                throw new Exception("Houve um erro e não foi possivel criar o usuario.");
            }
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"Não existe nenhum usuario com este id: {id} .");
            }
            return user;
        }
        public async Task UpdateUserAsync(Guid id, UpdateUserRequest request)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    throw new Exception($"Todo item with id {id} not found.");
                }

                if (request.Nome != null)
                {
                    user.Nome = request.Nome;
                }
                if (request.Email != null)
                {
                    user.Email = request.Email;
                }
                if (request.Cpf != null)
                {
                    user.Cpf = request.Cpf;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Houve um erro ao tentar atualizar o usuario com o seguinte id :  {id}.");
                throw;
            }
        }

        // ...

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