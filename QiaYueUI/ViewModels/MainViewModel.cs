using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QiaYue.UI.Models;
using QiaYue.UI.Services;
using QiaYue.UI.Views.Components;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QiaYue.UI.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly ITranslateService _translateService;
        private readonly IDialogManager _dialog;

        public MainViewModel(
            ITranslateService translateService, 
            IDialogManager dialog)
        {
            _translateService = translateService;
            this._dialog = dialog;
        }


        private RelayCommand? _cmdSentTranslateMessageButton;
        public RelayCommand? CmdSentTranslateMessageButton =>
            _cmdSentTranslateMessageButton ??=
                new RelayCommand(PerformSentTranslateMessage);

        private async void PerformSentTranslateMessage()
        {
            var text = ChatInputText.Trim();
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("不能发送空内容哦！");
                return;
            }
            // todo
            await RunTranslateServiceAsync(_translateService, text);

            ChatInputText = "";
        }

        private async Task RunTranslateServiceAsync(ITranslateService translateService, string chatText)
        {
            if ((int)chatText[0] < 128)
            {
                // English input
                SourceLanguage = "en";
                DestinationLanguage = "zh";
            }
            else
            {
                SourceLanguage = "zh";
                DestinationLanguage = "en";
            }

            var c2e = new TranslateRequest { Query = chatText, From = SourceLanguage, To = DestinationLanguage };
            try
            {
                var result = await translateService.TranslateAsync(c2e);
                var sb = new StringBuilder();
                if (result.TranslationResults != null)
                {
                    foreach (var item in result.TranslationResults)
                    {
                        sb.AppendLine("原文：" + item.Source);
                        sb.AppendLine("译文：" + item.Destination);
                    }
                    ChatDisplayText = sb.ToString();
                }

            }
            catch (Exception ex)
            {
                ChatDisplayText = ex.Message;
            }

        }

        private string _chatInputText = string.Empty;

        public string ChatInputText { get => _chatInputText; set => SetProperty(ref _chatInputText, value); }

        private ObservableCollection<MessageItem>? _chatMessages;

        public ObservableCollection<MessageItem>? ChatMessages { get => _chatMessages; set => SetProperty(ref _chatMessages, value); }

        private string _chatDisplayText = "";

        public string ChatDisplayText { get => _chatDisplayText; set => SetProperty(ref _chatDisplayText, value); }

        private string _sourceLanguage = "auto";

        public string SourceLanguage { get => _sourceLanguage; set => SetProperty(ref _sourceLanguage, value); }

        private string _destinationLanguage = "zh";

        public string DestinationLanguage { get => _destinationLanguage; set => SetProperty(ref _destinationLanguage, value); }

        private RelayCommand cmdOpenConfigApiPageButton;
        public ICommand CmdOpenConfigApiPageButton => cmdOpenConfigApiPageButton ??= new RelayCommand(PerformCmdOpenConfigApiPage);

        private void PerformCmdOpenConfigApiPage()
        {
            _dialog.ShowDialog<AppConfigPage>();
        }
    }
}
