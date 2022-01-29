using Microsoft.EntityFrameworkCore.Migrations;

namespace VimalJagruti.Repo.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RunningKM",
                table: "VehicleDetails");

            migrationBuilder.AddColumn<int>(
                name: "FuelLevel",
                table: "JobCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "JobCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RunningKM",
                table: "JobCards",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelLevel",
                table: "JobCards");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "JobCards");

            migrationBuilder.DropColumn(
                name: "RunningKM",
                table: "JobCards");

            migrationBuilder.AddColumn<string>(
                name: "RunningKM",
                table: "VehicleDetails",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
