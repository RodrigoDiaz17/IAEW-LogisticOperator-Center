using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistanceLayer.Migrations
{
    public partial class renametableordenesenvio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosEnvios");

            migrationBuilder.CreateTable(
                name: "OrdenesEnvios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DireccionOrigen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactoComprador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoEnvio = table.Column<int>(type: "int", nullable: false),
                    DetalleProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepartidorId = table.Column<long>(type: "bigint", nullable: true),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesEnvios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesEnvios_Repartidores_RepartidorId",
                        column: x => x.RepartidorId,
                        principalTable: "Repartidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesEnvios_RepartidorId",
                table: "OrdenesEnvios",
                column: "RepartidorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesEnvios");

            migrationBuilder.CreateTable(
                name: "DatosEnvios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactoComprador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetalleProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionOrigen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoEnvio = table.Column<int>(type: "int", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepartidorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosEnvios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatosEnvios_Repartidores_RepartidorId",
                        column: x => x.RepartidorId,
                        principalTable: "Repartidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatosEnvios_RepartidorId",
                table: "DatosEnvios",
                column: "RepartidorId");
        }
    }
}
