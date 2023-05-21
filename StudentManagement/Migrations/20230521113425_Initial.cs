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
                name: "Students",
                columns: table =>
                    new
                    {
                        studentId = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        firstName = table.Column<string>(type: "TEXT", nullable: false),
                        lastName = table.Column<string>(type: "TEXT", nullable: false),
                        birthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                        gender = table.Column<int>(type: "INTEGER", nullable: false),
                        grade = table.Column<int>(type: "INTEGER", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentId);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Students");
        }
    }
}
