using System.Text.Json.Serialization;

namespace QiaYue.UI.Models
{
    public class TranslationResult
    {
        [JsonPropertyName("src")]
        public string? Source { get; set; }

        [JsonPropertyName("dst")]
        public string? Destination { get; set; }
    }
}