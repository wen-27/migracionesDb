using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DerTransporte.Migrations
{
    /// <inheritdoc />
    public partial class TravelScale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "travel_scale",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    trip_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    city_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    sequence = table.Column<short>(type: "smallint", nullable: false),
                    arrival_estimated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    arrival_actual = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    departure_actual = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travel_scale", x => x.id);
                    table.ForeignKey(
                        name: "FK_travel_scale_Citiesormunicipalities_city_id",
                        column: x => x.city_id,
                        principalTable: "Citiesormunicipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_travel_scale_trips_trip_id",
                        column: x => x.trip_id,
                        principalTable: "trips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_travel_scale_city_id",
                table: "travel_scale",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_travel_scale_trip_id",
                table: "travel_scale",
                column: "trip_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "travel_scale");
        }
    }
}
