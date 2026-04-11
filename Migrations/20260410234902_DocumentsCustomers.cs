using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DerTransporte.Migrations
{
    /// <inheritdoc />
    public partial class DocumentsCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "documents_customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DocumentNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileUrl = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TypeDocumentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DocumentStatusId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents_customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_documents_customers_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_documents_customers_documents_status_DocumentStatusId",
                        column: x => x.DocumentStatusId,
                        principalTable: "documents_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_documents_customers_type_documents_TypeDocumentId",
                        column: x => x.TypeDocumentId,
                        principalTable: "type_documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_documents_customers_CustomerId",
                table: "documents_customers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_documents_customers_DocumentStatusId",
                table: "documents_customers",
                column: "DocumentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_documents_customers_TypeDocumentId",
                table: "documents_customers",
                column: "TypeDocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documents_customers");
        }
    }
}
