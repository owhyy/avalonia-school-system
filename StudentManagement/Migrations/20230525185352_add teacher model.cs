using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class addteachermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Courses_Teacher_Teacherid", table: "Courses");

            migrationBuilder.DropPrimaryKey(name: "PK_Teacher", table: "Teacher");

            migrationBuilder.RenameTable(name: "Teacher", newName: "Teachers");

            migrationBuilder.RenameColumn(
                name: "Teacherid",
                table: "Courses",
                newName: "TeacherId"
            );

            migrationBuilder.RenameIndex(
                name: "IX_Courses_Teacherid",
                table: "Courses",
                newName: "IX_Courses_TeacherId"
            );

            migrationBuilder.RenameColumn(
                name: "Teacherid",
                table: "Teachers",
                newName: "TeacherId"
            );

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "TeacherId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses"
            );

            migrationBuilder.DropPrimaryKey(name: "PK_Teachers", table: "Teachers");

            migrationBuilder.RenameTable(name: "Teachers", newName: "Teacher");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Courses",
                newName: "Teacherid"
            );

            migrationBuilder.RenameIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                newName: "IX_Courses_Teacherid"
            );

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Teacher",
                newName: "Teacherid"
            );

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Teacherid"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teacher_Teacherid",
                table: "Courses",
                column: "Teacherid",
                principalTable: "Teacher",
                principalColumn: "Teacherid",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
