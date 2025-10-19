using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using QiaYue.UI.Options;
using QiaYue.UI.Services;
using System.Windows.Input;

namespace QiaYue.UI.ViewModels
{
    internal class ConfigViewModel : ObservableObject
    {
        public ConfigViewModel(
            IOptions<BaiduTranslateApi> bdapi,
            IConfigFileManager config)
        {
            _apiModel = bdapi.Value;
            CheckItems();
            this._config = config;
        }

        private void CheckItems()
        {
            BdtApiID = _apiModel.AppId;
            BdtApiKEY = _apiModel.AppKey;
            BdtApiUrl = _apiModel.ApiUrl;
        }

        private string? _bdtApiID;

        public string? BdtApiID { get => _bdtApiID; set => SetProperty(ref _bdtApiID, value); }

        private string? _bdtApiKEY;

        public string? BdtApiKEY { get => _bdtApiKEY; set => SetProperty(ref _bdtApiKEY, value); }

        private string? _bdtApiUrl;
        private bool _allowModify;
        private BaiduTranslateApi _apiModel;

        public string? BdtApiUrl { get => _bdtApiUrl; set => SetProperty(ref _bdtApiUrl, value); }

        private RelayCommand cmdSubmitButton;
        private readonly IConfigFileManager _config;

        public ICommand CmdSubmitButton => cmdSubmitButton ??= new RelayCommand(PerformSubmit);

        private void PerformSubmit()
        {
            if (string.IsNullOrEmpty(BdtApiID) || string.IsNullOrEmpty(BdtApiKEY) || string.IsNullOrEmpty(BdtApiUrl))
            {
                System.Windows.MessageBox.Show("请填写完整信息！");
                return;
            }
            _config.CreateFile(App._AppSettingsFileFullPath,
                new ConfigModel
                {
                    BaiduTranslateApi = new BaiduTranslateApi
                    {
                        AppId = BdtApiID,
                        AppKey = BdtApiKEY,
                        ApiUrl = BdtApiUrl
                    }
                });

        }
    }
}
