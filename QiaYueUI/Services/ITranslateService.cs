using QiaYue.UI.Models;
using System.Threading;
using System.Threading.Tasks;

namespace QiaYue.UI.Services;

public interface ITranslateService
{
    Task<TranslateResponse> TranslateAsync(TranslateRequest request, CancellationToken cancellationToken = default);
}