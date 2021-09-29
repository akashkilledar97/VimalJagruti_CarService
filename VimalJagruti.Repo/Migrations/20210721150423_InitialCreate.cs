using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VimalJagruti.Repo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetAmount = table.Column<double>(type: "float", nullable: false),
                    GSTAmount = table.Column<double>(type: "float", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Roles = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleOwnerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOwnerDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId_FK",
                        column: x => x.CategoryId_FK,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleOwnerId_FK = table.Column<int>(type: "int", nullable: false),
                    FeedbackMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_VehicleOwnerDetails_VehicleOwnerId_FK",
                        column: x => x.VehicleOwnerId_FK,
                        principalTable: "VehicleOwnerDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleOwnerId_FK = table.Column<int>(type: "int", nullable: false),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassisNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EngineNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    RunningKM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VehicleQR = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleDetails_VehicleOwnerDetails_VehicleOwnerId_FK",
                        column: x => x.VehicleOwnerId_FK,
                        principalTable: "VehicleOwnerDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductQuantityManagements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId_FK = table.Column<int>(type: "int", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQuantityManagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductQuantityManagements_Products_ProductId_FK",
                        column: x => x.ProductId_FK,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleDetailsId_FK = table.Column<int>(type: "int", nullable: false),
                    VehicleDentPhotos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatorPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnderChassisCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleDriverCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewEstimatedParts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObservationAndCustomerComplaints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedAmount = table.Column<double>(type: "float", nullable: false),
                    CreatedById_FK = table.Column<int>(type: "int", nullable: false),
                    UpdatedById_FK = table.Column<int>(type: "int", nullable: true),
                    JobCardStatus = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobCards_Users_CreatedById_FK",
                        column: x => x.CreatedById_FK,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCards_Users_UpdatedById_FK",
                        column: x => x.UpdatedById_FK,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobCards_VehicleDetails_VehicleDetailsId_FK",
                        column: x => x.VehicleDetailsId_FK,
                        principalTable: "VehicleDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pre_Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCardIdFK_FK = table.Column<int>(type: "int", nullable: false),
                    InvoiceId_FK = table.Column<int>(type: "int", nullable: false),
                    Particulers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Labours = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pre_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pre_Invoices_Invoices_InvoiceId_FK",
                        column: x => x.InvoiceId_FK,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pre_Invoices_JobCards_JobCardIdFK_FK",
                        column: x => x.JobCardIdFK_FK,
                        principalTable: "JobCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_VehicleOwnerId_FK",
                table: "Feedbacks",
                column: "VehicleOwnerId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_CreatedById_FK",
                table: "JobCards",
                column: "CreatedById_FK");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_UpdatedById_FK",
                table: "JobCards",
                column: "UpdatedById_FK");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_VehicleDetailsId_FK",
                table: "JobCards",
                column: "VehicleDetailsId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Pre_Invoices_InvoiceId_FK",
                table: "Pre_Invoices",
                column: "InvoiceId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Pre_Invoices_JobCardIdFK_FK",
                table: "Pre_Invoices",
                column: "JobCardIdFK_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantityManagements_ProductId_FK",
                table: "ProductQuantityManagements",
                column: "ProductId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId_FK",
                table: "Products",
                column: "CategoryId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetails_VehicleOwnerId_FK",
                table: "VehicleDetails",
                column: "VehicleOwnerId_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Pre_Invoices");

            migrationBuilder.DropTable(
                name: "ProductQuantityManagements");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "JobCards");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VehicleDetails");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "VehicleOwnerDetails");
        }
    }
}
