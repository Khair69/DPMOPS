using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DPMOPS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Review : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Review",
                table: "ServiceRequests",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "ServiceRequests");
        }
    }
}
