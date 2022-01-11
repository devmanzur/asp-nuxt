using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCart.Infrastructure.Migrations
{
    public partial class UpdatedCartModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_ApplicationUsers_OwnerId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_OwnerId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ReferenceId",
                table: "Carts",
                column: "ReferenceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carts_ReferenceId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_OwnerId",
                table: "Carts",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_ApplicationUsers_OwnerId",
                table: "Carts",
                column: "OwnerId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
