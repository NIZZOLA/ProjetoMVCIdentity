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
                CidadeId = cidade.Id
            };

            Assert.True(true);
        }
    }
}