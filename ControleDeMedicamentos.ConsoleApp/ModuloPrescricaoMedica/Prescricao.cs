using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

    public  class Prescricao : EntidadeBase<Prescricao>
    {
        public string CRM { get; set; }
        public DateTime DATA { get; set; }
        public Medicamento Medicamento { get; set; }

        public Prescricao(string crm, Medicamento medicamento)
        {
            CRM = crm;
            Medicamento = medicamento;



        }

        public override void AtualizarRegistro(Prescricao registroEditado)
        {
            registroEditado.CRM = registroEditado.CRM;
            registroEditado.Medicamento = registroEditado.Medicamento;
        }

    public override string Validar()
    {
        string erros = "";
        if (string.IsNullOrEmpty(CRM))
            erros += "O campo CRM é obrigatorio";

    

        if (Medicamento.Id == null)

            erros += "Informe um medicamento";


        return erros;
    }

 
}
    
    

