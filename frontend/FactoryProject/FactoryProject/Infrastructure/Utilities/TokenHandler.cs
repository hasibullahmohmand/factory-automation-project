using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace FactoryProject.Infrastructure.Utilities;

public class TokenHandler: DelegatingHandler
{
    private readonly TokenContainer _tokentContainer;    
    public TokenHandler(TokenContainer tokentContainer)
    {
        _tokentContainer = tokentContainer;
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token=_tokentContainer.Token;   
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",token);
        }
        return await base.SendAsync(request, cancellationToken);
    }
}
