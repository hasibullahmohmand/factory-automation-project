using System.Net.Http.Headers;

namespace FactoryProject.Infrastructure.Utilities;

public class TokenHandler(TokenContainer tokenContainer) : DelegatingHandler
{
    private readonly TokenContainer _tokenContainer = tokenContainer;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (!String.IsNullOrEmpty(_tokenContainer.Token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenContainer.Token);
       return await base.SendAsync(request, cancellationToken);
    }
}
