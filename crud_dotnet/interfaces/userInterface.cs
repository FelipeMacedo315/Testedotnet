

using TodoAPI.Models;

namespace crud_dotnet.Interface
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task GetByIdAsync(Guid id);
        Task CreateUserAsync(CreateUserRequest request);
        Task UpdateUserAsync(Guid id, UpdateUserRequest request);
        Task DeleteUserAsync(Guid id);
    }
}