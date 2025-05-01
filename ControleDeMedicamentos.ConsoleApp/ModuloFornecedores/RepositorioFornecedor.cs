using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
