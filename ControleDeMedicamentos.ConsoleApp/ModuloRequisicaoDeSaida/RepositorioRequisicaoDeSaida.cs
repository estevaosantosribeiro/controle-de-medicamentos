using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida;

public class RepositorioRequisicaoDeSaida : RepositorioBase<RequisicaoDeSaida>, IRepositorioRequisicaoDeSaida
{
    public RepositorioRequisicaoDeSaida(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<RequisicaoDeSaida> ObterRegistros()
    {
        return contexto.Saidas;
    }
}
