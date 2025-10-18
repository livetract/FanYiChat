namespace FanYi.UI.Models
{
    internal class InputTextItem
    {
        public string InputPlaceholder { get; set; } = "请在此处输入文本";
        public bool IsGotFocus { get; set; } = false;
        public string InputText { get; set; } = string.Empty;
    }
}
