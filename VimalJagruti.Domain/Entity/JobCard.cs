using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public List<string> ObservationAndCustomerComplaints { get; set; }

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

        /// <summary>
        /// Rearside checkup from jobcard
        /// </summary>
        public RearsideCheckup RearsideCheckup { get; set; }

        /// <summary>
        /// Fuel level when doing job card
        /// </summary>
        public int FuelLevel { get; set; }

        /// <summary>
        /// Mileage when doing job card
        /// </summary>
        public int Mileage { get; set; }

        [MaxLength(20)]
        public string RunningKM { get; set; }

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
        public CheckupStatus TyreForDamage { get; set; }

        public CheckupStatus FuelAndBrakeFORLeaks { get; set; }

        public CheckupStatus AnyOtherLeaks { get; set; }

        public CheckupStatus ExhaustSystemAnyLeaks { get; set; }

        public CheckupStatus SteeringOrSuspensionOilLeakage { get; set; }

        public CheckupStatus FrontStrutORRearShocks { get; set; }

        public CheckupStatus DriveShaftBootCondition { get; set; }

        public CheckupStatus AnyOtherUnderBodyDamage { get; set; }


    }

    /// <summary>
    /// Details of Driver side things
    /// </summary>
    public class VehicleDriverCheck
    {
        public CheckupStatus ClutchPedalFreePlay { get; set; }

        public CheckupStatus BrakePedalForSpongy { get; set; }

        public CheckupStatus HandBrakeNotches { get; set; }
    }

    /// <summary>
    /// Customer complaints and observations
    /// </summary>
    public class ObservationAndCustomerComplaints
    {
        public string ObservationAndCustomerComplaint { get; set; }

        public bool Approved { get; set; }

    }

    /// <summary>
    /// Rearside checkup data in jobcard
    /// </summary>
    public class RearsideCheckup
    {
        public int SpareWheel { get; set; }
        public int JackWheel { get; set; }
        public int BootMat { get; set; }
        public int FirstAidKit { get; set; }
        public int WarningTraingle { get; set; }
        public int ToolKit { get; set; }
    }
}
