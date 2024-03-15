using Alura.Adopet.Console.Utils;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "help",
        documentacao: " adopet help comando que exibe informações da ajuda. \n" +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico")]
    public class Help : IComando
    {
        private readonly Dictionary<string, DocComando> docs = GeraDocumentacao.ConverteDocComandoEmDict(Assembly.GetExecutingAssembly());

        public Task ExecutarAsync(string[] args)
        {
            ExibeListaAjudaUsuario(listaArgumentos: args);
            return Task.CompletedTask;
        }

        private void ExibeListaAjudaUsuario(string[] listaArgumentos)
        {
            if (listaArgumentos.Length == 1)
            {
                System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine("Comando possíveis: ");
                foreach (var doc in docs.Values)
                {
                    System.Console.WriteLine(doc.Documentacao);
                }
            }
            // exibe o help daquele comando específico
            else if (listaArgumentos.Length == 2)
            {
                string comandoASerExibido = listaArgumentos[1];
                if (docs.ContainsKey(comandoASerExibido))
                {
                    var comando = docs[comandoASerExibido];
                    System.Console.WriteLine(comando.Documentacao);
                }
            }
        }

        
    }
}
