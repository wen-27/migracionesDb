using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DerTransporte.Migrations
{
    /// <inheritdoc />
    public partial class Loads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OriginAddress = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DestinationAddress = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginCoords = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DestinationCoords = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WeightTons = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    VolumeM3 = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OfferedPrice = table.Column<decimal>(type: "DECIMAL(19,4)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    CustomerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TypeLoadId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OriginCityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DestinationCityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StatusId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loads_Citiesormunicipalities_DestinationCityId",
                        column: x => x.DestinationCityId,
                        principalTable: "Citiesormunicipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_loads_Citiesormunicipalities_OriginCityId",
                        column: x => x.OriginCityId,
                        principalTable: "Citiesormunicipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_loads_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_loads_type_load_TypeLoadId",
                        column: x => x.TypeLoadId,
                        principalTable: "type_load",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_loads_CustomerId",
                table: "loads",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_loads_DestinationCityId",
                table: "loads",
                column: "DestinationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_loads_OriginCityId",
                table: "loads",
                column: "OriginCityId");

            migrationBuilder.CreateIndex(
                name: "IX_loads_TypeLoadId",
                table: "loads",
                column: "TypeLoadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loads");
        }
    }
}
