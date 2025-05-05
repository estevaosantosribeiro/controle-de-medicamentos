using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica
{
    public class TelaPrescricao : TelaBase<Prescricao>, ITelaCrud
    {
        public TelaPrescricao(Irepossitorio_Prescricao repositorio, IRepositorioMedicamento repositorioMedicamento) : base("prescricão", repositorio)
        {
           this.repositorioMedicamento = repositorioMedicamento;
        }
        IRepositorioMedicamento repositorioMedicamento;



        public void VisualizarMedicamentos()
        {
            Console.WriteLine($"Visualizando Medicamentos...");
            Console.WriteLine("---------------------------------");

            Console.WriteLine(
                "{0, -10} | {1, -21} | {2, -21} | {3, -10} | {4, -15}",
                "Id", "Nome", "Descrição", "Estoque", "Fornecedor"
            );

            List<Medicamento> medicamentos = repositorioMedicamento.SelecionarRegistros();

            foreach (var medicamento in medicamentos)
            {
                if (medicamento == null) continue;

                if (medicamento.Estoque <= 20) Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(
                    "{0, -10} | {1, -21} | {2, -21} | {3, -10} | {4, -15}",
                    medicamento.Id, medicamento.Nome, medicamento.Descricao, medicamento.Estoque, medicamento.Fornecedor.Nome
                );
                Console.ResetColor();
            }
        }

        public override Prescricao ObterDados(bool validacaoExtra)
        {
            Console.WriteLine("Informe o CRM");
            string crm  = Console.ReadLine()!;

     
            VisualizarMedicamentos();
            int idMedicamento = int.TryParse(Console.ReadLine(), out int valorMedicamento) ? valorMedicamento : -1;

            Medicamento medicamento = repositorioMedicamento.SelecionarRegistroPorId(idMedicamento);

            Console.WriteLine("Informe a dosagem desse");
            string dosagem = Console.ReadLine();

            Console.WriteLine("informe o periodo ");
            string periodo = Console.ReadLine();

            if (medicamento == null)
            {
                Notificador.ExibirMensagem($"Não existe Medicamento com o ID {idMedicamento}", ConsoleColor.Red);
                return null!;
            }



            Prescricao prescricao = new Prescricao(crm, medicamento, dosagem, periodo);

            return prescricao;
        }
        public override void ExibirTabela()
        {
            Console.WriteLine("{0,-10} | {1,-15} | {2,-20} | {3,-20} | |{4, -10} | {5, -10}",
                "id", "CRM", "Medicamento",   "Dosagem", "Periodo"  ,"DATA" );
        }


        public override void ExibirConteudoTabela(Prescricao registro)
        {
            {
                Prescricao r = registro;
                Console.WriteLine("{0,-10} | {1,-15} | {2,-20} | {3,-20} | |{4, -10} | {5, -10}",       
                r.Id, r.CRM, r.Medicamento.Nome,r.Dosagem,r.Periodo, r.DATA.ToShortDateString()
                    );
            }
        }
    }
}
