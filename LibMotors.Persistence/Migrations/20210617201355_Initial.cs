using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibMotors.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockIn = table.Column<int>(type: "int", nullable: false),
                    StockOut = table.Column<int>(type: "int", nullable: false),
                    FinalStock = table.Column<int>(type: "int", nullable: false),
                    StockReport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoveMovementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeesId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipmentCost = table.Column<double>(type: "float", nullable: false),
                    ShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiptName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    EmployeesId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DOB", "DateCreated", "Email", "Fullname", "Gender", "HiredDate", "JobId", "LocationId", "Mobile", "Position" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "uncle.bob@gmail.com", "Uncle Bob", 0, new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B9A09", "S034b9", "999-888-7777", "WarehouseManager" },
                    { 2, new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "uncle.ochuko@gmail.com", "ochuko Lucky", 0, new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CC9A09", "C034b9", "888-888-7777", "WarehouPersonel" }
                });

            migrationBuilder.InsertData(
                table: "InventoryItems",
                columns: new[] { "Id", "DateCreated", "DeliveryDate", "EmployeesId", "ItemStatus", "OwnerContact", "ReceiptDetails", "ReceiptName", "ShipmentCost", "ShipmentDate", "StockItem", "StockOwner", "StockRef", "WarehouseId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Shift", "999-888-7777", "Hello word", "john dev", 8000.0, new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iphone", " marrt Bob", null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Shift", "999-888-7777", "Hello word", "john dev", 8000.0, new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iphone", " marrt Bob", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_EmployeesId",
                table: "InventoryItems",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_WarehouseId",
                table: "InventoryItems",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_EmployeesId",
                table: "Warehouses",
                column: "EmployeesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
