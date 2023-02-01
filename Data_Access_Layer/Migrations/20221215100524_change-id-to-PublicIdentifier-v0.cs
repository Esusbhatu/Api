using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class changeidtoPublicIdentifierv0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Survey_SurveyId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Survey",
                table: "Survey");

            migrationBuilder.DropIndex(
                name: "IX_Question_SurveyId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Question");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Survey",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "Question",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Survey",
                table: "Survey",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Question_SurveyId",
                table: "Question",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Survey_SurveyId",
                table: "Question",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
