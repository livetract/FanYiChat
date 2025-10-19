using System;

namespace QiaYue.UI.Models
{
    public class MessageItem
    {
        public string OriginalText { get; set; } = string.Empty;

        public string TranslatedText { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; }

        public string LanguageInfo { get; set; } = string.Empty;
    }
}
