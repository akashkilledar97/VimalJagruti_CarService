﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VimalJagruti.Repo;

namespace VimalJagruti.Repo.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VimalJagruti.Domain.Entity.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FeedbackMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleOwnerId_FK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleOwnerId_FK");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<double>("GSTAmount")
                        .HasColumnType("float");

                    b.Property<double>("NetAmount")
                        .HasColumnType("float");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.JobCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById_FK")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<double>("EstimatedAmount")
                        .HasColumnType("float");

                    b.Property<int>("JobCardStatus")
                        .HasColumnType("int");

                    b.Property<string>("NewEstimatedParts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObservationAndCustomerComplaints")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatorPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RearsideCheckup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnderChassisCheck")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedById_FK")
                        .HasColumnType("int");

                    b.Property<string>("VehicleDentPhotos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleDetailsId_FK")
                        .HasColumnType("int");

                    b.Property<string>("VehicleDriverCheck")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById_FK");

                    b.HasIndex("UpdatedById_FK");

                    b.HasIndex("VehicleDetailsId_FK");

                    b.ToTable("JobCards");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.Pre_Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InvoiceId_FK")
                        .HasColumnType("int");

                    b.Property<int>("JobCardIdFK_FK")
                        .HasColumnType("int");

                    b.Property<string>("Labours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Particulers")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId_FK");

                    b.HasIndex("JobCardIdFK_FK");

                    b.ToTable("Pre_Invoices");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId_FK")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId_FK");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.ProductQuantityManagement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BatchNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId_FK")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId_FK");

                    b.ToTable("ProductQuantityManagements");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.VehicleDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChassisNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EngineNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<string>("RunningKM")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VehicleBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleOwnerId_FK")
                        .HasColumnType("int");

                    b.Property<string>("VehicleQR")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("VehicleOwnerId_FK");

                    b.ToTable("VehicleDetails");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.VehicleOwnerDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleOwnerDetails");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.Feedback", b =>
                {
                    b.HasOne("VimalJagruti.Domain.Entity.VehicleOwnerDetails", "VehicleOwner")
                        .WithMany()
                        .HasForeignKey("VehicleOwnerId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleOwner");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.JobCard", b =>
                {
                    b.HasOne("VimalJagruti.Domain.Entity.User", "JobCardCreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedById_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VimalJagruti.Domain.Entity.User", "JobCardUpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedById_FK");

                    b.HasOne("VimalJagruti.Domain.Entity.VehicleDetails", "VehicleDetails")
                        .WithMany()
                        .HasForeignKey("VehicleDetailsId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobCardCreatedUser");

                    b.Navigation("JobCardUpdatedUser");

                    b.Navigation("VehicleDetails");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.Pre_Invoice", b =>
                {
                    b.HasOne("VimalJagruti.Domain.Entity.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VimalJagruti.Domain.Entity.JobCard", "JobCard")
                        .WithMany()
                        .HasForeignKey("JobCardIdFK_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("JobCard");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.Product", b =>
                {
                    b.HasOne("VimalJagruti.Domain.Entity.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.ProductQuantityManagement", b =>
                {
                    b.HasOne("VimalJagruti.Domain.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("VimalJagruti.Domain.Entity.VehicleDetails", b =>
                {
                    b.HasOne("VimalJagruti.Domain.Entity.VehicleOwnerDetails", "VehicleOwner")
                        .WithMany()
                        .HasForeignKey("VehicleOwnerId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleOwner");
                });
#pragma warning restore 612, 618
        }
    }
}
