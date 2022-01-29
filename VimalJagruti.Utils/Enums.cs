using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimalJagruti.Utils
{
    public enum Roles
    {
        Admin = 1,
        Owner = 2,
        Staff = 3
    }
    public enum FuelType
    {
        Petrol = 1,
        Diesel = 2,
        Electric = 3
    }
    public enum JobCardStatus
    {
        Completed = 1,
        InProcess = 2,
        New = 3
    }

    public enum Policies
    {
        Admin = 1,
        OwnerAndHigher = 2,
        StaffAndHigher = 3
    }
    public enum CheckupStatus
    {
        Good = 1,
        YetToCheck = 2,
        Replace = 3
    }

}
