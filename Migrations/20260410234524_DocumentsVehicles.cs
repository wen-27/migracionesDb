using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DerTransporte.Migrations
{
    /// <inheritdoc />
    public partial class DocumentsVehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "documents_vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DocumentNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpirationDate = table.Column<DateOnly>(type: "DATE", nullable: false),
                    FileUrl = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    VehicleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TypeDocumentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DocumentStatusId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents_vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_documents_vehicles_documents_status_DocumentStatusId",
                        column: x => x.DocumentStatusId,
                        principalTable: "documents_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_documents_vehicles_type_documents_TypeDocumentId",
                        column: x => x.TypeDocumentId,
                        principalTable: "type_documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_documents_vehicles_vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_documents_vehicles_DocumentStatusId",
                table: "documents_vehicles",
                column: "DocumentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_documents_vehicles_TypeDocumentId",
                table: "documents_vehicles",
                column: "TypeDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_documents_vehicles_VehicleId",
                table: "documents_vehicles",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documents_vehicles");
        }
    }
}
