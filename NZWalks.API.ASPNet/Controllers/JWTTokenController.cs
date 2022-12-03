using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NZWalks.API.ASPNet.Data;
using NZWalks.API.ASPNet.Models.Domain;
using NZWalks.API.ASPNet.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.ASPNet.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class JWTTokenController : ControllerBase
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;
        public IConfiguration _configuration;
        private readonly NZWalksDBContext _nZWalksDBContext;

        public JWTTokenController(IConfiguration configuration, IUserInfoRepository userInfoRepository, IMapper mapper)
        {

            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
            _configuration = configuration;
            //_nZWalksDBContext = nZWalksDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserInfo _userInfo)
        {
            UserInfo userInfo = new UserInfo();
            

            //UserInfo objuserInfo = new UserInfo();
            //objuserInfo.Email = "rameshwar.landge95@gmai.com";
            //objuserInfo.Password = "12345";
            //objuserInfo.UserName = "rameshwar";
            //objuserInfo.DisplayName = "rameshwarLAndge";
            //objuserInfo.UserID = 1;
            //_userInfo = objuserInfo;

            if (_userInfo != null)
            {
                var userinfoDTO = await _userInfoRepository.GetUserInfo(_userInfo.Email, _userInfo.Password);

                _userInfo = _mapper.Map<UserInfo>(userinfoDTO);

                if (_userInfo.UserName != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", _userInfo.UserID.ToString()),
                        new Claim("DisplayName", _userInfo.DisplayName),
                        new Claim("UserName", _userInfo.UserName),
                        new Claim("Email", _userInfo.Email)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credential");
                }
            }
            else
            {
                return BadRequest("You not enter user info for ");
            }
        }
    }
}
