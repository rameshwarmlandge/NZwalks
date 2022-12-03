using Microsoft.EntityFrameworkCore;
using NZWalks.API.ASPNet.Data;
using NZWalks.API.ASPNet.Models.Domain;

namespace NZWalks.API.ASPNet.Repositories
{
    public class WalksRepository : IWalksRepository
    {

        private readonly NZWalksDBContext nZWalksDbContext;

        public WalksRepository(NZWalksDBContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="walk"></param>
        /// <returns></returns>
        public async Task<Walk> AddAsync(Walk walk)
        {
            // Assign New ID
            walk.id = Guid.NewGuid();
            await nZWalksDbContext.Walks.AddAsync(walk);
            await nZWalksDbContext.SaveChangesAsync();
            return walk;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Walk> DeleteAsync(Guid id)
        {
            var existingWalk = await nZWalksDbContext.Walks.FindAsync(id);

            if (existingWalk == null)
            {
                return null;
            }

            nZWalksDbContext.Walks.Remove(existingWalk);
            await nZWalksDbContext.SaveChangesAsync();
            return existingWalk;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await
                nZWalksDbContext.Walks
                .Include(x => x.region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Walk> GetAsync(Guid id)
        {
            return nZWalksDbContext.Walks
                .Include(x => x.region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.id == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="walk"></param>
        /// <returns></returns>
        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await nZWalksDbContext.Walks.FindAsync(id);

            if (existingWalk != null)
            {
                existingWalk.Lenght = walk.Lenght;
                existingWalk.name = walk.name;
                existingWalk.WalkDifficulyId = walk.WalkDifficulyId;
                existingWalk.RegionId = walk.RegionId;
                await nZWalksDbContext.SaveChangesAsync();
                return existingWalk;
            }

            return null;
        }

    }
}
