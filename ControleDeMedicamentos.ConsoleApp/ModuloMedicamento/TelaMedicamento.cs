using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

public class TelaMedicamento : TelaBase<Medicamento>, ITelaCrud
{
    IRepositorioMedicamento repositorioMedicamento;

    public TelaMedicamento(IRepositorioMedicamento repositorioMedicamento) : base("Medicamento", repositorioMedicamento)
    {
        this.repositorioMedicamento = repositorioMedicamento;
    }

    public override void ExibirConteudoTabela(Medicamento registro)
    {
        if (registro.Estoque <= 20) Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(
            "{0, -10} | {1, -21} | {2, -21} | {3, -10} | {4, -15}",
            registro.Id, registro.Nome, registro.Descricao, registro.Estoque, registro.Fornecedor
        );
        Console.ResetColor();
    }

    public override void ExibirTabela()
    {
        Console.WriteLine(
            "{0, -10} | {1, -21} | {2, -21} | {3, -10} | {4, -15}",
            "Id", "Nome", "Descrição", "Estoque", "Fornecedor"
        );
    }

    public override Medicamento ObterDados(bool validacaoExtra)
    {
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o descrição: ");
        string descricao = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o estoque: ");
        int estoque = int.TryParse(Console.ReadLine(), out int valor) ? valor : -1;

        Console.Write("Digite o fornecedor: ");
        string fornecedor = Console.ReadLine() ?? string.Empty;

        Medicamento novoMedicamento = new Medicamento(nome, descricao, estoque, fornecedor);

        return novoMedicamento;
    }
}
