using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPMOPS.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_ServiceTypes_ServiceTypeId",
                table: "ServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_Citizens_CitizenId",
                table: "ServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_Districts_DistrictId",
                table: "ServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_ServiceProviders_ServiceProviderId",
                table: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "ReportRequests");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceProviderId",
                table: "ServiceRequests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DistrictId",
                table: "ServiceRequests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CitizenId",
                table: "ServiceRequests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_ServiceTypes_ServiceTypeId",
                table: "ServiceProviders",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_Citizens_CitizenId",
                table: "ServiceRequests",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "CitizenId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_Districts_DistrictId",
                table: "ServiceRequests",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_ServiceProviders_ServiceProviderId",
                table: "ServiceRequests",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "ServiceProviderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_ServiceTypes_ServiceTypeId",
                table: "ServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_Citizens_CitizenId",
                table: "ServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_Districts_DistrictId",
                table: "ServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_ServiceProviders_ServiceProviderId",
                table: "ServiceRequests");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceProviderId",
                table: "ServiceRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DistrictId",
                table: "ServiceRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CitizenId",
                table: "ServiceRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ReportRequests",
                columns: table => new
                {
                    ReportRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CitizenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRequests", x => x.ReportRequestId);
                    table.ForeignKey(
                        name: "FK_ReportRequests_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "CitizenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportRequests_Districts_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportRequests_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "ServiceProviderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequests_CitizenId",
                table: "ReportRequests",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequests_ServiceProviderId",
                table: "ReportRequests",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_ServiceTypes_ServiceTypeId",
                table: "ServiceProviders",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_Citizens_CitizenId",
                table: "ServiceRequests",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "CitizenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_Districts_DistrictId",
                table: "ServiceRequests",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_ServiceProviders_ServiceProviderId",
                table: "ServiceRequests",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "ServiceProviderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
