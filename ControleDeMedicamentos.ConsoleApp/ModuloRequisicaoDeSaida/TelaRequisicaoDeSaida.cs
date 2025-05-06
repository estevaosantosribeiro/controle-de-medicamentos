using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;
using ControleDeMedicamentos.ConsoleApp.Util;
using Microsoft.Win32;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida;

public class TelaRequisicaoDeSaida : TelaBase<RequisicaoDeSaida>, ITelaCrud
{
    private RepositorioRequisicaoDeSaida repositorioRequisicaoDeSaida1;

    IRepositorioRequisicaoDeSaida repositorioRequisicaoDeSaida { get; set; }
    IRepositorioPaciente repositorioPaciente { get; set; }
    IrepossitorioPrescricao repositorioPrescricao { get; set; }
    IRepositorioMedicamento repositorioMedicamento { get; set; }

    public TelaRequisicaoDeSaida(
        IRepositorioRequisicaoDeSaida repositorioRequisicaoDeSaida,
        IRepositorioPaciente repositorioPaciente,
        IrepossitorioPrescricao repositorioPrescricao,
        IRepositorioMedicamento repositorioMedicamento
        ) : base("Requisição de Saída", repositorioRequisicaoDeSaida)
    {
        this.repositorioRequisicaoDeSaida = repositorioRequisicaoDeSaida;
        this.repositorioPaciente = repositorioPaciente;
        this.repositorioPrescricao = repositorioPrescricao;
        this.repositorioMedicamento = repositorioMedicamento;
    }

    public override void MostrarOpcoes()
    {
        Console.WriteLine($"1 - Cadastrar Requisição de Saída");
        Console.WriteLine($"2 - Editar Requisição de Saída");
        Console.WriteLine($"3 - Excluir Requisição de Saída");
        Console.WriteLine($"4 - Visualizar Requisição de Saídas");
        Console.WriteLine($"5 - Visualizar Requisição de Saídas por Paciente");
        Console.WriteLine("S - Voltar");
    }

