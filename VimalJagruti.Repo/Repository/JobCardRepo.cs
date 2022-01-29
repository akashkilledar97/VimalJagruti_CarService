using System.Linq;
using System.Threading.Tasks;
using VimalJagruti.Domain.Entity;
using VimalJagruti.Repo.IRepository;

namespace VimalJagruti.Repo.Repository
{
    public class JobCardRepo : GenericRepository<JobCard>,IJobCardRepo
    {
        private readonly Context _context;
        private readonly IStoredProcedureRepo _spRepo;
        public JobCardRepo(Context context,IStoredProcedureRepo spRepo) : base(context)
        {
            _context = context;
            _spRepo = spRepo;
        }

        public async Task<bool> CreateJobCard(Domain.ViewModel.JobCard.JobCard _jobCard, int CurrentUserId)
        {
            var jobCard = new JobCard
            {
                OperatorName = _jobCard.OperatorName,
                OperatorPhoneNumber = _jobCard.OperatorPhoneNumber,
                CreatedById_FK = CurrentUserId,
                Discount = _jobCard.Discount,
                FuelLevel = _jobCard.FuelLevel,
                EstimatedAmount = _jobCard.EstimatedAmount,
                JobCardStatus = Utils.JobCardStatus.InProcess,
                RearsideCheckup = _jobCard.RearsideCheckup,
                Mileage = _jobCard.Mileage,
                RunningKM = _jobCard.RunningKM,
                VehicleDentPhotos = _jobCard.VehicleDentPhotos,
                NewEstimatedParts = _jobCard.NewEstimatedParts,
                ObservationAndCustomerComplaints = _jobCard.ObservationAndCustomerComplaints,
                UnderChassisCheck = _jobCard.UnderChassisCheck,
                UpdatedById_FK = null,
                VehicleDetailsId_FK = _jobCard.VehicleId,
                VehicleDriverCheck = _jobCard.VehicleDriverCheck
            };

            _context.JobCards.Add(jobCard);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
