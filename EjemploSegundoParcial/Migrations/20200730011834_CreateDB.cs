using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EjemploSegundoParcial.Migrations
{
    public partial class CreateDB : Migration
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
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    RNC = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 40, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    TipoNegocio = table.Column<string>(maxLength: 40, nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
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
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Llamadas");
        }
    }
}
