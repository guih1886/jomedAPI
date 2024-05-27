using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using jomedAPI.Models.Enum;
using System.Text.Json.Serialization;

namespace jomedAPI.Models;

public class Consulta
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("medicoId")]
    public int MedicoId { get; set; }
    [ForeignKey("MedicoId")]
    public virtual required Medico Medico { get; set; }
    [JsonPropertyName("pacienteId")]
    public int PacienteId { get; set; }
    [ForeignKey("PacienteId")]
    public virtual required Paciente Paciente { get; set; }
    [JsonPropertyName("data")]
    public DateTime Data { get; set; }
    [JsonPropertyName("motivoCancelamento")]
    public MotivoCancelamento? MotivoCancelamento { get; set; }
    [JsonPropertyName("cancelado")]
    public bool Cancelado { get; set; }
}
