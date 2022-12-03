using NZWalks.API.ASPNet.Models.Domain;

namespace NZWalks.API.ASPNet.Repositories
{
    public interface IUserInfoRepository
    {
        Task<UserInfo> GetUserInfo(string email,string password);

    }
}
