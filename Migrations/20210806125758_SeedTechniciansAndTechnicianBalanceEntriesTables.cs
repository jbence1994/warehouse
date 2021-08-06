using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Migrations
{
    public partial class SeedTechniciansAndTechnicianBalanceEntriesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO technicians (first_name, last_name, email, phone, balance) VALUES ('László', 'Papp', 'laszlo.papp@netsurfclub.hu', '06201234567', 0);");
            migrationBuilder.Sql(
                "INSERT INTO technicians (first_name, last_name, email, phone, balance) VALUES ('Róbert', 'Lengyel', 'robert.lengyel@netsurfclub.hu', '06301234567', 0);");
            migrationBuilder.Sql(
                "INSERT INTO technicians (first_name, last_name, email, phone, balance) VALUES ('Alex', 'Ádók', 'alex.adok@netsurfclub.hu', '06701234567', 0);");

            migrationBuilder.Sql(
                "INSERT INTO technician_balance_entries (technician_id, amount, created_at) VALUES ((SELECT id FROM technicians WHERE last_name = 'Papp'), 0, CURRENT_TIMESTAMP());");
            migrationBuilder.Sql(
                "INSERT INTO technician_balance_entries (technician_id, amount, created_at) VALUES ((SELECT id FROM technicians WHERE last_name = 'Ádók'), 0, CURRENT_TIMESTAMP());");
            migrationBuilder.Sql(
                "INSERT INTO technician_balance_entries (technician_id, amount, created_at) VALUES ((SELECT id FROM technicians WHERE last_name = 'Lengyel'), 0, CURRENT_TIMESTAMP());");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM technician_balance_entries;");
            migrationBuilder.Sql("DELETE FROM technicians;");
        }
    }
}
