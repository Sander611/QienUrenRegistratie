using Microsoft.EntityFrameworkCore.Migrations;

namespace QienHoursRegistration.Migrations
{
    public partial class hoursformLock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "HoursForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "HoursForm",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "HoursForm");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "HoursForm");
        }
    }
}
