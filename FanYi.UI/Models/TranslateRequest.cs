namespace FanYi.UI.Models;

/// <summary>
/// 百度翻译API请求参数模型
/// </summary>
public class TranslateRequest
{
    /// <summary>
    /// 源文本
    /// </summary>
    public string Query { get; set; } = string.Empty;
    
    /// <summary>
    /// 源语言，默认自动检测
    /// </summary>
    public string From { get; set; } = "auto";
    
    /// <summary>
    /// 目标语言
    /// </summary>
    public string To { get; set; } = "zh";
}