using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Repositories.Interfaces;

namespace TaskManager.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDbContext _dbContext;

        public UserRepository(TaskSystemDbContext taskSystemDbContext)
        {
            _dbContext = taskSystemDbContext;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<List<UserModel>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> CreateUser(UserModel user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userToDelete = await GetUserById(id) ?? throw new Exception($"User {id} not found.");
            {
                _dbContext.Users.Remove(userToDelete);
                await _dbContext.SaveChangesAsync();

                return true;
            }
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userToUpdate = await GetUserById(id) ?? throw new Exception($"User {id} not found.");
            {
                _dbContext.Users.Update(userToUpdate);
                await _dbContext.SaveChangesAsync();

                return userToUpdate;
            }
        }
    }
}