using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    IdTeam = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Deadline = table.Column<DateTime>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.IdTeam);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    IdTaskType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.IdTaskType);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    IdTeamMember = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.IdTeamMember);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    IdTask = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    IdTeam = table.Column<int>(nullable: false),
                    IdTaskType = table.Column<int>(nullable: false),
                    IdAssignedTo = table.Column<int>(nullable: false),
                    IdCreator = table.Column<int>(nullable: false),
                    TeamMemberIdTeamMember = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.IdTask);
                    table.ForeignKey(
                        name: "FK_Tasks_TeamMembers_IdAssignedTo",
                        column: x => x.IdAssignedTo,
                        principalTable: "TeamMembers",
                        principalColumn: "IdTeamMember",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_TeamMembers_IdCreator",
                        column: x => x.IdCreator,
                        principalTable: "TeamMembers",
                        principalColumn: "IdTeamMember",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTypes_IdTaskType",
                        column: x => x.IdTaskType,
                        principalTable: "TaskTypes",
                        principalColumn: "IdTaskType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Projects",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TeamMembers_TeamMemberIdTeamMember",
                        column: x => x.TeamMemberIdTeamMember,
                        principalTable: "TeamMembers",
                        principalColumn: "IdTeamMember",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "IdTeam", "Deadline", "Name" },
                values: new object[] { 1, new DateTime(2023, 2, 3, 10, 35, 18, 921, DateTimeKind.Local).AddTicks(3762), "project1" });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "IdTaskType", "Name" },
                values: new object[] { 1, "niewiem" });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "IdTeamMember", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "niewiem@gmail.com", "michał", "Kowalski" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "IdTask", "Deadline", "Description", "IdAssignedTo", "IdCreator", "IdTaskType", "IdTeam", "Name", "TeamMemberIdTeamMember" },
                values: new object[] { 1, new DateTime(2023, 2, 3, 10, 35, 18, 934, DateTimeKind.Local).AddTicks(9025), "Opis", 1, 1, 1, 1, "zadanie1", null });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdAssignedTo",
                table: "Tasks",
                column: "IdAssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdCreator",
                table: "Tasks",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdTaskType",
                table: "Tasks",
                column: "IdTaskType");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdTeam",
                table: "Tasks",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TeamMemberIdTeamMember",
                table: "Tasks",
                column: "TeamMemberIdTeamMember");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
