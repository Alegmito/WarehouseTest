using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceListColumns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PriceListColValType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PriceListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListColumns_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceListProduct",
                columns: table => new
                {
                    PriceListsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListProduct", x => new { x.PriceListsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_PriceListProduct_PriceLists_PriceListsId",
                        column: x => x.PriceListsId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceListProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceListColValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceListColumnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    value_type = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    valueInt = table.Column<int>(type: "int", nullable: true),
                    valueString = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    valueText = table.Column<string>(type: "nvarchar(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListColValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListColValue_PriceListColumns_PriceListColumnId",
                        column: x => x.PriceListColumnId,
                        principalTable: "PriceListColumns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceListColValue_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceListColumns_PriceListId",
                table: "PriceListColumns",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListColValue_PriceListColumnId",
                table: "PriceListColValue",
                column: "PriceListColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListColValue_ProductId",
                table: "PriceListColValue",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListProduct_ProductsId",
                table: "PriceListProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceListColValue");

            migrationBuilder.DropTable(
                name: "PriceListProduct");

            migrationBuilder.DropTable(
                name: "PriceListColumns");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PriceLists");
        }
    }
}
