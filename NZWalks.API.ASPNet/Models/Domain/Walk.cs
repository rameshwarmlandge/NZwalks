namespace NZWalks.API.ASPNet.Models.Domain
{
    public class Walk
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public double Lenght { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficulyId { get; set; }

        // Navigation property

        public Region region { get; set; }
        public WalkDifficulty WalkDifficulty  { get; set; }

    }
}
