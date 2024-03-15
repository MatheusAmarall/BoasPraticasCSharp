using Alura.Adopet.Console.Domain;
using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list",
        documentacao: " adopet list comando que exibe no terminal o conteúdo cadastradeo na base de dados da AdoPet.")]
    public class List : IComando
    {
        public async Task ExecutarAsync(string[] args)
        {
            await ExibeListaPets();
        }

        private async Task ExibeListaPets()
        {
            var httpClientPet = new HttpClientPet();
            IEnumerable<Pet>? pets = await httpClientPet.ListPetsAsync();
            System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }

        
    }
}
