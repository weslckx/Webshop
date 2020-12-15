using Microsoft.EntityFrameworkCore.Migrations;

namespace Webshop.Data.Migrations
{
    public partial class AddedRequirementsToProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Prijs");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Productnaam");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "Link naar afbeelding");

            migrationBuilder.RenameColumn(
                name: "DescriptionShort",
                table: "Products",
                newName: "Korte omschrijving");

            migrationBuilder.RenameColumn(
                name: "DescriptionLong",
                table: "Products",
                newName: "Omschrijving");

            migrationBuilder.AlterColumn<decimal>(
                name: "Prijs",
                table: "Products",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Productnaam",
                table: "Products",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Korte omschrijving",
                table: "Products",
                maxLength: 550,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prijs",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Productnaam",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Link naar afbeelding",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "Korte omschrijving",
                table: "Products",
                newName: "DescriptionShort");

            migrationBuilder.RenameColumn(
                name: "Omschrijving",
                table: "Products",
                newName: "DescriptionLong");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionShort",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 550);
        }
    }
}
