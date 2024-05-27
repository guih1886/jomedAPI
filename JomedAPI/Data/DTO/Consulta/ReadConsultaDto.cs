using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JomedAPI.Data.DTO.Consulta;

public class ReadConsultaDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("medicoId")]
    public int MedicoId { get; set; }
    [JsonPropertyName("pacienteId")]
    public int PacienteId { get; set; }
    [JsonPropertyName("data")]
    public DateTime Data { get; set; }
}
