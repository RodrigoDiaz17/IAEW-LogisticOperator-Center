using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistanceLayer.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repartidores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repartidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatosEnvios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DireccionOrigen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactoComprador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoEnvio = table.Column<int>(type: "int", nullable: false),
                    DetalleProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepartidorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosEnvios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatosEnvios_Repartidores_RepartidorId",
                        column: x => x.RepartidorId,
                        principalTable: "Repartidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatosEnvios_RepartidorId",
                table: "DatosEnvios",
                column: "RepartidorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosEnvios");

            migrationBuilder.DropTable(
                name: "Repartidores");
        }
    }
}
