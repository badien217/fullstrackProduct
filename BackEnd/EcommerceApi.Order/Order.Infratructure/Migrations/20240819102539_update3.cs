using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.Infratructure.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "orderDetail");

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "orderDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "orderDetail");

            migrationBuilder.DropColumn(
                name: "price",
                table: "order");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "orderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
