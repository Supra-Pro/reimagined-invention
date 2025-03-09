using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixFeePaymentStudentInitialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeePayements_Students_StudentId",
                table: "FeePayements");

            migrationBuilder.DropIndex(
                name: "IX_FeePayements_StudentId",
                table: "FeePayements");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FeePayements_StudentId",
                table: "FeePayements",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeePayements_Students_StudentId",
                table: "FeePayements",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
