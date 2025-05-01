using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedores
{
    public class RepositorioFornecedor : RepositorioBase<Fornecedor>, IRepositorioFornecedor
    {
        public RepositorioFornecedor(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Fornecedor> ObterRegistros()
        {
            return new List<Fornecedor>();
        }
    }
}
