using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.Entity;

namespace VimalJagruti.Repo
{
    public class Context : DbContext
    {
        protected readonly IConfiguration Configuration;
        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("VmJagrutiCS"));
        }

        //DB tables
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<JobCard> JobCards { get; set; }
        public DbSet<Pre_Invoice> Pre_Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductQuantityManagement> ProductQuantityManagements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VehicleDetails> VehicleDetails { get; set; }
        public DbSet<VehicleOwnerDetails> VehicleOwnerDetails { get; set; }

        //on model creation serialisation and deserialisation

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Job card
            modelBuilder.Entity<JobCard>()
                .Property(p => p.VehicleDentPhotos).HasConversion(
                    a => JsonConvert.SerializeObject(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    a => JsonConvert.DeserializeObject<List<string>>(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

            modelBuilder.Entity<JobCard>()
                .Property(p => p.UnderChassisCheck).HasConversion(
                    a => JsonConvert.SerializeObject(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    a => JsonConvert.DeserializeObject<UnderChassisCheck>(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

            modelBuilder.Entity<JobCard>()
                .Property(p => p.VehicleDriverCheck).HasConversion(
                    a => JsonConvert.SerializeObject(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    a => JsonConvert.DeserializeObject<VehicleDriverCheck>(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

            modelBuilder.Entity<JobCard>()
                .Property(p => p.NewEstimatedParts).HasConversion(
                    a => JsonConvert.SerializeObject(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    a => JsonConvert.DeserializeObject<List<int>>(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

            modelBuilder.Entity<JobCard>()
                .Property(p => p.ObservationAndCustomerComplaints).HasConversion(
                    a => JsonConvert.SerializeObject(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    a => JsonConvert.DeserializeObject<List<string>>(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

            modelBuilder.Entity<JobCard>()
                .Property(p => p.RearsideCheckup).HasConversion(
                    a => JsonConvert.SerializeObject(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    a => JsonConvert.DeserializeObject<RearsideCheckup>(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );


            #endregion

            #region Pre-Invoice

            modelBuilder.Entity<Pre_Invoice>()
                .Property(p => p.Particulers).HasConversion(
                    a => JsonConvert.SerializeObject(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    a => JsonConvert.DeserializeObject<List<Particuler>>(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

            modelBuilder.Entity<Pre_Invoice>()
                .Property(p => p.Labours).HasConversion(
                    a => JsonConvert.SerializeObject(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    a => JsonConvert.DeserializeObject<List<Labour>>(a, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

            #endregion
        }
    }
}
