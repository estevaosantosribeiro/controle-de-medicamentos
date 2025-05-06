using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedores
{
    public class RepositorioPrescricao : RepositorioBase<Prescricao>, IrepossitorioPrescricao
    {
        public RepositorioPrescricao(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Prescricao> ObterRegistros()
        {
            return contexto.Prescricoes;
        }
    }
}
