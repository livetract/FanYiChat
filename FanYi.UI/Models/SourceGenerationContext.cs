using System.Text.Json.Serialization;

namespace FanYi.UI.Models
{
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(TranslateResponse))]
    internal partial class SourceGenerationContext : JsonSerializerContext
    {
    }

}
