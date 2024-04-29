using TaskManager.Models;

namespace TaskManager.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUserById(int id);

        Task<UserModel> CreateUser(UserModel user);

        Task<UserModel> UpdateUser(UserModel user, int id);

        Task<bool> DeleteUser(int id);

    }
}