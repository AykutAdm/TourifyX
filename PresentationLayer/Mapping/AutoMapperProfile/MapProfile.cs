using AutoMapper;
using DtoLayer.Dtos.AnnouncementDtos;
using DtoLayer.Dtos.AppUserDtos;
using DtoLayer.Dtos.ContactDtos;
using EntityLayer.Concrete;

namespace PresentationLayer.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ListAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<AddAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<UpdateAnnouncementDto, Announcement>().ReverseMap();

            CreateMap<AppUserRegisterDto, AppUser>().ReverseMap();

            CreateMap<AppUserLoginDto, AppUser>().ReverseMap();

            CreateMap<SendMessageDto, ContactUs>().ReverseMap();


        }
    }
}
