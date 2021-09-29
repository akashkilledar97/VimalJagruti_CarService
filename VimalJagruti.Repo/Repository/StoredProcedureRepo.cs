using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Repo.IRepository;

namespace VimalJagruti.Repo.Repository
{
    public class StoredProcedureRepo : IStoredProcedureRepo
    {
        protected readonly IConfiguration Configuration;
        public StoredProcedureRepo(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public T Get<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString("VmJagrutiCS")))
            {
                db.Open();
               return db.Query<T>(sp,parms, commandType: commandType).FirstOrDefault();
            }
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString("VmJagrutiCS")))
            {
                db.Open();
                return db.Query<T>(sp, parms, commandType: commandType).ToList();
            }
        }
        public void Dispose()
        {
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
