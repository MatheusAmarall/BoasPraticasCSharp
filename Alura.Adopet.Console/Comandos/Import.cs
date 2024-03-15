using Alura.Adopet.Console.Domain;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "import",
        documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando
    {
        public async Task ExecutarAsync(string[] args)
        {
            await ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
        }

        private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
        {
            List<Pet> listaDePet = LeitorDeArquivo.RealizaLeitura(caminhoDoArquivoDeImportacao);
            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
                try
                {
                    var httpClientPet = new HttpClientPet();
                    await httpClientPet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }
    }
}
