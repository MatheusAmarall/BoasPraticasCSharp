using Alura.Adopet.Console.Comandos;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0].Trim();
    if (ComandosDoSistema.ComandoValido(comando))
    {
        IComando comandoASerExecutado = ComandosDoSistema.RetornaComandoEspecificoDoSistema(comando)!;
        await comandoASerExecutado.ExecutarAsync(args);
    }
    else
    {
        Console.WriteLine("Comando inválido!");
    }
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}