using Bogus;
using ProjetoMVC.Models;
using ProjetoMVC.Models.Enum;
using Xunit;

namespace ProjetoMVC.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var cidade = new CidadeModel()
            {
                Id = System.Guid.NewGuid(),
                NomeCidade = "Itu",
                Estado = EstadoEnum.SP
            };

            var endereco = new EnderecoModel()
            {
                Logradouro = "Avenida Barata Ribeiro, 400",
                Cidade = cidade,
                CidadeId = cidade.Id,
                 Bairro = "PARQUE INDUSTRIAL",
                  Cep = "13.300-000",
                   Latitude = 10.00,
                   Longitude = 20.00
            };

            var pessoaFisica = new Faker<PessoaModel>()
                .RuleFor(p => p.Id, p => p.Random.Guid())
                .RuleFor(p => p.Nome, p => p.Person.FullName)
                .RuleFor(p => p.Cpf, p => "123456")
                .RuleFor(p => p.DataDeNascimento, p=> p.Person.DateOfBirth)
                .Generate();

            var pessoaJuridica = new Faker<PessoaJuridicaModel>()
                .RuleFor(p => p.Id, p => p.Random.Guid())
                .RuleFor(p => p.NomeFantasia, p => p.Person.FullName)
                .RuleFor(p => p.RazaoSocial, p => p.Person.FullName)
                .RuleFor(p => p.Cnpj, p => "01.000.000/0001-01")
                .Generate();

            var clienteFornecedor1 = new Faker<ClienteFornecedorModel>()
                .RuleFor(p => p.Id, p => p.Random.Guid())
                .RuleFor(p => p.PessoaId, p => pessoaFisica.Id)
                .RuleFor(p => p.PessoaFisica, p => pessoaFisica)
                .Generate();

            var clienteFornecedor2 = new Faker<ClienteFornecedorModel>()
               .RuleFor(p => p.Id, p => p.Random.Guid())
               .RuleFor(p => p.PessoaJuridicaId, p => pessoaJuridica.Id)
               .RuleFor(p => p.PessoaJuridica, p => pessoaJuridica)
               .Generate();

            Assert.True(true);
        }
    }
}