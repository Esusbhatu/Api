using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class removecreatedateandactive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Survey_CreateDate",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Survey");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Survey",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Survey",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "statuses",
                table: "Survey",
                newName: "Status");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Survey",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Survey",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Survey",
                newName: "endDate");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Survey",
                newName: "statuses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "startDate",
                table: "Survey",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Survey",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Survey",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Survey_CreateDate",
                table: "Survey",
                column: "CreateDate");
        }
    }
}
