using NZWalks.API.ASPNet.Models.Domain;

namespace NZWalks.API.ASPNet.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegionAsync();
    }
}
