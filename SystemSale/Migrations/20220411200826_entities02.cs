using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemSale.Migrations
{
    public partial class entities02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Venda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Venda",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
