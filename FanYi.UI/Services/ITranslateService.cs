using FanYi.UI.Models;

namespace FanYi.UI.Services;

public interface ITranslateService
{
    Task<TranslateResponse> TranslateAsync(TranslateRequest request, CancellationToken cancellationToken = default);
}