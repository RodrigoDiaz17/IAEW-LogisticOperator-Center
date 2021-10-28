using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistanceLayer.Migrations
{
    public partial class Cambiosenlaestructura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatosEnvios_Repartidores_RepartidorId",
                table: "DatosEnvios");

            migrationBuilder.AlterColumn<long>(
                name: "RepartidorId",
                table: "DatosEnvios",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEntrega",
                table: "DatosEnvios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DatosEnvios_Repartidores_RepartidorId",
                table: "DatosEnvios",
                column: "RepartidorId",
                principalTable: "Repartidores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatosEnvios_Repartidores_RepartidorId",
                table: "DatosEnvios");

            migrationBuilder.DropColumn(
                name: "FechaEntrega",
                table: "DatosEnvios");

            migrationBuilder.AlterColumn<long>(
                name: "RepartidorId",
                table: "DatosEnvios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DatosEnvios_Repartidores_RepartidorId",
                table: "DatosEnvios",
                column: "RepartidorId",
                principalTable: "Repartidores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
