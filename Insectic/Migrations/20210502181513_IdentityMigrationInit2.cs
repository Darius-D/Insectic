using Microsoft.EntityFrameworkCore.Migrations;

namespace Insectic.Migrations
{
    public partial class IdentityMigrationInit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResourceGroup",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRoles",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResourceGroup",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserRoles",
                table: "AspNetUsers");
        }
    }
}
