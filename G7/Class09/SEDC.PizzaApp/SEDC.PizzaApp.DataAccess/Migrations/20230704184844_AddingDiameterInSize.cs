using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEDC.PizzaApp.DataAccess.Migrations
{
    public partial class AddingDiameterInSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Diameter",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diameter",
                table: "Sizes");
        }
    }
}
