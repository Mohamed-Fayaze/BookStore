using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyBook.DataAccess.Migrations
{
    public partial class updateQualification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Qualification",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_CategoryId",
                table: "Qualification",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Qualification_Category_CategoryId",
                table: "Qualification",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Qualification_Category_CategoryId",
                table: "Qualification");

            migrationBuilder.DropIndex(
                name: "IX_Qualification_CategoryId",
                table: "Qualification");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Qualification");
        }
    }
}
