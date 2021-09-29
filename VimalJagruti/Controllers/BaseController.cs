using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Utils;

namespace VimalJagruti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TService> : Controller
    {
        protected TService Service { get; }
        protected CurrentUser currentUsers;

        public BaseController(TService service)
        {
            Service = service;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var identityClaims = context.HttpContext.User;
            currentUsers = new CurrentUser();
            var claimValue = identityClaims.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var parseResult = Enum.TryParse<Roles>(claimValue, true, out var role);

            currentUsers.Id = Convert.ToInt64(identityClaims.Claims.SingleOrDefault(c => c.Type == "UserId")?.Value);
            currentUsers.Name = identityClaims.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
   
        }
    }
}
