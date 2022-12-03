using AutoMapper;
using NZWalks.API.ASPNet.Models.Domain;
using NZWalks.API.ASPNet.Models.DTO;
namespace NZWalks.API.ASPNet.Models.Profiles
{
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<UserInfo, UserInfoDTO>()
                .ReverseMap();
        }
    }
}
