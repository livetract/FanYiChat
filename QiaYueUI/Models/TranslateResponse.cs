using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QiaYue.UI.Models
{
    public class TranslateResponse
    {
        [JsonPropertyName("error_code")]
        public string? ErrorCode { get; set; }

        [JsonPropertyName("error_msg")]
        public string? ErrorMessage { get; set; }

        [JsonPropertyName("from")]
        public string? From { get; set; }

        [JsonPropertyName("to")]
        public string? To { get; set; }

        [JsonPropertyName("trans_result")]
        public List<TranslationResult>? TranslationResults { get; set; }
    }
}