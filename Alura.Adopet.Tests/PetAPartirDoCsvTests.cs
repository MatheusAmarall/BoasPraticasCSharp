using Alura.Adopet.Console.Domain;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Tests
{
    public class PetAPartirDoCsvTests
    {
        [Fact]
        public void PetAPartirDoCsv_Deve_RetornarUmPet_Quando_StringForValida()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
            //Act
            Pet pet = linha.ConverteDoTexto();

            //Assert
            Assert.NotNull(pet);
        }

        [Fact]
        public void PetAPartirDoCsv_Deve_RetornarArgumentNullException_Quando_StringNull()
        {
            //Arrange
            string? linha = null;
            //Act+Assert
            Assert.ThrowsAny<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void PetAPartirDoCsv_Deve_RetornarArgumentException_Quando_StringEmpty()
        {
            //Arrange
            string linha = "";
            //Act+Assert
            Assert.ThrowsAny<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void PetAPartirDoCsv_Deve_RetornarArgumentException_Quando_QuantidadeInsuficienteDeCampos()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão";
            //Act+Assert
            Assert.ThrowsAny<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void PetAPartirDoCsv_Deve_RetornarArgumentException_Quando_GuidInvalido()
        {
            //Arrange
            string linha = "guidinvalido;Lima Limão;1";
            //Act+Assert
            Assert.ThrowsAny<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void PetAPartirDoCsv_Deve_RetornarArgumentException_Quando_TipoInvalido()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;teste";
            //Act+Assert
            Assert.ThrowsAny<ArgumentException>(() => linha.ConverteDoTexto());
        }
    }
}