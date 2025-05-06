using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public class TelaPaciente : TelaBase<Paciente>, ITelaCrud
{
    IRepositorioPaciente repositorioPaciente;
    public TelaPaciente(IRepositorioPaciente repositorio) : base("Paciente", repositorio)
    {
        repositorioPaciente = repositorio;
    }

    public override bool ValidarInserirEditar(Paciente registroEditado, int idRegistro = -1)
    {
        bool validacao = repositorioPaciente.VerificarCartaoSUS(registroEditado.CartaoSUS, idRegistro);

        if (!validacao)
        {
            Notificador.ExibirMensagem("Já existe um Paciente com este Cartão do SUS", ConsoleColor.Red);
            return false;
        }

        return true;
    }

    public override void ExibirTabela()
    {
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -30}",
            "Id", "Nome", "Telefone", "Cartão do SUS"
        );
    }

    public override void ExibirConteudoTabela(Paciente registro)
    {
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -30}",
            registro.Id, registro.Nome, registro.Telefone, registro.CartaoSUS
        );
    }

    public override Paciente ObterDados(bool validacaoExtra)
    {
        Console.Write("Digite o nome do paciente: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do paciente: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        string cartaoSus;
        if (!validacaoExtra)
        {
            Console.Write("Digite o número do cartão do SUS do paciente: ");
            cartaoSus = Console.ReadLine() ?? string.Empty;

            Paciente paciente = new Paciente(nome, telefone, cartaoSus);

            return paciente;
        }
        
        Paciente pacienteEditado = new Paciente(nome, telefone, "000000000000000");

        return pacienteEditado;
    }
}


