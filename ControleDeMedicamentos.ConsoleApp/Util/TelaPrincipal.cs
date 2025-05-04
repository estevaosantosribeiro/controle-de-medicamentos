using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;
using ControleDeMedicamentos.ConsoleApp.ModuloEntrada;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida;

namespace ControleDeMedicamentos.ConsoleApp.Util;

public class TelaPrincipal
{
    private ContextoDados contexto;
    private RepositorioMedicamento repositorioMedicamento;
    private RepositorioPaciente repositorioPaciente;
    private RepositorioFuncionario repositorioFuncionario;
    private RepositorioFornecedor repositorioFornecedor;
    private RepositorioPrescricao repositorioPrescricao;
    private RepositorioEntrada repositorioEntrada;
    private RepositorioRequisicaoDeSaida repositorioRequisicaoDeSaida;

    public string OpcaoPrincipal { get; private set; }

    public TelaPrincipal()
    {
        contexto = new ContextoDados(true);
        repositorioMedicamento = new RepositorioMedicamento(contexto);
        repositorioPaciente = new RepositorioPaciente(contexto);
        repositorioFuncionario = new RepositorioFuncionario(contexto);
        repositorioFornecedor = new RepositorioFornecedor(contexto);
        repositorioPrescricao = new RepositorioPrescricao(contexto);
        repositorioEntrada = new RepositorioEntrada(contexto);
        repositorioRequisicaoDeSaida = new RepositorioRequisicaoDeSaida(contexto);
    }


    public void ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("|    Controle De Medicamentos    |");
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Console.WriteLine("1- Controle de Fornecedores");
        Console.WriteLine("2 - Controle de Pacientes");
        Console.WriteLine("3 - Controle de Medicamentos");
        Console.WriteLine("4 - Controle de Funcionários");
        Console.WriteLine("5 - Prescrições Médicas");
        Console.WriteLine("6 - Requisição de Entrada");
        Console.WriteLine("7 - Requisição de Saída");
        Console.WriteLine("S - Sair do Programa");
        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        OpcaoPrincipal = Console.ReadLine()!.ToUpper();
    }

    public ITelaCrud ObterTela()
    {
        if (OpcaoPrincipal == "1")
            return new TelaFornecedor(repositorioFornecedor);

        else if (OpcaoPrincipal == "2")
            return new TelaPaciente(repositorioPaciente);

        else if (OpcaoPrincipal == "3")
            return new TelaMedicamento(repositorioMedicamento, repositorioFornecedor);

        else if (OpcaoPrincipal == "4")
            return new TelaFuncionario(repositorioFuncionario);

        else if (OpcaoPrincipal == "5")
            return new TelaPrescricao(repositorioPrescricao);

        else if (OpcaoPrincipal == "6")
            return new TelaEntrada(repositorioEntrada, repositorioFuncionario, repositorioMedicamento);

        else if (OpcaoPrincipal == "7")
            return new TelaRequisicaoDeSaida(repositorioRequisicaoDeSaida, repositorioPaciente, repositorioPrescricao, repositorioMedicamento);

        return null;
    }
}
