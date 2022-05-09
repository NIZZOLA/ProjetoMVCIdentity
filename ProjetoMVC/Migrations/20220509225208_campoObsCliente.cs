using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMVC.Migrations
{
    public partial class campoObsCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "PessoaJuridica");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "ClienteFornecedor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ClienteFornecedorRequestModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cliente = table.Column<bool>(type: "bit", nullable: false),
                    Fornecedor = table.Column<bool>(type: "bit", nullable: false),
                    TipoDeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    OptanteDoSimples = table.Column<bool>(type: "bit", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteFornecedorRequestModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteFornecedorRequestModel");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "ClienteFornecedor");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "PessoaJuridica",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
