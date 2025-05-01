using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedores
{
    class TelaFornecedor : TelaBase<Fornecedor>
    {
        public TelaFornecedor(string nomeEntidade, IRepositorio<Fornecedor> repositorio) : base(nomeEntidade, repositorio)
        {
        }

        public override void ExibirConteudoTabela(Fornecedor registro)
        {
            throw new NotImplementedException();
        }

        public override void ExibirTabela()
        {
            throw new NotImplementedException();
        }

        public override Fornecedor ObterDados(bool validacaoExtra)
        {
            Console.WriteLine("Informe o Nome");
            string nome = Console.ReadLine()!;
            Console.WriteLine("Informe o Telefone");
            string telefone = Console.ReadLine()!;
            Console.WriteLine("Informe o Cnpj");
            string cnpj = Console.ReadLine()!;

            Fornecedor fornecedor = new Fornecedor(nome, telefone, cnpj);

            return fornecedor;
        }
    }
}
