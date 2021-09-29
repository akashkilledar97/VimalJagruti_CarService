using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Domain.ViewModel.User;
using VimalJagruti.Services.IServices;
using VimalJagruti.Utils;

namespace VimalJagruti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<IUserServices>
    {
        public UserController(IUserServices userServices) : base(userServices)
        {
        }

        /// <summary>
        /// TO register user/customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromBody] RegisterModel model)
        {
            var res = await Service.AddUser(model);

            return Ok(new ResponseViewModel<bool>
            {
                Data = res,
                Message = res ? Constants.SuccessRegister : Constants.GeneralError
            });
        }
    }
}
