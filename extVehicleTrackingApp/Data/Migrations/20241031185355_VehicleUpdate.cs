using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace extVehicleTrackingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtVehicleOrg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtVehicleOrg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgId = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Inspection = table.Column<DateOnly>(type: "date", nullable: true),
                    Surplus = table.Column<bool>(type: "bit", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtVehicle_ExtVehicleOrg_OrgId",
                        column: x => x.OrgId,
                        principalTable: "ExtVehicleOrg",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExtVehicleTrip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalTravelers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundingSource = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtVehicleTrip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtVehicleTrip_ExtVehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "ExtVehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtVehicleTripInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Ts = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    FuelGallons = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FuelTotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtVehicleTripInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtVehicleTripInfo_ExtVehicleTrip_TripId",
                        column: x => x.TripId,
                        principalTable: "ExtVehicleTrip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtVehicle_OrgId",
                table: "ExtVehicle",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtVehicleTrip_VehicleId",
                table: "ExtVehicleTrip",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtVehicleTripInfo_TripId",
                table: "ExtVehicleTripInfo",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtVehicleTripInfo");

            migrationBuilder.DropTable(
                name: "ExtVehicleTrip");

            migrationBuilder.DropTable(
                name: "ExtVehicle");

            migrationBuilder.DropTable(
                name: "ExtVehicleOrg");
        }
    }
}
