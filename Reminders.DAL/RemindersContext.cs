using Microsoft.EntityFrameworkCore;
using Reminders.Domain.Models;

namespace Reminders.DAL
{
    public class RemindersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        public RemindersContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
