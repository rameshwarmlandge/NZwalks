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
        public IEnumerable<Region> GetAllRegion()
        {
            return aZWalksDBContext.Regions.ToList();
        }
    }
}
