using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFQuerySample.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeachersId",
                table: "CourseTeachers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeachersId",
                table: "CourseTeachers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
