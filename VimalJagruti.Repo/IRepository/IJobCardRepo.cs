
using System.Threading.Tasks;
using VimalJagruti.Domain.Entity;

namespace VimalJagruti.Repo.IRepository
{
    public interface IJobCardRepo : IRepository<JobCard>
    {
        Task<bool> CreateJobCard(Domain.ViewModel.JobCard.JobCard jobCard, int CurrentUserId);
        //Task<bool> GetAllJobCards(Domain.ViewModel.JobCard.JobCard jobCard, int CurrentUserId);
    }
}
