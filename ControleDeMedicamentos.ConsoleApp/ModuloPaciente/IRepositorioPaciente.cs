using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public interface IRepositorioPaciente : IRepositorio<Paciente>
{
    public bool VerificarCartaoSUS(string cartao, int id = -1);
}