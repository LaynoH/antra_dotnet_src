using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInterviewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobStatusLookUps",
                table: "JobStatusLookUps");

            migrationBuilder.RenameTable(
                name: "JobStatusLookUps",
                newName: "InterviewStatusLookUps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewStatusLookUps",
                table: "InterviewStatusLookUps",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewStatusLookUps",
                table: "InterviewStatusLookUps");

            migrationBuilder.RenameTable(
                name: "InterviewStatusLookUps",
                newName: "JobStatusLookUps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobStatusLookUps",
                table: "JobStatusLookUps",
                column: "Id");
        }
    }
}
