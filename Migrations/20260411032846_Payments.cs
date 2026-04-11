using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DerTransporte.Migrations
{
    /// <inheritdoc />
    public partial class Payments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    wallet_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    payment_provider_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    external_reference = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    amount_money = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_payments_credit_wallet_wallet_id",
                        column: x => x.wallet_id,
                        principalTable: "credit_wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payments_payment_providers_payment_provider_id",
                        column: x => x.payment_provider_id,
                        principalTable: "payment_providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payments_payment_statuses_status_id",
                        column: x => x.status_id,
                        principalTable: "payment_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_payments_payment_provider_id",
                table: "payments",
                column: "payment_provider_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_status_id",
                table: "payments",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_wallet_id",
                table: "payments",
                column: "wallet_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");
        }
    }
}
