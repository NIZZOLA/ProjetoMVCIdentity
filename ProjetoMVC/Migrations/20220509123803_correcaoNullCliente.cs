using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMVC.Migrations
{
    public partial class correcaoNullCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_ClienteFornecedor_ClienteFornecedorId",
                table: "Endereco");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteFornecedorId",
                table: "Endereco",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_ClienteFornecedor_ClienteFornecedorId",
                table: "Endereco",
                column: "ClienteFornecedorId",
                principalTable: "ClienteFornecedor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_ClienteFornecedor_ClienteFornecedorId",
                table: "Endereco");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteFornecedorId",
                table: "Endereco",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_ClienteFornecedor_ClienteFornecedorId",
                table: "Endereco",
                column: "ClienteFornecedorId",
                principalTable: "ClienteFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