    public override void ExibirConteudoTabela(RequisicaoDeSaida registro)
    {
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -30} | {4, -30}",
            registro.Id,
            registro.Data.ToShortDateString(),
            registro.Paciente.Nome,
            registro.PrescricaoMedica.CRM,
            registro.MedicamentoRequisitado.Nome
        );
    }

    public override void ExibirTabela()
    {
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -30} | {4, -30}",
            "Id", "Data", "Paciente", "Prescrição Médica", "Medicamentos"
        );
    }

    public override void ExtrasInserirEditar(RequisicaoDeSaida registro)
    {
        registro.MedicamentoRequisitado.AtualizarEstoque(1, false);
    }

    public override RequisicaoDeSaida ObterDados(bool validacaoExtra)
    {
        VisualizarPacientes();
        
        Console.Write("Digite o ID do paciente que deseja selecionar: ");
        int idPaciente = int.TryParse(Console.ReadLine(), out int valorPaciente) ? valorPaciente : -1;

        Paciente pacienteSelecionado = repositorioPaciente.SelecionarRegistroPorId(idPaciente);

        if (pacienteSelecionado == null)
        {
            Notificador.ExibirMensagem($"Não existe Paciente com o ID {idPaciente}", ConsoleColor.Red);
            return null!;
        }

        VisualizarPrescricoes();
        
        Console.Write("Digite o ID do paciente que deseja selecionar: ");
        int idPrescricao = int.TryParse(Console.ReadLine(), out int valorPrescricao) ? valorPrescricao : -1;

        Prescricao prescricaoSelecionada = repositorioPrescricao.SelecionarRegistroPorId(idPrescricao);

        if (prescricaoSelecionada == null)
        {
            Notificador.ExibirMensagem($"Não existe Prescrição com o ID {idPrescricao}", ConsoleColor.Red);
            return null!;
        }

        VisualizarMedicamentos();
        
        Console.Write("Digite o ID do paciente que deseja selecionar: ");
        int idMedicamento = int.TryParse(Console.ReadLine(), out int valorMedicamento) ? valorMedicamento : -1;

        Medicamento medicamentoSelecionado = repositorioMedicamento.SelecionarRegistroPorId(idMedicamento);

        if (medicamentoSelecionado == null)
        {
            Notificador.ExibirMensagem($"Não existe Medicamento com o ID {idPrescricao}", ConsoleColor.Red);
            return null!;
        }

        RequisicaoDeSaida requisicaoDeSaida = new RequisicaoDeSaida(
            DateTime.Now,
            pacienteSelecionado,
            prescricaoSelecionada,
            medicamentoSelecionado
        );

        return requisicaoDeSaida;
    }

    public void VisualizarPacientes()
    {
        Console.WriteLine("Visualizando Pacientes");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -30}",
            "Id", "Nome", "Telefone", "Cartão do SUS"
        );

        List<Paciente> pacientes = repositorioPaciente.SelecionarRegistros();

        foreach (var registro in pacientes)
        {
            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -30}",
            registro.Id, registro.Nome, registro.Telefone, registro.CartaoSUS
            );
        }

        Console.WriteLine();
    }

    public void VisualizarPrescricoes()
    {
        Console.WriteLine("Visualizando Prescrições");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0,-10} | {1,-30} | {2,-20} | {3,-20} |",
             "id", "CRM", "Medicamento", "DATA"
        );

        List<Prescricao> prescricoes = repositorioPrescricao.SelecionarRegistros();

        foreach ( var registro in prescricoes)
        {
            Console.WriteLine(
                "{0,-10} | {1,-30} | {2,-20} | {3,-20} |",
                registro.Id, registro.CRM, registro.Medicamento.Nome, registro.DATA.ToShortDateString()
            );
        }

        Console.WriteLine();
    }

    public void VisualizarMedicamentos()
    {
        Console.WriteLine("Visualizando Medicamentos");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0, -10} | {1, -21} | {2, -21} | {3, -10} | {4, -15}",
            "Id", "Nome", "Descrição", "Estoque", "Fornecedor"
        );

        List<Medicamento> medicamentos = repositorioMedicamento.SelecionarRegistros();

        foreach (var registro in medicamentos)
        {
            Console.WriteLine(
                "{0, -10} | {1, -21} | {2, -21} | {3, -10} | {4, -15}",
                registro.Id, registro.Nome, registro.Descricao, registro.Estoque, registro.Fornecedor.Nome
            );
        }
    }

    public void VisualizarRequisicoesPorPaciente()
    {
        VisualizarPacientes();
        
        Console.Write("Digite o ID do paciente: ");
        int idPaciente = int.TryParse(Console.ReadLine(), out int valorPaciente) ? valorPaciente : -1;

        Paciente paciente = repositorioPaciente.SelecionarRegistroPorId(idPaciente);

        if (paciente == null)
        {
            Notificador.ExibirMensagem($"Não existe Paciente com o ID {idPaciente}", ConsoleColor.Red);
            return;
        }

        List<RequisicaoDeSaida> requisicoes = repositorioRequisicaoDeSaida.SelecionarRegistros();

        List<RequisicaoDeSaida> requisicoesDoPaciente = new List<RequisicaoDeSaida>();

        foreach (RequisicaoDeSaida requisicao in requisicoes)
        {
            if (requisicao.Paciente.Id == paciente.Id)
            {
                requisicoesDoPaciente.Add(requisicao);
            }
        }

        if (requisicoesDoPaciente.Count == 0)
        {
            Notificador.ExibirMensagem("Nenhuma requisição encontrada para este paciente.", ConsoleColor.Red);
            return;
        }

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -30} | {4, -30}",
            "Id", "Data", "Paciente", "Prescrição Médica", "Medicamentos"
        );

        foreach (var r in requisicoesDoPaciente)
        {
            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -30} | {4, -30}",
                r.Id, r.Data, r.Paciente.Nome, r.PrescricaoMedica.CRM, r.MedicamentoRequisitado.Nome
            );
        }
    }

}
