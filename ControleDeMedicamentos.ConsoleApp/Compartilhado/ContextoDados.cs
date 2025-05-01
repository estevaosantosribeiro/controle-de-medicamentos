using System.Text.Json.Serialization;
using System.Text.Json;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;

namespace ControleDeMedicamentos.ConsoleApp.Compartilhado;

public class ContextoDados
{
    // Listas
    public List<Medicamento> Medicamentos { get; set; }
    public List<Paciente> Pacientes { get; set; }

    public List<Fornecedor> Fornecedor { get; set; }
    
    public List<Funcionario> Funcionarios { get; set; }

    private string pastaRaiz = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "AcademiaProgramador2025");
    private string arquivoArmazenamento = "dados.json";
    private string pastaPrincipal = "ControleDeMedicamentos";

    public ContextoDados()
    {
        // Criar Listas
        Medicamentos = new List<Medicamento>();
        Pacientes = new List<Paciente>();
        Funcionarios = new List<Funcionario>();
    }

    public ContextoDados(bool carregarDados) : this()
    {
        if (carregarDados)
            Carregar();
    }

    public void Salvar()
    {
        if (!Directory.Exists(pastaRaiz))
            Directory.CreateDirectory(pastaRaiz);

        string pastaProjeto = Path.Combine(pastaRaiz, pastaPrincipal);

        if (!Directory.Exists(pastaProjeto))
            Directory.CreateDirectory(pastaProjeto);

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.WriteIndented = true;
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        string caminhoCompleto = Path.Combine(pastaProjeto, arquivoArmazenamento);

        string json = JsonSerializer.Serialize(this, jsonOptions);

        File.WriteAllText(caminhoCompleto, json);
    }

    public void Carregar()
    {
        string pastaProjeto = Path.Combine(pastaRaiz, pastaPrincipal);

        string caminhoCompleto = Path.Combine(pastaProjeto, arquivoArmazenamento);

        if (!File.Exists(caminhoCompleto)) return;

        string json = File.ReadAllText(caminhoCompleto);

        if (string.IsNullOrWhiteSpace(json)) return;

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(json, jsonOptions)!;

        if (contextoArmazenado == null) return;
        
        // Carregar listas
        
        Pacientes = contextoArmazenado.Pacientes;
        Medicamentos = contextoArmazenado.Medicamentos;
        Funcionarios = contextoArmazenado.Funcionarios;
        Fornecedor = contextoArmazenado.Fornecedor;
    }
}
