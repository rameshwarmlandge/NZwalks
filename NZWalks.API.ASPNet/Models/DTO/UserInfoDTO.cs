namespace NZWalks.API.ASPNet.Models.DTO
{
    public class UserInfoDTO
    {
        public Guid Id { get; set; }
        public int UserID { get; set; }
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
