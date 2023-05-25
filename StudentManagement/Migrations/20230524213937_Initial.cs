using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table =>
                    new
                    {
                        GroupCode = table.Column<string>(type: "TEXT", nullable: false),
                        Grade = table.Column<int>(type: "INTEGER", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupCode);
                }
            );

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table =>
                    new
                    {
                        Teacherid = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        FirstName = table.Column<string>(
                            type: "TEXT",
                            maxLength: 50,
                            nullable: false
                        ),
                        LastName = table.Column<string>(
                            type: "TEXT",
                            maxLength: 50,
                            nullable: false
                        ),
                        Subject = table.Column<int>(type: "INTEGER", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Teacherid);
                }
            );

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table =>
                    new
                    {
                        UserId = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        Username = table.Column<string>(type: "TEXT", nullable: false),
                        Password = table.Column<string>(type: "TEXT", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                }
            );

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table =>
                    new
                    {
                        StudentId = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        FirstName = table.Column<string>(
                            type: "TEXT",
                            maxLength: 50,
                            nullable: false
                        ),
                        LastName = table.Column<string>(
                            type: "TEXT",
                            maxLength: 50,
                            nullable: false
                        ),
                        BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                        Gender = table.Column<int>(type: "INTEGER", nullable: false),
                        GroupCode = table.Column<string>(type: "TEXT", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupCode",
                        column: x => x.GroupCode,
                        principalTable: "Groups",
                        principalColumn: "GroupCode",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table =>
                    new
                    {
                        CourseCode = table.Column<string>(type: "TEXT", nullable: false),
                        Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                        Teacherid = table.Column<int>(type: "INTEGER", nullable: false),
                        GroupCode = table.Column<string>(type: "TEXT", nullable: false),
                        StudentId = table.Column<int>(type: "INTEGER", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseCode);
                    table.ForeignKey(
                        name: "FK_Courses_Groups_GroupCode",
                        column: x => x.GroupCode,
                        principalTable: "Groups",
                        principalColumn: "GroupCode",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Courses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId"
                    );
                    table.ForeignKey(
                        name: "FK_Courses_Teacher_Teacherid",
                        column: x => x.Teacherid,
                        principalTable: "Teacher",
                        principalColumn: "Teacherid",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table =>
                    new
                    {
                        AbsenceId = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                        CourseCode = table.Column<string>(type: "TEXT", nullable: false),
                        Date = table.Column<DateOnly>(type: "TEXT", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.AbsenceId);
                    table.ForeignKey(
                        name: "FK_Absences_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Absences_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table =>
                    new
                    {
                        MarkId = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                        CourseCode = table.Column<string>(type: "TEXT", nullable: false),
                        Value = table.Column<int>(type: "INTEGER", nullable: false),
                        DateReceived = table.Column<DateOnly>(type: "TEXT", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.MarkId);
                    table.ForeignKey(
                        name: "FK_Marks_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Marks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Absences_CourseCode",
                table: "Absences",
                column: "CourseCode"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Absences_StudentId",
                table: "Absences",
                column: "StudentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Courses_GroupCode",
                table: "Courses",
                column: "GroupCode"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentId",
                table: "Courses",
                column: "StudentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Teacherid",
                table: "Courses",
                column: "Teacherid"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Marks_CourseCode",
                table: "Marks",
                column: "CourseCode"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Marks_StudentId",
                table: "Marks",
                column: "StudentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupCode",
                table: "Students",
                column: "GroupCode"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Absences");

            migrationBuilder.DropTable(name: "Marks");

            migrationBuilder.DropTable(name: "Users");

            migrationBuilder.DropTable(name: "Courses");

            migrationBuilder.DropTable(name: "Students");

            migrationBuilder.DropTable(name: "Teacher");

            migrationBuilder.DropTable(name: "Groups");
        }
    }
}
