using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QienHoursRegistration.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    HashedPassword = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ZIP = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    IBAN = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ProfileImage = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsTrainee = table.Column<bool>(nullable: false),
                    IsQienEmployee = table.Column<bool>(nullable: false),
                    IsSeniorDeveloper = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
