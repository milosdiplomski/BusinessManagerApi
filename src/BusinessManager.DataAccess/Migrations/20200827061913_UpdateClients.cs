using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessManager.DataAccess.Migrations
{
    public partial class UpdateClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Clients",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Clients");
        }
    }
}
