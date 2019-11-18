using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QienHoursRegistration.Migrations
{
    public partial class newModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Account",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    ClientName1 = table.Column<string>(nullable: false),
                    ClientName2 = table.Column<string>(nullable: true),
                    ClientEmail1 = table.Column<string>(nullable: false),
                    ClientEmail2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "HoursForm",
                columns: table => new
                {
                    FormId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false),
                    DateSend = table.Column<DateTime>(nullable: true),
                    DateDue = table.Column<DateTime>(nullable: true),
                    TotalHours = table.Column<int>(nullable: false),
                    ProjectMonth = table.Column<string>(nullable: true),
                    IsAcceptedClient = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoursForm", x => x.FormId);
                });

            migrationBuilder.CreateTable(
                name: "HoursPerDay",
                columns: table => new
                {
                    HoursPerDayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Month = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    OverTimeHours = table.Column<int>(nullable: false),
                    Training = table.Column<int>(nullable: false),
                    IsLeave = table.Column<bool>(nullable: false),
                    Other = table.Column<string>(nullable: true),
                    Reasoning = table.Column<string>(nullable: true),
                    ProjectDay = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    IsSick = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoursPerDay", x => x.HoursPerDayId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "HoursForm");

            migrationBuilder.DropTable(
                name: "HoursPerDay");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
