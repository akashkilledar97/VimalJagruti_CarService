using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Domain.ViewModel.JobCard;
using VimalJagruti.Services.IServices;
using VimalJagruti.Utils;

namespace VimalJagruti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCardController : BaseController<IJobCardService>
    {
        public JobCardController(IJobCardService jobCardService) : base(jobCardService)
        {

        }


        /// <summary>
        /// To create job card
        /// </summary>
        /// <param name="vehiclenumber"></param>
        /// <returns></returns>
        [Authorize(Policy = nameof(Policies.StaffAndHigher))]
        [HttpPost("create-job-card")]
        public async Task<IActionResult> CreateJobCard(JobCard jobCard)
        {
            var res = await Service.CreateJobCard(jobCard,currentUsers.Id);

            return Ok(res);
        }
    }
}
