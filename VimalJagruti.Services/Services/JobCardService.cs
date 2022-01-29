using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Domain.ViewModel.JobCard;
using VimalJagruti.Repo.IRepository;
using VimalJagruti.Services.IServices;

namespace VimalJagruti.Services.Services
{
    public class JobCardService : IJobCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public JobCardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseViewModel<bool>> CreateJobCard(JobCard jobCard, int CurrentUserId)
        {
            if (jobCard.UnderChassisCheck == null || jobCard.VehicleDriverCheck == null)
                return new ResponseViewModel<bool>
                {
                    Data = false,
                    Message = Utils.Constants.DataIncorrect,
                    StatusCode = System.Net.HttpStatusCode.NotAcceptable
                };

            var obj = await _unitOfWork.jobCardRepo.CreateJobCard(jobCard,CurrentUserId);

            return new ResponseViewModel<bool>
            {
                Data = true,
                Message = Utils.Constants.JobCardCreated,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}
