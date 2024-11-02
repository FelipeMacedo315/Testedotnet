

using crud_dotnet.entitys;

namespace crud_dotnet.Interface
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task CreateUserAsync(CreateUserRequest request);
        Task UpdateUserAsync(Guid id, UpdateUserRequest request);
        Task DeleteUserAsync(Guid id);
    }
}