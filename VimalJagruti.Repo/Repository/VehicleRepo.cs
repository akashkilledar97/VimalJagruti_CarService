using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.Entity;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Repo.IRepository;

namespace VimalJagruti.Repo.Repository
{
    public class VehicleRepo : GenericRepository<VehicleDetails>,IVehicleRepo
    {
        private readonly Context _context;
        private readonly IStoredProcedureRepo _spRepo;
        public VehicleRepo(Context context, IStoredProcedureRepo spRepo) : base(context)
        {
            _context = context;
            _spRepo = spRepo;
        }

        public async Task<Domain.ViewModel.VehicleDetails.VehicleDetails> GetVehicleDetails(string vehicleNumber)
        {
            if (string.IsNullOrEmpty(vehicleNumber))
                return null;

            //Attach parameters
            DynamicParameters param = new DynamicParameters();
            param.Add("@@VehicleNumber", vehicleNumber);

            var sp = "GetVehicleDetails";

            //Execute stored procedure
            var details = _spRepo.Get<Domain.ViewModel.VehicleDetails.VehicleDetails>(sp, param);

            if (details == null)
                return null;

            return details;
        }

        public Task<ResponseViewModel<bool>> RegisterVehicle(Domain.ViewModel.VehicleDetails.NewVehicleDetails newVehicleDetails)
        {
            throw new NotImplementedException();
        }
    }
}
