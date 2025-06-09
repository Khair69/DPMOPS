using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPMOPS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentAdv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appointments_ServiceRequestId",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceRequestId",
                table: "Appointments",
                column: "ServiceRequestId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appointments_ServiceRequestId",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceRequestId",
                table: "Appointments",
                column: "ServiceRequestId");
        }
    }
}
