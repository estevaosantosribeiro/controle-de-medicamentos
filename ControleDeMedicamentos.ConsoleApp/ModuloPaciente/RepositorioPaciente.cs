using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public class RepositorioPaciente : RepositorioBase<Paciente>, IRepositorioPaciente 
{
    public RepositorioPaciente(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Paciente> ObterRegistros()
    {
        return contexto.Pacientes;
    }

    public bool VerificarCartaoSUS(string cartao, int id = -1)
    {
        List<Paciente> pacientes = ObterRegistros();

        foreach (var paciente in pacientes)
        {
            if (paciente == null) continue;

            if (paciente.Id == id) continue;

            if (paciente.CartaoSUS == cartao) return false;
        }
        return true;
    }
}
