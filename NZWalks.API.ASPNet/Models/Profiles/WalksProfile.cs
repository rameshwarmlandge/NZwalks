using AutoMapper;
using NZWalks.API.ASPNet.Models.Domain;
using NZWalks.API.ASPNet.Models.DTO;

namespace NZWalks.API.ASPNet.Models.Profiles
{
    public class WalksProfile :Profile
    {
        public WalksProfile()
        {
            CreateMap<Walk, WalksDTO>()
                .ReverseMap();
        }
    }
}
