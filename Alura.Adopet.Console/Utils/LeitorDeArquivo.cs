using Alura.Adopet.Console.Domain;

namespace Alura.Adopet.Console.Utils
{
    public class LeitorDeArquivo
    {
        public static List<Pet> RealizaLeitura(string caminhoDoArquivoASerLido)
        {
            List<Pet> listaDePet = new();
            using StreamReader sr = new(caminhoDoArquivoASerLido);
            while (!sr.EndOfStream)
            {
                string dadosPet = sr.ReadLine()!;
                Pet pet = dadosPet.ConverteDoTexto();
                listaDePet.Add(pet);
            }

            return listaDePet;
        }
    }
}
