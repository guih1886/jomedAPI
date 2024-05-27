using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JomedAPI.Data.DTO.Consulta;

public class CreateConsultaDto
{
    public CreateConsultaDto(int medicoId, int pacienteId, DateTime data)
    {
        MedicoId = medicoId;
        PacienteId = pacienteId;
        Data = data;
    }

    [JsonPropertyName("medicoId")]
    [Required(ErrorMessage = "O id do médico não pode estar vazio")]
    public int MedicoId { get; set; }
    [JsonPropertyName("pacienteId")]
    [Required(ErrorMessage = "O id do paciente não pode estar vazio")]
    public int PacienteId { get; set; }
    [JsonPropertyName("data")]
    public DateTime Data { get; set; }
}
