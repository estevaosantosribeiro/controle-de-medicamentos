using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedores
{
    class TelaFornecedor : TelaBase<Fornecedor> , ITelaCrud
    {
        public TelaFornecedor(IRepositorioFornecedor repositorio) : base("fornecedor", repositorio)
        {
 

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
        public override void ExibirTabela()
        {
            Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20} |" ,
                "id","nome","telefone" ,"Cnpj"
                );
        }

        public override void ExibirConteudoTabela(Fornecedor fornecedor)
        {
            Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20} |"
              , fornecedor.Id, fornecedor.Nome ,fornecedor.Telefone ,fornecedor.Cnpj );
        }
    
    }
}
