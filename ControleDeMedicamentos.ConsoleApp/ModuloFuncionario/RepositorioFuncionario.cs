using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

public class RepositorioFuncionario : RepositorioBase<Funcionario>, IRepositorioFuncionario
{
    public RepositorioFuncionario(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Funcionario> ObterRegistros()
    {
        return contexto.Funcionarios;
    }

    public bool VerificarCPF(string cpf, int id = -1)
    {
        List<Funcionario> funcionarios = SelecionarRegistros();

        foreach (var funcionario in funcionarios)
        {
            if (funcionario == null) continue;

            if (funcionario.Id == id) continue;

            if (funcionario.CPF == cpf) return false;
        }
        return true;
    }
}
