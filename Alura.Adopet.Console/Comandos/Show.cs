using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show",
        documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        public Task ExecutarAsync(string[] args)
        {
            ExibeArquivo(caminhoDoArquivoASerExibido: args[1]);
            return Task.CompletedTask;
        }

        private void ExibeArquivo(string caminhoDoArquivoASerExibido)
        {
            var listDePets = LeitorDeArquivo.RealizaLeitura(caminhoDoArquivoASerExibido);

            foreach (var item in listDePets)
            {
                System.Console.WriteLine(item);
            }
        }

        
    }
}
