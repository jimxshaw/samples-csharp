using AutoMapper;
using MeetHub.Controllers.Api;
using MeetHub.Models;

namespace MeetHub
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDataTransferObject>();
            CreateMap<Category, CategoryDataTransferObject>();
            CreateMap<Meetup, MeetupDataTransferObject>();
            CreateMap<Notification, NotificationDataTransferObject>();
        }
    }
}