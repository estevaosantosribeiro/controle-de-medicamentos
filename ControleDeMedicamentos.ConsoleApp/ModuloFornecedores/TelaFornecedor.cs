using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedores
{
    class TelaFornecedor : TelaBase<Fornecedor>
    {
        public TelaFornecedor(string nomeEntidade, IRepositorio<Fornecedor> repositorio) : base(nomeEntidade, repositorio)
        {
        }

        public override Fornecedor ObterDados(bool validacaoExtra)
        {
            Console.WriteLine("Informe o Nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o Telefone");
            string telefone = Console.ReadLine();
            Console.WriteLine("Informe o Cnpj");
            string cnpj = Console.ReadLine();

            Fornecedor fornecedor = new Fornecedor(nome, telefone, cnpj);

            return fornecedor;
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            Console.WriteLine("{0, -10} | {0, -10} | {0, -10}, {0, -10}");
            
        }
    }
}
