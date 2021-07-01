using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyBook.DataAccess.Migrations
{
    public partial class updatestateanddist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "HealthcareBranch");

            migrationBuilder.DropColumn(
                name: "State",
                table: "HealthcareBranch");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "HealthcareBranch",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "HealthcareBranch",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareBranch_DistrictId",
                table: "HealthcareBranch",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareBranch_StateId",
                table: "HealthcareBranch",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthcareBranch_District_DistrictId",
                table: "HealthcareBranch",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthcareBranch_State_StateId",
                table: "HealthcareBranch",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthcareBranch_District_DistrictId",
                table: "HealthcareBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthcareBranch_State_StateId",
                table: "HealthcareBranch");

            migrationBuilder.DropIndex(
                name: "IX_HealthcareBranch_DistrictId",
                table: "HealthcareBranch");

            migrationBuilder.DropIndex(
                name: "IX_HealthcareBranch_StateId",
                table: "HealthcareBranch");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "HealthcareBranch");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "HealthcareBranch");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "HealthcareBranch",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "HealthcareBranch",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);
        }
    }
}
