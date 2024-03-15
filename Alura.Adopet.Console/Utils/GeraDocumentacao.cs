using Alura.Adopet.Console.Comandos;
using System.Reflection;

namespace Alura.Adopet.Console.Utils
{
    public class GeraDocumentacao
    {
        public static Dictionary<string, DocComando> ConverteDocComandoEmDict(Assembly assemblyComOTipoDocComando)
        {
            return assemblyComOTipoDocComando.GetTypes()
                .Where(t => t.GetCustomAttributes<DocComando>().Any())
                .Select(t => t.GetCustomAttribute<DocComando>()!)
                .ToDictionary(d => d.Instrucao);
        }
    }
}
