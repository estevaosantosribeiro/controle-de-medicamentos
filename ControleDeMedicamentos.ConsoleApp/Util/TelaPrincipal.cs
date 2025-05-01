using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

namespace ControleDeMedicamentos.ConsoleApp.Util;

public class TelaPrincipal
{
    //Repositorios

    private ContextoDados contexto;
    private RepositorioMedicamento repositorioMedicamento;
    private RepositorioPaciente repositorioPaciente;
    private RepositorioFuncionario repositorioFuncionario;
    
    public string OpcaoPrincipal { get; private set; }

    public TelaPrincipal()
    {
        contexto = new ContextoDados(true);
        //Criar repositorios
        repositorioMedicamento = new RepositorioMedicamento(contexto);
        repositorioPaciente = new RepositorioPaciente(contexto);
        repositorioFuncionario = new RepositorioFuncionario(contexto);
    }


    public void ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("|    Controle De Medicamentos    |");
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Console.WriteLine("2 - Controle de Pacientes");
        Console.WriteLine("3 - Controle de Medicamentos");
        Console.WriteLine("4 - Controle de Funcionários");
        Console.WriteLine("S - Sair do Programa");
        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        OpcaoPrincipal = Console.ReadLine()!.ToUpper();
    }

    public ITelaCrud ObterTela()
    {
        // If else para telas
        if (OpcaoPrincipal == "2")
            return new TelaPaciente(repositorioPaciente);

        else if (OpcaoPrincipal == "3")
            return new TelaMedicamento(repositorioMedicamento);

        else if (OpcaoPrincipal == "4")
            return new TelaFuncionario(repositorioFuncionario);

        return null;
    }
}
