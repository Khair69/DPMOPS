using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPMOPS.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CitizrnId",
                table: "RequestFollowers",
                newName: "CitizenId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestFollowers_CitizrnId_ServiceRequestId",
                table: "RequestFollowers",
                newName: "IX_RequestFollowers_CitizenId_ServiceRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CitizenId",
                table: "RequestFollowers",
                newName: "CitizrnId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestFollowers_CitizenId_ServiceRequestId",
                table: "RequestFollowers",
                newName: "IX_RequestFollowers_CitizrnId_ServiceRequestId");
        }
    }
}
