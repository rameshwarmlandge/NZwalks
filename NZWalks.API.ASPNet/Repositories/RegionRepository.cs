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


        /// <summary>
        /// This method use of adding data into region table
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await aZWalksDBContext.AddAsync(region);
            await aZWalksDBContext.SaveChangesAsync();
            return region;

        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await aZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }
            aZWalksDBContext.Regions.Remove(region);
            await aZWalksDBContext.SaveChangesAsync();
            return region;

        }

        /// <summary>
        /// THis method use of fetch all region record from database table
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Region>> GetAllRegionAsync()
        {
            return await aZWalksDBContext.Regions.ToListAsync();
        }
        /// <summary>
        /// This method use for fetch only particuler region record 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Region> GetRegionAsync(Guid id)
        {
            return await aZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// This method use for updeting the regtion data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await aZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.lat = region.lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await aZWalksDBContext.SaveChangesAsync();

            return existingRegion;
        }
    }

}
