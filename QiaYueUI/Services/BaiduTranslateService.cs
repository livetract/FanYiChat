using QiaYue.UI.Models;
using QiaYue.UI.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace QiaYue.UI.Services
{

    public class BaiduTranslateService : ITranslateService
    {
        private readonly HttpClient _client;
        private readonly BaiduTranslateApi _api;

        public BaiduTranslateService(
            IHttpClientFactory httpClientFactory,
            IOptions<BaiduTranslateApi> api)
        {
            _client = httpClientFactory.CreateClient(nameof(BaiduTranslateApi));
            _api = api.Value;
        }


        public async Task<TranslateResponse> TranslateAsync(TranslateRequest request, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(request.Query))
            {
                throw new ArgumentException("翻译文本不能为空", nameof(request));
            }
            var salt = DateTime.Now.Millisecond.ToString();
            var sign = GenerateSign(request.Query, salt);
            var parameters = new Dictionary<string, string>
        {
            { "q", request.Query },
            { "from", request.From },
            { "to", request.To },
            { "appid", _api.AppId },
            { "salt", salt },
            { "sign", sign }
        };

            var queryString = new FormUrlEncodedContent(parameters);
            var url = $"{_api.ApiUrl}?{await queryString.ReadAsStringAsync(cancellationToken)}";

            try
            {
                var response = await _client.GetAsync(url, cancellationToken);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                var translateResponse = JsonSerializer.Deserialize<TranslateResponse>(responseContent);
                if (translateResponse == null)
                {
                    throw new InvalidOperationException("无法解析翻译响应");
                }
                if (!string.IsNullOrEmpty(translateResponse.ErrorCode))
                {
                    throw new Exception($"翻译失败: {translateResponse.ErrorCode} - {translateResponse.ErrorMessage}");
                }

                return translateResponse;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"HTTP请求错误: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception($"JSON解析错误: {ex.Message}", ex);
            }
        }

        private string GenerateSign(string query, string salt)
        {
            var signString = $"{_api.AppId}{query}{salt}{_api.AppKey}";

            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(signString);
                var hashBytes = md5.ComputeHash(inputBytes);

                var stringBuilder = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }

}