using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloEntrada;

public class RepositorioEntrada : RepositorioBase<Entrada>, IRepositorioEntrada
{
    public RepositorioEntrada(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Entrada> ObterRegistros()
    {
        return contexto.Entradas;
    }
}
