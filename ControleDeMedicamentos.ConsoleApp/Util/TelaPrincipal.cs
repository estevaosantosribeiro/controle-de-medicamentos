using ClubeDaLeitura.ConsoleApp.Compartilhado;


namespace ClubeDaLeitura.ConsoleApp.Util;

public class TelaPrincipal
{
    //Repositorios

    private ContextoDados contexto;
    
    public string OpcaoPrincipal { get; private set; }

    public TelaPrincipal()
    {
        contexto = new ContextoDados(true);
        //Criar repositorios
    }


    public void ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("|    Controle De Medicamentos    |");
        Console.WriteLine("---------------------------------");
        Console.WriteLine();


        Console.WriteLine("S - Sair do Programa");
        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        OpcaoPrincipal = Console.ReadLine()!.ToUpper();
    }

    public ITelaCrud ObterTela()
    {
        // If else para telas

        return null;
    }
}
