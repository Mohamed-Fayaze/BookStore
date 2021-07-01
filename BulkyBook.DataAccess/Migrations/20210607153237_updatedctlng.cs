using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyBook.DataAccess.Migrations
{
    public partial class updatedctlng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DoctorLanguage");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "DoctorLanguage",
                maxLength: 30,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLanguage_LanguageId",
                table: "DoctorLanguage",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorLanguage_Languages_LanguageId",
                table: "DoctorLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorLanguage_Languages_LanguageId",
                table: "DoctorLanguage");

            migrationBuilder.DropIndex(
                name: "IX_DoctorLanguage_LanguageId",
                table: "DoctorLanguage");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "DoctorLanguage");

            migrationBuilder.AddColumn<int>(
                name: "Description",
                table: "DoctorLanguage",
                type: "int",
                maxLength: 30,
                nullable: false,
                defaultValue: 0);
        }
    }
}
