using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeMedicamentos.ConsoleApp.ModuloEntrada;

public class Entrada : EntidadeBase<Entrada>
{
    public DateTime Data { get; set; }
    public Medicamento Medicamento { get; set; }
    public Funcionario Funcionario { get; set; }
    public int Quantidade { get; set; }

    public Entrada()
    {
    }

    public Entrada(DateTime data, Medicamento medicamento, Funcionario funcionario, int quantidade) : this()
    {
        Data = data;
        Medicamento = medicamento;
        Funcionario = funcionario;
        Quantidade = quantidade;
    }

    public override void AtualizarRegistro(Entrada registroEditado)
    {
        Data = registroEditado.Data;
        Medicamento = registroEditado.Medicamento;
        Funcionario = registroEditado.Funcionario;
        Quantidade = registroEditado.Quantidade;
    }

    public override string Validar()
    {
        string erros = "";

        if (Data > DateTime.Now)
            erros += "O campo 'Data' não pode ser do futuro\n";
        
        if (Medicamento == null)
            erros += "O campo 'Medicamento' deve ser válido\n";

        if (Funcionario == null)
            erros += "O campo 'Funcionário' deve ser válido\n";

        if (Quantidade < 0)
            erros += "O campo 'Quantidade' deve ser um número positivo\n";


        return erros;
    }
}
