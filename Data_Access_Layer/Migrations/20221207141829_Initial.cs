using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    id = table.Column<Guid>(name: "_id", type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    owner = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    createDate = table.Column<DateTime>(name: "_createDate", type: "datetime2", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionBaseModel",
                columns: table => new
                {
                    id = table.Column<int>(name: "_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    index = table.Column<int>(name: "_index", type: "int", nullable: false),
                    required = table.Column<bool>(type: "bit", nullable: false),
                    questionText = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    questionType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ServeyModelid = table.Column<Guid>(name: "ServeyModel_id", type: "uniqueidentifier", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ChoiceModel",
                columns: table => new
                {
                    id = table.Column<int>(name: "_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    index = table.Column<int>(name: "_index", type: "int", nullable: false),
                    choice = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    QuestionBaseModelid = table.Column<int>(name: "QuestionBaseModel_id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_ChoiceModel_QuestionBaseModel_QuestionBaseModel_id",
                        column: x => x.QuestionBaseModelid,
                        principalTable: "QuestionBaseModel",
                        principalColumn: "_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceModel_QuestionBaseModel_id",
                table: "ChoiceModel",
                column: "QuestionBaseModel_id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBaseModel__index",
                table: "QuestionBaseModel",
                column: "_index");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBaseModel_ServeyModel_id",
                table: "QuestionBaseModel",
                column: "ServeyModel_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChoiceModel");

            migrationBuilder.DropTable(
                name: "QuestionBaseModel");

            migrationBuilder.DropTable(
                name: "Survey");
        }
    }
}
