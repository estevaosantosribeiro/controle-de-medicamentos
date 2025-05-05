using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedores
{
    class TelaFornecedor : TelaBase<Fornecedor> , ITelaCrud
    {
        public TelaFornecedor(IRepositorioFornecedor repositorio) : base("fornecedor", repositorio)
        {
            repositorioFornecedor = repositorio;

        }

        IRepositorioFornecedor repositorioFornecedor;

       

        public override bool ValidarInserirEditar(Fornecedor registroEditado, int idRegistro = -1)
        {
            bool validacao = repositorioFornecedor.VerificarCNPJ( registroEditado.Cnpj, idRegistro);

            if (!validacao)
            {
                Notificador.ExibirMensagem("Já existe um Fornecedor com este CNPJ", ConsoleColor.Red);
                return false;
            }

            return true;
        }

        public override Fornecedor ObterDados(bool validacaoExtra)
        {
            Console.WriteLine("Informe o Nome");
            string nome = Console.ReadLine()!;
            Console.WriteLine();
            Console.WriteLine("Informe o Telefone");
            Console.WriteLine();
            string telefone = Console.ReadLine()!;
            Console.WriteLine("Informe o Cnpj");
            Console.WriteLine();
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
