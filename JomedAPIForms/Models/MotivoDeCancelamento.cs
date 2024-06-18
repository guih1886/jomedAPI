using jomedAPI.Models.Enum;
using System.Text.Json.Serialization;

namespace JomedAPIForms.Models;

public class MotivoDeCancelamento
{
    public MotivoDeCancelamento(MotivoCancelamento motivo)
    {
        motivoCancelamento = motivo;
    }

    [JsonPropertyName("motivoCancelamento")]
    public MotivoCancelamento motivoCancelamento { get; set; }
}
