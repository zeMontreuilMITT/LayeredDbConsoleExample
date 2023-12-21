using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LayeredDbConsole.Data.Migrations
{
    public partial class AddLeaseNav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Leases_VehicleRegistrationNumber",
                table: "Leases");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_VehicleRegistrationNumber",
                table: "Leases",
                column: "VehicleRegistrationNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Leases_VehicleRegistrationNumber",
                table: "Leases");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_VehicleRegistrationNumber",
                table: "Leases",
                column: "VehicleRegistrationNumber");
        }
    }
}
