using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimalJagruti.Repo.IRepository
{
    public interface IStoredProcedureRepo : IDisposable
    {
        T Get<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.StoredProcedure);
    }
}
