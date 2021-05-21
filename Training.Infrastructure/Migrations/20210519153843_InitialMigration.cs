using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TrainingProject.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "storeDepartments",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Scheme = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storeDepartments", x => new { x.StoreId, x.DepartmentId });
                });

            migrationBuilder.CreateTable(
                name: "stands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Side = table.Column<int>(type: "integer", nullable: false),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stands_storeDepartments_StoreId_DepartmentId",
                        columns: x => new { x.StoreId, x.DepartmentId },
                        principalTable: "storeDepartments",
                        principalColumns: new[] { "StoreId", "DepartmentId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Shelf = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    StandId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cells_stands_StandId",
                        column: x => x.StandId,
                        principalTable: "stands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cellid = table.Column<int>(type: "integer", nullable: false),
                    ProductCode = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_cells_Cellid",
                        column: x => x.Cellid,
                        principalTable: "cells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cells_StandId",
                table: "cells",
                column: "StandId");

            migrationBuilder.CreateIndex(
                name: "IX_products_Cellid",
                table: "products",
                column: "Cellid");

            migrationBuilder.CreateIndex(
                name: "IX_stands_StoreId_DepartmentId",
                table: "stands",
                columns: new[] { "StoreId", "DepartmentId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "cells");

            migrationBuilder.DropTable(
                name: "stands");

            migrationBuilder.DropTable(
                name: "storeDepartments");
        }
    }
}
