using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Migrations
{
    public partial class CreateOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO orders (technician_id, total, created_at) VALUES (1, 20000, CURRENT_TIMESTAMP());");

            migrationBuilder.Sql(
                "INSERT INTO order_details (order_id, product_id, quantity, sub_total) VALUES ((SELECT id FROM orders WHERE total = 20000), (SELECT id FROM products WHERE name = 'Antennatartó konzol'), 2, 20000);");

            migrationBuilder.Sql(
                "INSERT INTO technician_balance_entries (technician_id, amount, created_at) VALUES ((SELECT id FROM technicians WHERE first_name = 'László' AND last_name = 'Papp'), -20000, CURRENT_TIMESTAMP());");

            migrationBuilder.Sql(
                "UPDATE technicians SET balance = -20000 WHERE first_name = 'László' AND last_name = 'Papp';");

            migrationBuilder.Sql(
                "UPDATE stocks SET quantity = 398 WHERE product_id = (SELECT id FROM products WHERE name = 'Antennatartó konzol');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE stocks SET quantity = 400 WHERE product_id = (SELECT id FROM products WHERE name = 'Antennatartó konzol');");

            migrationBuilder.Sql(
                "UPDATE technicians SET balance = 0 WHERE first_name = 'László' AND last_name = 'Papp';");

            migrationBuilder.Sql("DELETE FROM technician_balance_entries;");

            migrationBuilder.Sql("DELETE FROM order_details;");

            migrationBuilder.Sql("DELETE FROM orders;");
        }
    }
}
