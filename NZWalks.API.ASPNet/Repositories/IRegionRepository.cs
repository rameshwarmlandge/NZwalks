using NZWalks.API.ASPNet.Models.Domain;

namespace NZWalks.API.ASPNet.Repositories
{
    public interface IRegionRepository
    {
        // This method use for Display all regions data. 
        Task<IEnumerable<Region>> GetAllRegionAsync();
        
        // This method use for display only pariculer region id record

        Task<Region> GetRegionAsync(Guid id);

        Task<Region> AddAsync(Region region);  
        Task<Region> DeleteAsync(Guid id);

        Task<Region> UpdateAsync(Guid id, Region region);
    }
}
