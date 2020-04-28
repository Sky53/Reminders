using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.DAL.Abstraction
{
    public interface IEventRepository
    {
        public Task<List<Event>> GetAllEvent();

        public Task<int> SaveAsync(Event newEvent);
    }
}
