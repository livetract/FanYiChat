namespace FanYi.UI.Models
{
    /// <summary>
    /// 消息项模型
    /// </summary>
    public class MessageItem
    {
        /// <summary>
        /// 原始文本
        /// </summary>
        public string OriginalText { get; set; } = string.Empty;

        /// <summary>
        /// 翻译后的文本
        /// </summary>
        public string TranslatedText { get; set; } = string.Empty;

        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// 语言信息
        /// </summary>
        public string LanguageInfo { get; set; } = string.Empty;
    }
}
