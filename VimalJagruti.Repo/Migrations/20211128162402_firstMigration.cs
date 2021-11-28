using Microsoft.EntityFrameworkCore.Migrations;

namespace VimalJagruti.Repo.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RearsideCheckup",
                table: "JobCards",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RearsideCheckup",
                table: "JobCards");
        }
    }
}
