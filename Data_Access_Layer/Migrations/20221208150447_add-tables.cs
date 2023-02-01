using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class addtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChoiceModel");

            migrationBuilder.DropTable(
                name: "QuestionModel");

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    SurveyModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Survey_SurveyModelId",
                        column: x => x.SurveyModelId,
                        principalTable: "Survey",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Choice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Choice = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    QuestionModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choice_Question_QuestionModelId",
                        column: x => x.QuestionModelId,
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Survey_CreateDate",
                table: "Survey",
                column: "CreateDate");

            migrationBuilder.CreateIndex(
                name: "IX_Choice_Index",
                table: "Choice",
                column: "Index");

            migrationBuilder.CreateIndex(
                name: "IX_Choice_QuestionModelId",
                table: "Choice",
                column: "QuestionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Index",
                table: "Question",
                column: "Index");

            migrationBuilder.CreateIndex(
                name: "IX_Question_SurveyModelId",
                table: "Question",
                column: "SurveyModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Survey_CreateDate",
                table: "Survey");

            migrationBuilder.CreateTable(
                name: "QuestionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    SurveyModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionModel_Survey_SurveyModelId",
                        column: x => x.SurveyModelId,
                        principalTable: "Survey",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChoiceModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Choice = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    QuestionModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChoiceModel_QuestionModel_QuestionModelId",
                        column: x => x.QuestionModelId,
                        principalTable: "QuestionModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceModel_QuestionModelId",
                table: "ChoiceModel",
                column: "QuestionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionModel_Index",
                table: "QuestionModel",
                column: "Index");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionModel_SurveyModelId",
                table: "QuestionModel",
                column: "SurveyModelId");
        }
    }
}
