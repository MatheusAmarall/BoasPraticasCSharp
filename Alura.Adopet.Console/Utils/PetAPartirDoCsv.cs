using Alura.Adopet.Console.Domain;

namespace Alura.Adopet.Console.Utils
{
    public static class PetAPartirDoCsv
    {
        public static Pet ConverteDoTexto(this string? linha)
        {
            ValidateStringNullOrEmpty(linha);

            string[] propriedades = linha!.Split(';');

            ValidateProperties(propriedades);

            Guid idPet = Guid.Parse(propriedades[0]);
            string nomePet = propriedades[1];
            int tipoPet = int.Parse(propriedades[2]);

            return new Pet(idPet, nomePet, tipoPet == 0 ? TipoPet.Gato : TipoPet.Cachorro);
        }

        private static void ValidateStringNullOrEmpty(string? linha)
        {
            if (string.IsNullOrEmpty(linha)) throw new ArgumentNullException("Texto não pode ser vazio ou nulo");
        }

        private static void ValidateProperties(string[] propriedades)
        {
            if (propriedades.Length != 3) throw new ArgumentException("Texto inválido");
            if (!Guid.TryParse(propriedades[0], out Guid idPet)) throw new ArgumentException("Id inválido");
            if (!int.TryParse(propriedades[2], out int tipoPet)) throw new ArgumentException("Tipo de Pet inválido");
        }
    }
}
