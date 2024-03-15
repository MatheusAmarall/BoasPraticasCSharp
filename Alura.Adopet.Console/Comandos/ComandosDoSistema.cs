namespace Alura.Adopet.Console.Comandos
{
    public class ComandosDoSistema
    {
        private static Dictionary<string, IComando> comandosDoSistema = new()
        {
            {"help",new Help() },
            {"import",new Import() },
            {"list",new List() },
            {"show",new Show() },
        };

        public static IComando RetornaComandoEspecificoDoSistema(string key) {
            return comandosDoSistema[key];
        }

        public static bool ComandoValido(string key)
        {
            return comandosDoSistema.ContainsKey(key);
        }
    }
}
