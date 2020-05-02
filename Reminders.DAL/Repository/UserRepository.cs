using Microsoft.EntityFrameworkCore;
using Reminders.DAL.Abstraction;
using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RemindersContext _context;

        public UserRepository(RemindersContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return (await _context.Users.ToListAsync()).Where(u => u.IsDeleted == false).ToList();
        }

        public async Task<User> FindByIdAsync(long id)
        {
            var entity = await _context.Users.FindAsync(id);
            _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        

        public async Task<long> SaveAsync(User newUser)
        {
            if (newUser == null)
            {
                throw new Exception("Empty User");
            }

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser.Id;
        }

        public async Task<User> UppdateAsync(User updateUser)
        {
            _context.Users.Update(updateUser);
            await _context.SaveChangesAsync();

            return updateUser;
        }

        public async Task DeleteAsync(User deletedUser)
        {
            _context.Users.Update(deletedUser);
            await _context.SaveChangesAsync();
        }
    }
}
