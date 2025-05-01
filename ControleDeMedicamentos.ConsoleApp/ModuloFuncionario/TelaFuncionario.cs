using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

public class TelaFuncionario : TelaBase<Funcionario>, ITelaCrud
{
    IRepositorioFuncionario repositorioFuncionario;

    public TelaFuncionario(IRepositorioFuncionario repositorio) : base("Funcionário", repositorio)
    {
        repositorioFuncionario = repositorio;
    }

    public override bool ValidarInserirEditar(Funcionario registroEditado, int idRegistro = -1)
    {
        bool validacao = repositorioFuncionario.VerificarCPF(registroEditado.CPF, idRegistro);

        if (!validacao)
        {
            Notificador.ExibirMensagem("Já existe um funcionário com este CPF", ConsoleColor.Red);
            return false;
        }

        return true;
    }

    public override void ExibirConteudoTabela(Funcionario registro)
    {
        Console.WriteLine(
            "{0, -10} | {1, -21} | {2, -17} | {3, -17}",
            registro.Id, registro.Nome, registro.Telefone, registro.CPF
        );
    }

    public override void ExibirTabela()
    {
        Console.WriteLine(
            "{0, -10} | {1, -21} | {2, -17} | {3, -17}",
            "Id", "Nome", "Telefone", "CPF"
        );
    }

    public override Funcionario ObterDados(bool validacaoExtra)
    {
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o CPF: ");
        string cpf = Console.ReadLine() ?? string.Empty;

        Funcionario novoFuncionario = new Funcionario(nome, telefone, cpf);

        return novoFuncionario;
    }
}
