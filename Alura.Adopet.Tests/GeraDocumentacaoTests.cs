using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Utils;
using System.Reflection;

namespace Alura.Adopet.Tests
{
    public class GeraDocumentacaoTests
    {
        [Fact]
        public void GeraDocumentacao_Deve_RetornarDicionarioNaoVazio_Quando_ExistemComandos()
        {
            //Arrange
            Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComando))!;
            //Act
            var dicionario = GeraDocumentacao.ConverteDocComandoEmDict(assemblyComOTipoDocComando);

            //Assert
            Assert.NotEmpty(dicionario);
            Assert.Equal(4, dicionario.Count);
        }
    }
}
