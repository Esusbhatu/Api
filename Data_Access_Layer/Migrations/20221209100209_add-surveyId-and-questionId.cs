using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class addsurveyIdandquestionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choice_Question_QuestionModelId",
                table: "Choice");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Survey_SurveyModelId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_SurveyModelId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Choice_QuestionModelId",
                table: "Choice");

            migrationBuilder.DropColumn(
                name: "SurveyModelId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuestionModelId",
                table: "Choice");

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "Question",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Choice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Question_SurveyId",
                table: "Question",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Choice_QuestionId",
                table: "Choice",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_Question_QuestionId",
                table: "Choice",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Survey_SurveyId",
                table: "Question",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choice_Question_QuestionId",
                table: "Choice");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Survey_SurveyId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_SurveyId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Choice_QuestionId",
                table: "Choice");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Choice");

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyModelId",
                table: "Question",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionModelId",
                table: "Choice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_SurveyModelId",
                table: "Question",
                column: "SurveyModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Choice_QuestionModelId",
                table: "Choice",
                column: "QuestionModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_Question_QuestionModelId",
                table: "Choice",
                column: "QuestionModelId",
                principalTable: "Question",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Survey_SurveyModelId",
                table: "Question",
                column: "SurveyModelId",
                principalTable: "Survey",
                principalColumn: "Id");
        }
    }
}
