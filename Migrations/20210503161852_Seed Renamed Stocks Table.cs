using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Migrations
{
    public partial class SeedRenamedStocksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO stocks (product_id, quantity) VALUES ((SELECT id FROM products WHERE name = 'Antennatartó konzol'), '400');");
            migrationBuilder.Sql("INSERT INTO stocks (product_id, quantity) VALUES ((SELECT id FROM products WHERE name = 'Vörösréz'), '700');");
            migrationBuilder.Sql("INSERT INTO stocks (product_id, quantity) VALUES ((SELECT id FROM products WHERE name = '6-os anyacsavar'), '1000');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM stocks;");
        }
    }
}
