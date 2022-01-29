

using System.Collections.Generic;
using VimalJagruti.Domain.Entity;

namespace VimalJagruti.Domain.ViewModel.JobCard
{
    public class JobCard
    {
        public int VehicleId { get; set; }
        public List<string> VehicleDentPhotos { get; set; }

        public string OperatorName { get; set; }

        public string OperatorPhoneNumber { get; set; }

        public UnderChassisCheck UnderChassisCheck { get; set; }

        public VehicleDriverCheck VehicleDriverCheck { get; set; }

        public List<int> NewEstimatedParts { get; set; }
        public List<string> ObservationAndCustomerComplaints { get; set; }

        public double EstimatedAmount { get; set; }

        public int Discount { get; set; }

        public RearsideCheckup RearsideCheckup { get; set; }

        public int FuelLevel { get; set; }
        public int Mileage { get; set; }
        public string RunningKM { get; set; }
    }
}
