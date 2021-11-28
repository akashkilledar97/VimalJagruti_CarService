using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Domain.ViewModel.User;
using VimalJagruti.Helper;
using VimalJagruti.Services.IServices;
using VimalJagruti.Utils;

namespace VimalJagruti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserServices _userService;
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;

        public AccountController(IUserServices userServices, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _userService = userServices;
            _configuration = configuration;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// API to login users
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(ResponseDataModel<List<BasicUserDetail>>), 200)]
        public IActionResult Authenticate([FromBody] LoginModel model)
        {

            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return Ok(new ResponseViewModel<bool> { Data = false, Message = Constants.InvalidEmail });

            if (!user.Status)
                return Ok(new ResponseViewModel<bool> { Data = false, Message = user.Message });

            var userDetails = TokenizeUser(user.Data);

            // return basic user info and authentication token
            return Ok(new ResponseViewModel<BasicUserDetail>
            {
                Data = userDetails,
                Message = Constants.LoginSuccess
            });

        }

        /// <summary>
        /// if access token expired thn use this for new one
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("refresh-accesstoken")]
        public async Task<IActionResult> TokenAuthentication([FromBody] RefreshTokenAuthentication refreshToken)
        {
            var jwtHelper = new JwtHelper(_configuration);
            var userPrinciple = jwtHelper.GetPrincipalFromExpiredToken(refreshToken.AuthToken);
            var userId = userPrinciple.Claims.SingleOrDefault(u => u.Type == "UserId")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Ok(new ResponseViewModel<bool>
                {
                    Data = false,
                    Message = Constants.LoginFailed
                });
            }
            else
            {
                var user = await _userService.AuthenticationToken(Convert.ToInt64(userId), refreshToken.RefreshToken);

                if (!user.Status)
                    return Ok(new ResponseViewModel<bool> { Data = false, Message = user.Message });

                var userDetails = TokenizeUser(user.Data);

                // Basic user info and token
                return Ok(new ResponseViewModel<BasicUserDetail>
                {
                    Data = userDetails,
                    Message = Constants.LoginSuccess
                });
            }
        }

        /// <summary>
        /// TO register user/customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterModel model)
        //{
        //    var res = await _userService.Register(model);
        //    return Ok(new ResponseViewModel<bool>
        //    {
        //        Data = res,
        //        Message = res ? Constants.SuccessRegister : Constants.GeneralError
        //    }) ;
        //}

        #region Private Methods
        private BasicUserDetail TokenizeUser(LoginResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Sercret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Issuer = "VimalJagruti",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Role, user.Roles.ToString()),
                    new Claim("UserId", user.Id.ToString())

                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            BasicUserDetail userDetails = new BasicUserDetail
            {
                Username = user.Username,
                Avatar = user.Avatar,
                FullName = user.FullName,
                AuthToken = tokenHandler.WriteToken(token),
                Roles = user.Roles,
                AuthTokenExpire = 180,
                RefreshToken = user.RefreshToken
            };
            return userDetails;
        }

        #endregion
    }
}
