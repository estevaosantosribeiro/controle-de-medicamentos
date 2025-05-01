using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

public interface IRepositorioFuncionario : IRepositorio<Funcionario>
{
    public bool VerificarCPF(string cpf, int id = -1);
}