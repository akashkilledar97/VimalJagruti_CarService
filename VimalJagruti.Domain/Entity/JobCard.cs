using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VimalJagruti.Utils;

namespace VimalJagruti.Domain.Entity
{
    /// <summary>
    /// All job card details 
    /// </summary>
    public class JobCard : CommonEntity
    {

        [ForeignKey("VehicleDetails")]
        public int VehicleDetailsId_FK { get; set; }

        /// <summary>
        /// All side vehicle photos in array
        /// </summary>
        public List<string> VehicleDentPhotos { get; set; }

        public string OperatorName { get; set; }

        public string OperatorPhoneNumber { get; set; }

        public UnderChassisCheck UnderChassisCheck { get; set; }

        public VehicleDriverCheck VehicleDriverCheck { get; set; }

        /// <summary>
        /// New estimated parts Id from product table (product Id).
        /// </summary>
        public List<int> NewEstimatedParts { get; set; }

        /// <summary>
        /// List of all observations and complaints
        /// </summary>
        public List<ObservationAndCustomerComplaints> ObservationAndCustomerComplaints { get; set; }

        public double EstimatedAmount { get; set; }

        /// <summary>
        /// Information of person who job card created
        /// </summary>
        [ForeignKey("JobCardCreatedUser")]
        public int CreatedById_FK { get; set; }

        /// <summary>
        /// Information of person who job card updated
        /// </summary>
        [ForeignKey("JobCardUpdatedUser")]
        public Nullable<int> UpdatedById_FK { get; set; }

        /// <summary>
        /// What is the status of job card. Completed = Vehicle is ready for invoice, In process = Vehicle is under servicing process , New = Not started servicing yet
        /// </summary>
        public JobCardStatus JobCardStatus { get; set; }

        /// <summary>
        /// Discount for perticuler customer. It will be in %. Final discount amount will be calculated in final invoice.
        /// </summary>
        public int Discount {get; set;}

        [JsonIgnore]
        public User JobCardCreatedUser { get; set; }

        [JsonIgnore]
        public User JobCardUpdatedUser { get; set; }


        [JsonIgnore]
        public VehicleDetails VehicleDetails { get; set; }


    }

    /// <summary>
    /// Details for chassis check
    /// </summary>
    public class UnderChassisCheck
    {
        public string TyreForDamage { get; set; }

        public string FuelAndBrakeFORLeaks { get; set; }

        public string AnyOtherLeaks { get; set; }

        public string ExhaustSystemAnyLeaks { get; set; }

        public string SteeringOrSuspensionOilLeakage { get; set; }

        public string FrontStrutORRearShocks { get; set; }

        public string DriveShaftBootCondition { get; set; }

        public string AnyOtherUnderBodyDamage { get; set; }


    }

    /// <summary>
    /// Details of Driver side things
    /// </summary>
    public class VehicleDriverCheck
    {
        public string ClutchPedalFreePlay { get; set; }

        public string BrakePedalForSpongy { get; set; }

        public string HandBrakeNotches { get; set; }
    }

    /// <summary>
    /// Customer complaints and observations
    /// </summary>
    public class ObservationAndCustomerComplaints
    {
        public string ObservationAndCustomerComplaint { get; set; }

        public bool Approved { get; set; }

    }
}
