using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public class TelaPaciente : TelaBase<Paciente>, ITelaCrud
{
    public TelaPaciente(IRepositorioPaciente repositorio) : base("Paciente", repositorio)
    {
    }

    public override void ExibirConteudoTabela(Paciente registro)
    {
        throw new NotImplementedException();
    }

    public override void ExibirTabela()
    {
        throw new NotImplementedException();
    }

    public override Paciente ObterDados(bool validacaoExtra)
    {
        Console.Write("Digite o nome do paciente: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do paciente: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o número do cartão do SUS do paciente: ");
        string cartaoSus = Console.ReadLine() ?? string.Empty;

        Paciente paciente = new Paciente(nome, telefone, cartaoSus);

        return paciente;
    }
}
