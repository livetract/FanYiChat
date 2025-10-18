using System.Text.Json.Serialization;

namespace FanYi.UI.Models;

/// <summary>
/// 翻译结果项
/// </summary>
public class TranslationResult
{
    /// <summary>
    /// 源文本
    /// </summary>
    [JsonPropertyName("src")]
    public string? Source { get; set; }
    
    /// <summary>
    /// 翻译后的文本
    /// </summary>
    [JsonPropertyName("dst")]
    public string? Destination { get; set; }
}