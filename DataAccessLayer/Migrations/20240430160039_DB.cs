using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyPlans_Subjects_SubjectId",
                table: "DailyPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyPlans_WeeklyPlans_WeeklyPlanId",
                table: "DailyPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyPlans_Subjects_SubjectId",
                table: "WeeklyPlans");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyPlans_SubjectId",
                table: "WeeklyPlans");

            migrationBuilder.DropIndex(
                name: "IX_DailyPlans_SubjectId",
                table: "DailyPlans");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "WeeklyPlans");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "DailyPlans");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "DailyPlans");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Certificates",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "ClassroomId",
                table: "WeeklyPlans",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WeeklyPlanId",
                table: "DailyPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificates",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_Topics_DailyPlans_DailyPlanId",
                        column: x => x.DailyPlanId,
                        principalTable: "DailyPlans",
                        principalColumn: "DailyPlanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlans_ClassroomId",
                table: "WeeklyPlans",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_DailyPlanId",
                table: "Topics",
                column: "DailyPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyPlans_WeeklyPlans_WeeklyPlanId",
                table: "DailyPlans",
                column: "WeeklyPlanId",
                principalTable: "WeeklyPlans",
                principalColumn: "WeeklyPlanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyPlans_Classrooms_ClassroomId",
                table: "WeeklyPlans",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "ClassroomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyPlans_WeeklyPlans_WeeklyPlanId",
                table: "DailyPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyPlans_Classrooms_ClassroomId",
                table: "WeeklyPlans");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyPlans_ClassroomId",
                table: "WeeklyPlans");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "WeeklyPlans");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Certificates",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "WeeklyPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WeeklyPlanId",
                table: "DailyPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "DailyPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "DailyPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "IssueDate",
                table: "Certificates",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlans_SubjectId",
                table: "WeeklyPlans",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlans_SubjectId",
                table: "DailyPlans",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyPlans_Subjects_SubjectId",
                table: "DailyPlans",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyPlans_WeeklyPlans_WeeklyPlanId",
                table: "DailyPlans",
                column: "WeeklyPlanId",
                principalTable: "WeeklyPlans",
                principalColumn: "WeeklyPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyPlans_Subjects_SubjectId",
                table: "WeeklyPlans",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
