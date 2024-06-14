using jomedAPI.Models.Enum;

namespace JomedAPIForms.Models;

public class ConsultaFormatada
{
    public ConsultaFormatada(int idConsulta, Especialidade especialidade, string crm, string nomeMedico, string cpfPaciente, string nomePaciente, DateTime data)
    {
        IdConsulta = idConsulta;
        Especialidade = especialidade.ToString();
        Crm = crm;
        NomeMedico = nomeMedico;
        CpfPaciente = cpfPaciente;
        NomePaciente = nomePaciente;
        Data = data;
    }

    public int IdConsulta { get; set; }
    public string Especialidade { get; set; }
    public string Crm { get; set; }
    public string NomeMedico { get; set; }
    public string CpfPaciente { get; set; }
    public string NomePaciente { get; set; }
    public DateTime Data { get; set; }
}
