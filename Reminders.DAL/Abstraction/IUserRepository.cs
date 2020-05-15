using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.DAL.Abstraction
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUserAsync();
        public Task<long> SaveAsync(User newUser);
        public Task<User> FindByIdAsync(long id);
        Task<User> UppdateAsync(User updateUser);
        Task DeleteAsync(User deletedUser);
        Task<User> FindByLogginAndPasswordAsync(string login, string password);
    }
}
