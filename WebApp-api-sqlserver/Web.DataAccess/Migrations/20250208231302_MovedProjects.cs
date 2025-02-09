using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Api.Migrations
{
    /// <inheritdoc />
    public partial class MovedProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_CourseAdminestreId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseAdminestreId",
                table: "Courses",
                newName: "CourseAdministratorId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CourseAdminestreId",
                table: "Courses",
                newName: "IX_Courses_CourseAdministratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_CourseAdministratorId",
                table: "Courses",
                column: "CourseAdministratorId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_CourseAdministratorId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseAdministratorId",
                table: "Courses",
                newName: "CourseAdminestreId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CourseAdministratorId",
                table: "Courses",
                newName: "IX_Courses_CourseAdminestreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_CourseAdminestreId",
                table: "Courses",
                column: "CourseAdminestreId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
