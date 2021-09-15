using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Migrations
{
    public partial class SeedProductAndSupplierTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO suppliers (name, city, email, phone) VALUES ('Meleghegyi és Tsa. Kft.', 'Szeged', 'info@lezervagas.hu', '+36 20 258 6515');");
            migrationBuilder.Sql("INSERT INTO suppliers (name, city, email, phone) VALUES ('Lipták Fivérek Kft.', 'Békéscsaba', 'liptakfiverek@gmail.com', '+36-66-441-611');");
            migrationBuilder.Sql("INSERT INTO suppliers (name, city, email, phone) VALUES ('Rappai Csavar Kft.', 'Szeged', 'rappai@rappaicsavar.hu', '+36 62 558 778');");

            migrationBuilder.Sql("INSERT INTO products (name, price, unit, supplier_id) VALUES ('Antennatartó konzol', '10000', 'darab', (SELECT id FROM suppliers WHERE name = 'Meleghegyi és Tsa. Kft.'));");
            migrationBuilder.Sql("INSERT INTO products (name, price, unit, supplier_id) VALUES ('Vörösréz', '12000', 'darab', (SELECT id FROM suppliers WHERE name = 'Lipták Fivérek Kft.'));");
            migrationBuilder.Sql("INSERT INTO products (name, price, unit, supplier_id) VALUES ('6-os anyacsavar', '120', 'darab', (SELECT id FROM suppliers WHERE name = 'Rappai Csavar Kft.'));");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM products;");
            migrationBuilder.Sql("DELETE FROM suppliers;");
        }
    }
}
