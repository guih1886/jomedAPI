using jomedAPI.Models.Enum;
using System.Text.Json.Serialization;

namespace JomedAPI.Data.DTO.Consulta;

public class DeleteConsultaDto
{
    public DeleteConsultaDto(MotivoCancelamento? motivoCancelamento)
    {
        MotivoCancelamento = motivoCancelamento;
    }

    [JsonPropertyName("motivoCancelamento")]
    public MotivoCancelamento? MotivoCancelamento { get; set; }
}
