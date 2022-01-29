
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Domain.ViewModel.JobCard;

namespace VimalJagruti.Services.IServices
{
    public interface IJobCardService
    {
        /// <summary>
        /// Job card creation method
        /// </summary>
        /// <param name="jobCard"></param>
        /// <param name="CurrentUserId"></param>
        /// <returns></returns>
        Task<ResponseViewModel<bool>> CreateJobCard(JobCard jobCard, int CurrentUserId);
    }
}
