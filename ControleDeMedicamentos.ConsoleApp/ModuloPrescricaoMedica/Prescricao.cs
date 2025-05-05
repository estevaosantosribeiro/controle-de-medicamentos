using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

public class Prescricao : EntidadeBase<Prescricao>
{
    public string CRM { get; set; }
    public DateTime DATA { get; set; }
    public Medicamento Medicamento { get; set; }
    public string Dosagem { get; set; }

    public string Periodo  { get; set; }


    public Prescricao(string crm, Medicamento medicamento , string dosagem , string periodo)
    {
        CRM = crm;
        Medicamento = medicamento;
        DATA = DateTime.Now;
        Dosagem = dosagem;
        Periodo = periodo;




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



