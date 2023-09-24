using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace internTask.DAL.AppContext.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramBenefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramStart = table.Column<DateOnly>(type: "date", nullable: false),
                    ApplicationOpen = table.Column<DateOnly>(type: "date", nullable: false),
                    ApplicationClose = table.Column<DateOnly>(type: "date", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    MinQualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxNumOfApplication = table.Column<int>(type: "int", nullable: false),
                    Location_programLocation = table.Column<int>(type: "int", nullable: true),
                    Location_OnSightLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    CurrentResidence = table.Column<int>(type: "int", nullable: false),
                    IdNumber = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationForms_ProgramModels_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "ProgramModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramSkills",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramSkills", x => new { x.ProgramId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_ProgramSkills_ProgramModels_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "ProgramModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    QuestionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_ApplicationForms_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "ApplicationForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DropdownQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropdownQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DropdownQuestion_Question_Id",
                        column: x => x.Id,
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestion_Question_Id",
                        column: x => x.Id,
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParagraghQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParagraghQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParagraghQuestion_Question_Id",
                        column: x => x.Id,
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "YesNoQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YesNoQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YesNoQuestion_Question_Id",
                        column: x => x.Id,
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionChoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Choice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    DropdownQuestionId = table.Column<int>(type: "int", nullable: true),
                    MultipleChoiceQuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionChoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionChoice_DropdownQuestion_DropdownQuestionId",
                        column: x => x.DropdownQuestionId,
                        principalTable: "DropdownQuestion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestionChoice_MultipleChoiceQuestion_MultipleChoiceQuestionId",
                        column: x => x.MultipleChoiceQuestionId,
                        principalTable: "MultipleChoiceQuestion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForms_ProgramId",
                table: "ApplicationForms",
                column: "ProgramId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramSkills_SkillId",
                table: "ProgramSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ApplicationId",
                table: "Question",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionChoice_DropdownQuestionId",
                table: "QuestionChoice",
                column: "DropdownQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionChoice_MultipleChoiceQuestionId",
                table: "QuestionChoice",
                column: "MultipleChoiceQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParagraghQuestion");

            migrationBuilder.DropTable(
                name: "ProgramSkills");

            migrationBuilder.DropTable(
                name: "QuestionChoice");

            migrationBuilder.DropTable(
                name: "YesNoQuestion");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "DropdownQuestion");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestion");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "ApplicationForms");

            migrationBuilder.DropTable(
                name: "ProgramModels");
        }
    }
}
