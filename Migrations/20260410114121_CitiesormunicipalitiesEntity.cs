using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace DerTransporte.Migrations
{
    /// <inheritdoc />
    public partial class CitiesormunicipalitiesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citiesormunicipalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateorregionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Coordinates = table.Column<Point>(type: "point", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citiesormunicipalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citiesormunicipalities_Stateorregions_StateorregionId",
                        column: x => x.StateorregionId,
                        principalTable: "Stateorregions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Citiesormunicipalities_Code",
                table: "Citiesormunicipalities",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citiesormunicipalities_StateorregionId",
                table: "Citiesormunicipalities",
                column: "StateorregionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citiesormunicipalities");
        }
    }
}
