using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica
{
    public class TelaPrescricao : TelaBase<Prescricao>, ITelaCrud
    {
        public TelaPrescricao(Irepossitorio_Prescricao repositorio) : base("prescricão", repositorio)
        {


        }



        public override Prescricao ObterDados(bool validacaoExtra)
        {
            Console.WriteLine("Informe o CRM");
            string crm  = Console.ReadLine()!;

            Console.WriteLine("Informe o Id do medicamento ");
            int id = Convert.ToInt32(Console.ReadLine());

            
            Medicamento medicamento = new Medicamento();

            Prescricao prescricao = new Prescricao(crm, medicamento);

            return prescricao;
        }
        public override void ExibirTabela()
        {
            Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20} |",
                "id", "CRM", "Medicamento", "DATA"
                );
        }


        public override void ExibirConteudoTabela(Prescricao registro)
        {
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20} |",
                       registro.Id, registro.CRM, registro.Medicamento.Nome, registro.DATA.ToShortDateString()
                    );
            }
        }
    }
}
