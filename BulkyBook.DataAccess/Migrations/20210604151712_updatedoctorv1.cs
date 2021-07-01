using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyBook.DataAccess.Migrations
{
    public partial class updatedoctorv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthcareDoctor_Languages_LanguageId",
                table: "HealthcareDoctor");

            migrationBuilder.DropIndex(
                name: "IX_HealthcareDoctor_LanguageId",
                table: "HealthcareDoctor");

            migrationBuilder.AlterColumn<string>(
                name: "LanguageId",
                table: "HealthcareDoctor",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "HealthcareDoctor",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HealthcareDoctor_LanguageId",
                table: "HealthcareDoctor",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthcareDoctor_Languages_LanguageId",
                table: "HealthcareDoctor",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
