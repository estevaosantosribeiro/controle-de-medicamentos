using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;


namespace ClubeDaLeitura.ConsoleApp.Util;

public class TelaPrincipal
{
    //Repositorios

    private ContextoDados contexto;
    private RepositorioMedicamento repositorioMedicamento;

    public string OpcaoPrincipal { get; private set; }

    public TelaPrincipal()
    {
        contexto = new ContextoDados(true);
        //Criar repositorios
        repositorioMedicamento = new RepositorioMedicamento(contexto);
    }


    public void ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("|    Controle De Medicamentos    |");
        Console.WriteLine("---------------------------------");
        Console.WriteLine();


        Console.WriteLine("3 - Medicamentos");
        Console.WriteLine("S - Sair do Programa");
        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        OpcaoPrincipal = Console.ReadLine()!.ToUpper();
    }

    public ITelaCrud ObterTela()
    {
        // If else para telas
        if (OpcaoPrincipal == "3") return new TelaMedicamento(repositorioMedicamento);

        return null;
    }
}
