using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPMOPS.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedComplaints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_AspNetUsers_EmployeeId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_EmployeeId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Complaints");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "Complaints",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_EmployeeId",
                table: "Complaints",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_AspNetUsers_EmployeeId",
                table: "Complaints",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
