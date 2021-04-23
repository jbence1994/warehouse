using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Migrations
{
    public partial class SeedTechnicianBalanceTableAndTechnicianBalanceSummaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO technician_balances (technician_id, amount, created_at) VALUES ((SELECT id FROM technicians WHERE last_name = 'Papp'), 0, CURRENT_TIMESTAMP());");
            migrationBuilder.Sql("INSERT INTO technician_balances (technician_id, amount, created_at) VALUES ((SELECT id FROM technicians WHERE last_name = 'Ádók'), 0, CURRENT_TIMESTAMP());");
            migrationBuilder.Sql("INSERT INTO technician_balances (technician_id, amount, created_at) VALUES ((SELECT id FROM technicians WHERE last_name = 'Lengyel'), 0, CURRENT_TIMESTAMP());");

            migrationBuilder.Sql("INSERT INTO technician_balance_summary (technician_id, amount) VALUES ((SELECT id FROM technicians WHERE last_name = 'Papp'), 0);");
            migrationBuilder.Sql("INSERT INTO technician_balance_summary (technician_id, amount) VALUES ((SELECT id FROM technicians WHERE last_name = 'Ádók'), 0);");
            migrationBuilder.Sql("INSERT INTO technician_balance_summary (technician_id, amount) VALUES ((SELECT id FROM technicians WHERE last_name = 'Lengyel'), 0);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM technician_balances;");

            migrationBuilder.Sql("DELETE FROM technician_balance_summary;");
        }
    }
}
