using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        TelaPrincipal telaPrincipal = new TelaPrincipal();

        while (true)
        {
            telaPrincipal.ApresentarMenu();

            ITelaCrud telaSelecionada = telaPrincipal.ObterTela();

            if (telaSelecionada == null)
            {
                if (telaPrincipal.OpcaoPrincipal == "S")
                    return;

                Notificador.ExibirMensagem("Opção inválida!", ConsoleColor.Red);
                continue;
            }

            bool deveRodar = true;
            while (deveRodar)
            {
                string opcaoEscolhida = telaSelecionada.ApresentarMenu();

                if (telaSelecionada is TelaRequisicaoDeSaida)
                {
                    if (opcaoEscolhida == "5")
                    {
                        TelaRequisicaoDeSaida telaRequisicaoDeSaida = (TelaRequisicaoDeSaida)telaSelecionada;

                        telaRequisicaoDeSaida.VisualizarRequisicoesPorPaciente();
                    }
                }

                switch (opcaoEscolhida)
                {
                    case "1": telaSelecionada.CadastrarRegistro(); break;

                    case "2": telaSelecionada.EditarRegistro(); break;

                    case "3": telaSelecionada.ExcluirRegistro(); break;

                    case "4": telaSelecionada.VisualizarRegistros(true); break;

                    case "S": deveRodar = false; break;

                    default: Notificador.ExibirMensagem("Opção inválida!", ConsoleColor.Red); break;
                }
            }
        }
    }
}
