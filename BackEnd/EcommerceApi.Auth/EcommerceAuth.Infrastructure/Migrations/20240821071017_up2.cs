using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceAuth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class up2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "subscriptionType",
                table: "profiles",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "paymentStatus",
                table: "profiles",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "paymentOption",
                table: "profiles",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "age",
                table: "profiles",
                newName: "subscriptionType");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "profiles",
                newName: "paymentStatus");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "profiles",
                newName: "paymentOption");
        }
    }
}
