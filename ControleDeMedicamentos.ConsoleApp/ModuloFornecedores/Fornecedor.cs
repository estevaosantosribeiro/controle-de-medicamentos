using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedores
{
    public class Fornecedor : EntidadeBase<Fornecedor>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }


        public Fornecedor(string nome, string telefone, string cnpj)
        {
            Nome = nome;
            Telefone = telefone;
            Cnpj = cnpj;
        }


        public override void AtualizarRegistro(Fornecedor registroEditado)
        {
            Nome = registroEditado.Nome;
            Telefone = registroEditado.Telefone;
            Cnpj = registroEditado.Cnpj;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrEmpty(Nome))
                erros += "O campo Nome é obrigatorio !\n";

            if (string.IsNullOrEmpty(Telefone))
                erros += "O campo telefone é obrigatorio !\n";

            if (string.IsNullOrEmpty(Cnpj))
                erros += "O campo Cnpj é obrigatorio !\n";

            return erros;
        }
    }
}
