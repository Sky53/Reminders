using Reminders.Business.AutoMapper.User;
using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.Business.Abstraction
{
    public interface IUserService
    {
        public Task<List<User>> GetAllAsync();
        public Task<long> AddAsync(UserRequest newUser);
        public Task<UserResponse> UpdateAsync(long id, UserRequest updateUser);
        public Task DeleteAsync(long id);
    }
}
