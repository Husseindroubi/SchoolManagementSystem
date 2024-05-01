using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Structure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Classrooms_ClassroomId",
                table: "Homeworks");

            migrationBuilder.DropTable(
                name: "CourseSchedules");

            migrationBuilder.DropTable(
                name: "TeachersSubjects");

            migrationBuilder.DropTable(
                name: "SemesterSubjects");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Homeworks");

            migrationBuilder.RenameColumn(
                name: "InstructorNmae",
                table: "OnlineCourses",
                newName: "InstructorName");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "OnlineCourses",
                newName: "OnlineCourseId");

            migrationBuilder.RenameColumn(
                name: "Availability",
                table: "LibraryBooks",
                newName: "IsAvailable");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "LibraryBooks",
                newName: "LibraryBookId");

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Homeworks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "WeeklyPlans",
                columns: table => new
                {
                    WeeklyPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    WeekStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlans", x => x.WeeklyPlanId);
                    table.ForeignKey(
                        name: "FK_WeeklyPlans_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyPlans",
                columns: table => new
                {
                    DailyPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    WeeklyPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyPlans", x => x.DailyPlanId);
                    table.ForeignKey(
                        name: "FK_DailyPlans_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyPlans_WeeklyPlans_WeeklyPlanId",
                        column: x => x.WeeklyPlanId,
                        principalTable: "WeeklyPlans",
                        principalColumn: "WeeklyPlanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlans_SubjectId",
                table: "DailyPlans",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlans_WeeklyPlanId",
                table: "DailyPlans",
                column: "WeeklyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlans_SubjectId",
                table: "WeeklyPlans",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Classrooms_ClassroomId",
                table: "Homeworks",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Classrooms_ClassroomId",
                table: "Homeworks");

            migrationBuilder.DropTable(
                name: "DailyPlans");

            migrationBuilder.DropTable(
                name: "WeeklyPlans");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "InstructorName",
                table: "OnlineCourses",
                newName: "InstructorNmae");

            migrationBuilder.RenameColumn(
                name: "OnlineCourseId",
                table: "OnlineCourses",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "LibraryBooks",
                newName: "Availability");

            migrationBuilder.RenameColumn(
                name: "LibraryBookId",
                table: "LibraryBooks",
                newName: "BookId");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Homeworks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Homeworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SemesterSubjects",
                columns: table => new
                {
                    SemesterSubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterSubjects", x => x.SemesterSubjectId);
                    table.ForeignKey(
                        name: "FK_SemesterSubjects_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "ClassroomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemesterSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachersSubjects",
                columns: table => new
                {
                    TeacherSubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersSubjects", x => x.TeacherSubjectId);
                    table.ForeignKey(
                        name: "FK_TeachersSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSchedules",
                columns: table => new
                {
                    CourseScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterSubjectId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    From = table.Column<TimeOnly>(type: "time", nullable: false),
                    To = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSchedules", x => x.CourseScheduleId);
                    table.ForeignKey(
                        name: "FK_CourseSchedules_SemesterSubjects_SemesterSubjectId",
                        column: x => x.SemesterSubjectId,
                        principalTable: "SemesterSubjects",
                        principalColumn: "SemesterSubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedules_SemesterSubjectId",
                table: "CourseSchedules",
                column: "SemesterSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterSubjects_ClassroomId",
                table: "SemesterSubjects",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterSubjects_SubjectId",
                table: "SemesterSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersSubjects_SubjectId",
                table: "TeachersSubjects",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Classrooms_ClassroomId",
                table: "Homeworks",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "ClassroomId");
        }
    }
}
