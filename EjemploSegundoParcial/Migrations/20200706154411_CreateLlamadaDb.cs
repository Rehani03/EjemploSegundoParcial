using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EjemploSegundoParcial.Migrations
{
    public partial class CreateLlamadaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Llamadas",
                columns: table => new
                {
                    llamadaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(nullable: false),
                    total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llamadas", x => x.llamadaId);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    paisId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pais = table.Column<string>(nullable: true),
                    precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.paisId);
                });

            migrationBuilder.CreateTable(
                name: "LlamadaDetalle",
                columns: table => new
                {
                    llamadaDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    llamadaId = table.Column<int>(nullable: false),
                    paisId = table.Column<int>(nullable: false),
                    precio = table.Column<decimal>(nullable: false),
                    duracion = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlamadaDetalle", x => x.llamadaDetalleId);
                    table.ForeignKey(
                        name: "FK_LlamadaDetalle_Llamadas_llamadaId",
                        column: x => x.llamadaId,
                        principalTable: "Llamadas",
                        principalColumn: "llamadaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pais",
                columns: new[] { "paisId", "pais", "precio" },
                values: new object[] { 1, "Haiti", 10m });

            migrationBuilder.CreateIndex(
                name: "IX_LlamadaDetalle_llamadaId",
                table: "LlamadaDetalle",
                column: "llamadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LlamadaDetalle");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Llamadas");
        }
    }
}
