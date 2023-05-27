using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class make_course_groups_1tom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Groups_GroupCode",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_GroupCode",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "GroupCode",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Groups",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseCode",
                table: "Groups",
                column: "CourseCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Courses_CourseCode",
                table: "Groups",
                column: "CourseCode",
                principalTable: "Courses",
                principalColumn: "CourseCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Courses_CourseCode",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CourseCode",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Groups");

            migrationBuilder.AddColumn<string>(
                name: "GroupCode",
                table: "Courses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_GroupCode",
                table: "Courses",
                column: "GroupCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Groups_GroupCode",
                table: "Courses",
                column: "GroupCode",
                principalTable: "Groups",
                principalColumn: "GroupCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
