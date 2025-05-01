using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
