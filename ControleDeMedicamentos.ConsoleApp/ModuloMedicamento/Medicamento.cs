using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedores;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

public class Medicamento : EntidadeBase<Medicamento>
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Estoque { get; set; }
    public Fornecedor Fornecedor { get; set; } // Alterar para classe quando implementada

    public Medicamento()
    {
    }

    public Medicamento(string nome, string descricao, int estoque, Fornecedor fornecedor) : this()
    {
        Nome = nome;
        Descricao = descricao;
        Estoque = estoque;
        Fornecedor = fornecedor;
    }

    public override void AtualizarRegistro(Medicamento registroEditado)
    {
        Nome = registroEditado.Nome;
        Descricao = registroEditado.Descricao;
        Estoque = registroEditado.Estoque;
        Fornecedor = registroEditado.Fornecedor;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome)) 
            erros += "O campo 'Nome' é obrigatório\n";
        else if (Nome.Length < 3 || Nome.Length > 100) 
            erros += "O campo 'Nome' deve conter entre 3-100 caracteres\n";
        
        if (string.IsNullOrWhiteSpace(Descricao))
            erros += "O campo 'Descrição' é obrigatório\n";
        else if (Descricao.Length < 5 || Descricao.Length > 255)
            erros += "O campo 'Descrição' deve conter entre 5-255 caracteres\n";

        if (Estoque < 0)
            erros += "O campo 'Estoque' deve conter um número positivo\n";

        if (Fornecedor == null)
            erros += "O campo 'Fornecedor' precisa ser válido\n";

        return erros;
    }
}
