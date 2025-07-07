using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPMOPS.Data.Migrations
{
    /// <inheritdoc />
    public partial class BugFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestFollowers_AspNetUsers_UserId",
                table: "RequestFollowers");

            migrationBuilder.DropIndex(
                name: "IX_RequestFollowers_UserId",
                table: "RequestFollowers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RequestFollowers");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestFollowers_AspNetUsers_CitizenId",
                table: "RequestFollowers",
                column: "CitizenId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestFollowers_AspNetUsers_CitizenId",
                table: "RequestFollowers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RequestFollowers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestFollowers_UserId",
                table: "RequestFollowers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestFollowers_AspNetUsers_UserId",
                table: "RequestFollowers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
