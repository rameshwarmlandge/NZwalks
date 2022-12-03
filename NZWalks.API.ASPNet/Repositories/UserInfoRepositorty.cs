using Microsoft.EntityFrameworkCore;
using NZWalks.API.ASPNet.Data;
using NZWalks.API.ASPNet.Models.Domain;

namespace NZWalks.API.ASPNet.Repositories
{
    public class UserInfoRepositorty : IUserInfoRepository
    {
        private readonly NZWalksDBContext _aZWalksDBContext;
        public UserInfoRepositorty(NZWalksDBContext aZWalksDBContext)
        {
            this._aZWalksDBContext = aZWalksDBContext;   
        }

        public async Task<UserInfo> GetUserInfo(string aEmail, string aPassword)
        {
            return await _aZWalksDBContext.userInfos.FirstOrDefaultAsync(u => u.Email.Equals(aEmail) && u.Password.Equals(aPassword));
        }
    }
}
