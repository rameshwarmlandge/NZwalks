using NZWalks.API.ASPNet.Models.Domain;

namespace NZWalks.API.ASPNet.Models.DTO
{
    public class WalksDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public double Lenght { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficulyId { get; set; }

        // Navigation property

        public RegionDTO region { get; set; }
        public WalkDifficultyDTO WalkDifficulty { get; set; }
    }
}
