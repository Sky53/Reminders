using AutoMapper;
using Reminders.Business.AutoMapper.Event;
using Reminders.Business.AutoMapper.User;

namespace Reminders.Business.AutoMapper
{
    public class RemindersMapping : Profile
    {
        public RemindersMapping()
        {
            CreateMap<EventRequest, Domain.Models.Event>();
            CreateMap<Domain.Models.Event, EventResponse>();

            CreateMap<UserRequest, Domain.Models.User>();
            CreateMap<Domain.Models.User, UserResponse>();

            CreateMap<UserAuthorization, Domain.Models.User>();
            CreateMap<Domain.Models.User, UserAuthorization>();
        }
    }
}
