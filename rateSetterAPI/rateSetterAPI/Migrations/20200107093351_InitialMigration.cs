using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rateSetterAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanItem",
                columns: table => new
                {
                    LoanId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmount = table.Column<float>(nullable: false),
                    LoanName = table.Column<string>(nullable: true),
                    LoanStatus = table.Column<string>(nullable: true),
                    RequestedBy = table.Column<string>(nullable: true),
                    FundedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    RequestedAt = table.Column<DateTime>(nullable: false),
                    FundedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanItem", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "LoginItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanItem");

            migrationBuilder.DropTable(
                name: "LoginItem");
        }
    }
}
