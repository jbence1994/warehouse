using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Warehouse.Migrations
{
    public partial class CreateTechnicianBalanceTableAndTechnicianBalanceSummaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "technician_balance_summary",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    technician_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technician_balance_summary", x => x.id);
                    table.ForeignKey(
                        name: "FK_technician_balance_summary_technicians_technician_id",
                        column: x => x.technician_id,
                        principalTable: "technicians",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "technician_balances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    technician_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<double>(type: "double", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technician_balances", x => x.id);
                    table.ForeignKey(
                        name: "FK_technician_balances_technicians_technician_id",
                        column: x => x.technician_id,
                        principalTable: "technicians",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_technician_balance_summary_technician_id",
                table: "technician_balance_summary",
                column: "technician_id");

            migrationBuilder.CreateIndex(
                name: "IX_technician_balances_technician_id",
                table: "technician_balances",
                column: "technician_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "technician_balance_summary");

            migrationBuilder.DropTable(
                name: "technician_balances");
        }
    }
}
