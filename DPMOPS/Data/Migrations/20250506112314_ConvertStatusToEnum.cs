using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DPMOPS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConvertStatusToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. First drop foreign key constraints
            migrationBuilder.DropForeignKey(
                name: "FK_ReportRequests_Districts_ServiceProviderId",
                table: "ReportRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportRequests_Statuss_StatusId",
                table: "ReportRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_Statuss_StatusId",
                table: "ServiceRequests");

            // 2. Drop the indexes first (this is what was missing)
            migrationBuilder.DropIndex(
                name: "IX_ServiceRequests_StatusId",
                table: "ServiceRequests");

            migrationBuilder.DropIndex(
                name: "IX_ReportRequests_StatusId",
                table: "ReportRequests");

            // 3. Create temporary columns
            migrationBuilder.AddColumn<int>(
                name: "StatusIdTemp",
                table: "ServiceRequests",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "StatusIdTemp",
                table: "ReportRequests",
                nullable: false,
                defaultValue: 1);

            // 4. Convert data
            migrationBuilder.Sql(@"
        UPDATE ServiceRequests
        SET StatusIdTemp = CASE 
            WHEN StatusId = 'aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa' THEN 1
            WHEN StatusId = 'bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb' THEN 2
            WHEN StatusId = 'cccccccc-3333-cccc-3333-cccccccccccc' THEN 3
            WHEN StatusId = 'dddddddd-4444-dddd-4444-dddddddddddd' THEN 4
            WHEN StatusId = 'eeeeeeee-5555-eeee-5555-eeeeeeeeeeee' THEN 5
            WHEN StatusId = 'ffffffff-6666-ffff-6666-ffffffffffff' THEN 6
            ELSE 1
        END");

            migrationBuilder.Sql(@"
        UPDATE ReportRequests
        SET StatusIdTemp = CASE 
            WHEN StatusId = 'aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa' THEN 1
            WHEN StatusId = 'bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb' THEN 2
            WHEN StatusId = 'cccccccc-3333-cccc-3333-cccccccccccc' THEN 3
            WHEN StatusId = 'dddddddd-4444-dddd-4444-dddddddddddd' THEN 4
            WHEN StatusId = 'eeeeeeee-5555-eeee-5555-eeeeeeeeeeee' THEN 5
            WHEN StatusId = 'ffffffff-6666-ffff-6666-ffffffffffff' THEN 6
            ELSE 1
        END");

            // 5. Now drop the old columns
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ReportRequests");

            // 6. Rename the temporary columns
            migrationBuilder.RenameColumn(
                name: "StatusIdTemp",
                table: "ServiceRequests",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "StatusIdTemp",
                table: "ReportRequests",
                newName: "StatusId");

            // 7. Drop the old Status table
            migrationBuilder.DropTable(
                name: "Statuss");

            // 8. Fix ServiceProviderId columns
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
                name: "ServiceProviderId",
                table: "ReportRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            // 9. Recreate foreign key
            migrationBuilder.AddForeignKey(
                name: "FK_ReportRequests_Districts_ServiceProviderId",
                table: "ReportRequests",
                column: "ServiceProviderId",
                principalTable: "Districts",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);
        }        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportRequests_Districts_ServiceProviderId",
                table: "ReportRequests");

            migrationBuilder.AlterColumn<Guid>(
                name: "StatusId",
                table: "ServiceRequests",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceProviderId",
                table: "ServiceRequests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "StatusId",
                table: "ReportRequests",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceProviderId",
                table: "ReportRequests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "Statuss",
                columns: table => new
                {
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuss", x => x.StatusId);
                });

            migrationBuilder.InsertData(
                table: "Statuss",
                columns: new[] { "StatusId", "State" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa"), "Pending" },
                    { new Guid("bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb"), "Approved" },
                    { new Guid("cccccccc-3333-cccc-3333-cccccccccccc"), "InProgress" },
                    { new Guid("dddddddd-4444-dddd-4444-dddddddddddd"), "Suspended" },
                    { new Guid("eeeeeeee-5555-eeee-5555-eeeeeeeeeeee"), "Rejected" },
                    { new Guid("ffffffff-6666-ffff-6666-ffffffffffff"), "Completed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_StatusId",
                table: "ServiceRequests",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequests_StatusId",
                table: "ReportRequests",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportRequests_Districts_ServiceProviderId",
                table: "ReportRequests",
                column: "ServiceProviderId",
                principalTable: "Districts",
                principalColumn: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportRequests_Statuss_StatusId",
                table: "ReportRequests",
                column: "StatusId",
                principalTable: "Statuss",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_Statuss_StatusId",
                table: "ServiceRequests",
                column: "StatusId",
                principalTable: "Statuss",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
