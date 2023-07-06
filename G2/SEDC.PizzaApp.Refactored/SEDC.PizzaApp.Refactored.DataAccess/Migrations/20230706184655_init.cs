using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEDC.PizzaApp.Refactored.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PizzaSize = table.Column<int>(type: "int", nullable: false),
                    IsOnPromotion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    Delivered = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PizzaSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "IsOnPromotion", "Name", "PizzaSize" },
                values: new object[,]
                {
                    { 1, true, "Cappricioza", 0 },
                    { 2, false, "Pepperoni", 0 },
                    { 3, false, "Margarita", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Bob Street 22", "Bob", "Bobsky" },
                    { 2, "Wayne Street 33", "Jill", "Wayne" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Delivered", "Location", "PaymentMethod", "UserId" },
                values: new object[] { 1, true, "Store1", 2, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Delivered", "Location", "PaymentMethod", "UserId" },
                values: new object[] { 2, false, "Store2", 1, 2 });

            migrationBuilder.InsertData(
                table: "PizzaOrder",
                columns: new[] { "Id", "OrderId", "PizzaId", "PizzaSize" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "PizzaOrder",
                columns: new[] { "Id", "OrderId", "PizzaId", "PizzaSize" },
                values: new object[] { 2, 1, 2, 2 });

            migrationBuilder.InsertData(
                table: "PizzaOrder",
                columns: new[] { "Id", "OrderId", "PizzaId", "PizzaSize" },
                values: new object[] { 3, 2, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_OrderId",
                table: "PizzaOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_PizzaId",
                table: "PizzaOrder",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaOrder");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
