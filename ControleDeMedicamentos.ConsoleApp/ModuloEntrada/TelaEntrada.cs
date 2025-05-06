using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloEntrada;

public class TelaEntrada : TelaBase<Entrada>, ITelaCrud
{
    IRepositorioEntrada repositorioEntrada;
    IRepositorioFuncionario repositorioFuncionario;
    IRepositorioMedicamento repositorioMedicamento;

    public TelaEntrada(IRepositorioEntrada repositorioEntrada, 
        IRepositorioFuncionario repositorioFuncionario, 
        IRepositorioMedicamento repositorioMedicamento) : 
        base("Entrada", repositorioEntrada)
    {
        this.repositorioEntrada = repositorioEntrada;
        this.repositorioFuncionario = repositorioFuncionario;
        this.repositorioMedicamento = repositorioMedicamento;
    }


    public override void ExtrasInserirEditar(Entrada registro)
    {
        registro.Medicamento.AtualizarEstoque(registro.Quantidade);
    }


    public override void ExibirConteudoTabela(Entrada registro)
    {
        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -17} | {3, -17} | {4, -10}",
            registro.Id, registro.Data.ToShortDateString(), registro.Funcionario.Nome, 
            registro.Medicamento.Nome, registro.Quantidade
        );
    }

    public override void ExibirTabela()
    {
        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -17} | {3, -17} | {4, -10}",
            "Id", "Data", "Funcionário", "Medicamento", "Quantidade"
        );
    }

    public void VisualizarFuncionarios()
    {
        Console.WriteLine($"Visualizando Funcionarios...");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0, -10} | {1, -21} | {2, -17} | {3, -17}",
            "Id", "Nome", "Telefone", "CPF"
        );

        List<Funcionario> funcionarios = repositorioFuncionario.SelecionarRegistros();

        foreach (var funcionario in funcionarios)
        {
            if (funcionario == null) continue;

            Console.WriteLine(
            "{0, -10} | {1, -21} | {2, -17} | {3, -17}",
            funcionario.Id, funcionario.Nome, funcionario.Telefone, funcionario.CPF
            );
        }
    }

    public void VisualizarMedicamentos()
    {
        Console.WriteLine($"Visualizando Medicamentos...");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0, -10} | {1, -21} | {2, -21} | {3, -10} | {4, -15}",
            "Id", "Nome", "Descrição", "Estoque", "Fornecedor"
        );

        List<Medicamento> medicamentos = repositorioMedicamento.SelecionarRegistros();

        foreach (var medicamento in medicamentos)
        {
            if (medicamento == null) continue;

            if (medicamento.Estoque <= 20) Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(
                "{0, -10} | {1, -21} | {2, -21} | {3, -10} | {4, -15}",
                medicamento.Id, medicamento.Nome, medicamento.Descricao, medicamento.Estoque, medicamento.Fornecedor.Nome
            );
            Console.ResetColor();
        }
    }

    public override Entrada ObterDados(bool validacaoExtra)
    {
        Console.Write("Digite a data: ");
        DateTime data = DateTime.TryParse(Console.ReadLine(), out DateTime valorData) ? valorData : DateTime.Now;

        VisualizarFuncionarios();
        int idFuncionario = int.TryParse(Console.ReadLine(), out int valorFuncionario) ? valorFuncionario : -1;

        Funcionario funcionario = repositorioFuncionario.SelecionarRegistroPorId(idFuncionario);

        if (funcionario == null)
        {
            Notificador.ExibirMensagem($"Não existe Funcionário com o ID {idFuncionario}", ConsoleColor.Red);
            return null!;
        }
        
        VisualizarMedicamentos();
        int idMedicamento = int.TryParse(Console.ReadLine(), out int valorMedicamento) ? valorMedicamento : -1;

        Medicamento medicamento = repositorioMedicamento.SelecionarRegistroPorId(idMedicamento);

        if (medicamento == null)
        {
            Notificador.ExibirMensagem($"Não existe Medicamento com o ID {idMedicamento}", ConsoleColor.Red);
            return null!;
        }

        Console.Write("Digite a quantidade: ");
        int quantidade = int.TryParse(Console.ReadLine(), out int valorQuantidade) ? valorQuantidade : -1;

        Entrada novaEntrada = new Entrada(data, medicamento, funcionario, quantidade);

        return novaEntrada;
    }
}
