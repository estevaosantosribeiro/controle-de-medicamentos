using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedores
{
    public class RepositorioFornecedores : RepositorioBase<Fornecedor>
    {
        public RepositorioFornecedores(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Fornecedor> ObterRegistros()
        {
            return new List<Fornecedor>();
        }
    }
}
