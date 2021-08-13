using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Migrations
{
    public partial class SeedStocksAndStockEntriesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO stock_entries (product_id, quantity, created_at) VALUES ((SELECT id FROM products WHERE name = 'Antennatartó konzol'), 100, CURRENT_TIMESTAMP());");
            migrationBuilder.Sql(
                "INSERT INTO stock_entries (product_id, quantity, created_at) VALUES ((SELECT id FROM products WHERE name = 'Vörösréz'), 200, CURRENT_TIMESTAMP());");
            migrationBuilder.Sql(
                "INSERT INTO stock_entries (product_id, quantity, created_at) VALUES ((SELECT id FROM products WHERE name = 'Antennatartó konzol'), 300, CURRENT_TIMESTAMP());");
            migrationBuilder.Sql(
                "INSERT INTO stock_entries (product_id, quantity, created_at) VALUES ((SELECT id FROM products WHERE name = '6-os anyacsavar'), 400, CURRENT_TIMESTAMP());");
            migrationBuilder.Sql(
                "INSERT INTO stock_entries (product_id, quantity, created_at) VALUES ((SELECT id FROM products WHERE name = 'Vörösréz'), 500, CURRENT_TIMESTAMP());");
            migrationBuilder.Sql(
                "INSERT INTO stock_entries (product_id, quantity, created_at) VALUES ((SELECT id FROM products WHERE name = '6-os anyacsavar'), 600, CURRENT_TIMESTAMP());");

            migrationBuilder.Sql(
                "INSERT INTO stocks (product_id, quantity) VALUES ((SELECT id FROM products WHERE name = 'Antennatartó konzol'), '400');");
            migrationBuilder.Sql(
                "INSERT INTO stocks (product_id, quantity) VALUES ((SELECT id FROM products WHERE name = 'Vörösréz'), '700');");
            migrationBuilder.Sql(
                "INSERT INTO stocks (product_id, quantity) VALUES ((SELECT id FROM products WHERE name = '6-os anyacsavar'), '1000');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM stocks;");
            migrationBuilder.Sql("DELETE FROM stock_entries;");
        }
    }
}
