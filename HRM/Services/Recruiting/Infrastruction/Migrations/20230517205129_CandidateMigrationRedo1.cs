using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastruction.Migrations
{
    /// <inheritdoc />
    public partial class CandidateMigrationRedo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Candidates_CandidateId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Jobs_JobId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_CandidateId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_JobId",
                table: "Submissions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Submissions_CandidateId",
                table: "Submissions",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_JobId",
                table: "Submissions",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Candidates_CandidateId",
                table: "Submissions",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Jobs_JobId",
                table: "Submissions",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
