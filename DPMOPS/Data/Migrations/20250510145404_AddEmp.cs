using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPMOPS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_ServiceProviders_ServiceProviderId",
                table: "ServiceRequests");

            migrationBuilder.RenameColumn(
                name: "ServiceProviderId",
                table: "ServiceRequests",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceRequests_ServiceProviderId",
                table: "ServiceRequests",
                newName: "IX_ServiceRequests_EmployeeId");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "ServiceProviderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AccountId",
                table: "Employees",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ServiceProviderId",
                table: "Employees",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_Employees_EmployeeId",
                table: "ServiceRequests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_Employees_EmployeeId",
                table: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "ServiceRequests",
                newName: "ServiceProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceRequests_EmployeeId",
                table: "ServiceRequests",
                newName: "IX_ServiceRequests_ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_ServiceProviders_ServiceProviderId",
                table: "ServiceRequests",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "ServiceProviderId");
        }
    }
}
