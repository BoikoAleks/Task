using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_1.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ProductionFacilities",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardArea = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionFacilities", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentPlacementContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionFacilityCode = table.Column<int>(type: "int", nullable: false),
                    EquipmentTypeCode = table.Column<int>(type: "int", nullable: false),
                    EquipmentQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentPlacementContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentPlacementContracts_EquipmentTypes_EquipmentTypeCode",
                        column: x => x.EquipmentTypeCode,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentPlacementContracts_ProductionFacilities_ProductionFacilityCode",
                        column: x => x.ProductionFacilityCode,
                        principalTable: "ProductionFacilities",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EquipmentTypes",
                columns: new[] { "Code", "Area", "Name" },
                values: new object[,]
                {
                    { 1, 20.0, "Conveyor" },
                    { 2, 50.0, "Press Machine" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Code", "Name", "StandardArea" },
                values: new object[,]
                {
                    { 1, "Facility A", 500.0 },
                    { 2, "Facility B", 800.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacementContracts_EquipmentTypeCode",
                table: "EquipmentPlacementContracts",
                column: "EquipmentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacementContracts_ProductionFacilityCode",
                table: "EquipmentPlacementContracts",
                column: "ProductionFacilityCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentPlacementContracts");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "ProductionFacilities");
        }
    }
}
