using System.Text.Json.Serialization;

namespace FanYi.UI.Models;

public class TranslateResponse
{
    /// <summary>
    /// 错误代码，成功时为空
    /// </summary>
    [JsonPropertyName("error_code")]
    public string? ErrorCode { get; set; }
    
    /// <summary>
    /// 错误信息，成功时为空
    /// </summary>
    [JsonPropertyName("error_msg")]
    public string? ErrorMessage { get; set; }
    
    /// <summary>
    /// 源语言
    /// </summary>
    [JsonPropertyName("from")]
    public string? From { get; set; }
    
    /// <summary>
    /// 目标语言
    /// </summary>
    [JsonPropertyName("to")]
    public string? To { get; set; }
    
    /// <summary>
    /// 翻译结果列表
    /// </summary>
    [JsonPropertyName("trans_result")]
    public List<TranslationResult>? TranslationResults { get; set; }
}