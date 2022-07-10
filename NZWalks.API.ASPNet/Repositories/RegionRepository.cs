using Microsoft.EntityFrameworkCore;
using NZWalks.API.ASPNet.Data;
using NZWalks.API.ASPNet.Models.Domain;

namespace NZWalks.API.ASPNet.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDBContext aZWalksDBContext;

        public RegionRepository(NZWalksDBContext aZWalksDBContext)
        {
            this.aZWalksDBContext = aZWalksDBContext;
        }
        public async Task<IEnumerable<Region>> GetAllRegionAsync()
        {
            return await aZWalksDBContext.Regions.ToListAsync();
        }
    }
}
