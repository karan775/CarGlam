using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarGlam.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Center",
                columns: table => new
                {
                    CenterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OpeningDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Center", x => x.CenterID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFName = table.Column<string>(nullable: true),
                    CustomerLName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "SalePerson",
                columns: table => new
                {
                    SalePersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalePersonsName = table.Column<string>(nullable: true),
                    AgreedAmount = table.Column<double>(nullable: false),
                    SaleDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePerson", x => x.SalePersonId);
                });

            migrationBuilder.CreateTable(
                name: "CarSale",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    SalePersonID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarSale", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarSale_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarSale_SalePerson_SalePersonID",
                        column: x => x.SalePersonID,
                        principalTable: "SalePerson",
                        principalColumn: "SalePersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarSale_CustomerID",
                table: "CarSale",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CarSale_SalePersonID",
                table: "CarSale",
                column: "SalePersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarSale");

            migrationBuilder.DropTable(
                name: "Center");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "SalePerson");
        }
    }
}
