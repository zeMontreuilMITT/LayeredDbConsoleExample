using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LayeredDbConsole.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    RegistrationNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.RegistrationNumber);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    RegistrationNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicenceNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Colour = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.RegistrationNumber);
                });

            migrationBuilder.CreateTable(
                name: "Leases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleRegistrationNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerRegistrationNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leases_Customers_CustomerRegistrationNumber",
                        column: x => x.CustomerRegistrationNumber,
                        principalTable: "Customers",
                        principalColumn: "RegistrationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leases_Vehicles_VehicleRegistrationNumber",
                        column: x => x.VehicleRegistrationNumber,
                        principalTable: "Vehicles",
                        principalColumn: "RegistrationNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leases_CustomerRegistrationNumber",
                table: "Leases",
                column: "CustomerRegistrationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_VehicleRegistrationNumber",
                table: "Leases",
                column: "VehicleRegistrationNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leases");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
