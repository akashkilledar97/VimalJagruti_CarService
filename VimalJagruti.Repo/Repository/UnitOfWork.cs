﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.Entity;
using VimalJagruti.Repo.IRepository;

namespace VimalJagruti.Repo.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private readonly IStoredProcedureRepo _spRepo;
        public UnitOfWork(Context context, IStoredProcedureRepo spRepo)
        {
            _context = context;
            _spRepo = spRepo;
        }


        private IUserRepo _userRepo;
        private IVehicleRepo _vehicleRepo;
        private IRepository<Domain.Entity.VehicleOwnerDetails> _vehicleOwnerDetailsRepository;

        public IUserRepo userRepo => _userRepo ?? (_userRepo = new UserRepo(_context,_spRepo));
        public IVehicleRepo vehicleRepo => _vehicleRepo ?? (_vehicleRepo = new VehicleRepo(_context, _spRepo));
        public IRepository<Domain.Entity.VehicleOwnerDetails> vehicleOwnerDetailsRepository => _vehicleOwnerDetailsRepository ?? (_vehicleOwnerDetailsRepository =
             new GenericRepository<Domain.Entity.VehicleOwnerDetails>(_context));

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
            //Supress finalization
            GC.SuppressFinalize(this);
        }
    }
}
