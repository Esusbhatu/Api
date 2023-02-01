using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class namingconvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChoiceModel_QuestionBaseModel_QuestionBaseModel_id",
                table: "ChoiceModel");

            migrationBuilder.DropTable(
                name: "QuestionBaseModel");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Survey",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "owner",
                table: "Survey",
                newName: "Owner");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Survey",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "Survey",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "_createDate",
                table: "Survey",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "Survey",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "choice",
                table: "ChoiceModel",
                newName: "Choice");

            migrationBuilder.RenameColumn(
                name: "_index",
                table: "ChoiceModel",
                newName: "Index");

            migrationBuilder.RenameColumn(
                name: "QuestionBaseModel_id",
                table: "ChoiceModel",
                newName: "QuestionModelId");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "ChoiceModel",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ChoiceModel_QuestionBaseModel_id",
                table: "ChoiceModel",
                newName: "IX_ChoiceModel_QuestionModelId");

            migrationBuilder.CreateTable(
                name: "QuestionModel",
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
                    table.PrimaryKey("PK_QuestionModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionModel_Survey_SurveyModelId",
                        column: x => x.SurveyModelId,
                        principalTable: "Survey",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionModel_Index",
                table: "QuestionModel",
                column: "Index");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionModel_SurveyModelId",
                table: "QuestionModel",
                column: "SurveyModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChoiceModel_QuestionModel_QuestionModelId",
                table: "ChoiceModel",
                column: "QuestionModelId",
                principalTable: "QuestionModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChoiceModel_QuestionModel_QuestionModelId",
                table: "ChoiceModel");

            migrationBuilder.DropTable(
                name: "QuestionModel");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Survey",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Survey",
                newName: "owner");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Survey",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Survey",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Survey",
                newName: "_createDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Survey",
                newName: "_id");

            migrationBuilder.RenameColumn(
                name: "Choice",
                table: "ChoiceModel",
                newName: "choice");

            migrationBuilder.RenameColumn(
                name: "QuestionModelId",
                table: "ChoiceModel",
                newName: "QuestionBaseModel_id");

            migrationBuilder.RenameColumn(
                name: "Index",
                table: "ChoiceModel",
                newName: "_index");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ChoiceModel",
                newName: "_id");

            migrationBuilder.RenameIndex(
                name: "IX_ChoiceModel_QuestionModelId",
                table: "ChoiceModel",
                newName: "IX_ChoiceModel_QuestionBaseModel_id");

            migrationBuilder.CreateTable(
                name: "QuestionBaseModel",
                columns: table => new
                {
                    id = table.Column<int>(name: "_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServeyModelid = table.Column<Guid>(name: "ServeyModel_id", type: "uniqueidentifier", nullable: true),
                    index = table.Column<int>(name: "_index", type: "int", nullable: false),
                    questionText = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    questionType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    required = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionBaseModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_QuestionBaseModel_Survey_ServeyModel_id",
                        column: x => x.ServeyModelid,
                        principalTable: "Survey",
                        principalColumn: "_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBaseModel__index",
                table: "QuestionBaseModel",
                column: "_index");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBaseModel_ServeyModel_id",
                table: "QuestionBaseModel",
                column: "ServeyModel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChoiceModel_QuestionBaseModel_QuestionBaseModel_id",
                table: "ChoiceModel",
                column: "QuestionBaseModel_id",
                principalTable: "QuestionBaseModel",
                principalColumn: "_id");
        }
    }
}
