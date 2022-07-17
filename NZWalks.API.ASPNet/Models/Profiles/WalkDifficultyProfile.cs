using AutoMapper;
using NZWalks.API.ASPNet.Models.Domain;
using NZWalks.API.ASPNet.Models.DTO;

namespace NZWalks.API.ASPNet.Models.Profiles
{
    public class WalkDifficultyProfile : Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<WalkDifficulty, WalkDifficultyDTO>().
                ReverseMap();
        }
    }
}
