using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida;

public class RequisicaoDeSaida : EntidadeBase<RequisicaoDeSaida>
{
    public DateTime Data { get; set; }
    public Paciente Paciente { get; set; }
    public Prescricao PrescricaoMedica { get; set; }
    public Medicamento MedicamentoRequisitado { get; set; }

    public RequisicaoDeSaida()
    {

    }

    public RequisicaoDeSaida(DateTime data, Paciente paciente, Prescricao prescricaoMedica, Medicamento medicamentoRequisitado)
    {
        Data = data;
        Paciente = paciente;
        PrescricaoMedica = prescricaoMedica;
        MedicamentoRequisitado = medicamentoRequisitado;
    }

    public override void AtualizarRegistro(RequisicaoDeSaida registroEditado)
    {
        Data = registroEditado.Data;
        Paciente = registroEditado.Paciente;
        PrescricaoMedica = registroEditado.PrescricaoMedica;
        MedicamentoRequisitado = registroEditado.MedicamentoRequisitado;
    }

    public override string Validar()
    {
        string erros = "";

        if (Data == default(DateTime))
            erros += "O campo 'Data' é obrigatório e deve ser válido.\n";

        if (Paciente == null)
            erros += "O campo 'Paciente' é obrigatório.\n";

        if (PrescricaoMedica == null)
            erros += "O campo 'Prescrição Médica' é obrigatório.\n";

        if (MedicamentoRequisitado == null)
            erros += "O campo 'Medicamento' é obrigatório.\n";

        if (MedicamentoRequisitado != null && MedicamentoRequisitado.Estoque <= 0)
            erros += "Não há estoque disponível para o medicamento selecionado.\n";

        return erros;
    }
}
