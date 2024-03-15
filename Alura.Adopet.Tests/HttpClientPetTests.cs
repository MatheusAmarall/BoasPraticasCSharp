using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Tests
{
    public class HttpClientPetTests
    {
        [Fact]
        public async Task ListaPets_Deve_RetornarUmaListaNaoVazia_Quando_SucessoRequisicaoAsync()
        {
            //Arrange
            var clientPet = new HttpClientPet();

            //Act
            var lista = await clientPet.ListPetsAsync();

            //Assert
            Assert.NotNull(lista);
            Assert.NotEmpty(lista);
        }

        [Fact]
        public async Task ListaPets_Deve_RetornarUmaExcecao_Quando_APIforaAsync()
        {
            //Arrange
            var clientPet = new HttpClientPet(uri: "http://localhost:1111");

            //Act+Assert
            await Assert.ThrowsAnyAsync<Exception>(() => clientPet.ListPetsAsync());
        }
    }
}