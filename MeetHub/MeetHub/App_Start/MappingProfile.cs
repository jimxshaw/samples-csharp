using AutoMapper;
using MeetHub.DTOs;
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