using System.Security.Claims;
using System.Text.Json;

namespace FactoryProject.Infrastructure.Extensions;

public static class JwtParser
{
    public static IEnumerable<Claim>? ParseClaimsFromJwt(string jwt)
    {
        if (string.IsNullOrEmpty(jwt))
           throw new ArgumentNullException(nameof(jwt), "JWT cannot be null or empty.");
        
        var payload = jwt.Split('.')[1];
        var bytes = ParseBase64WithPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(bytes);

        return keyValuePairs?.Select(kvp =>
        {
            var claimType = kvp.Key;
            var claimValue = kvp.Value.ToString() ?? string.Empty;
            return new Claim(claimType=="role"?ClaimTypes.Role:claimType, claimValue);
        });
    }
    public static DateTimeOffset GetExpirationDateFromClaims(IEnumerable<Claim> claims)
    {
        var expClaims = claims.FirstOrDefault(c => c.Type == "exp");
        return expClaims != null
            ? DateTimeOffset.FromUnixTimeSeconds(long.Parse(expClaims.Value))
            : DateTimeOffset.UtcNow.AddMinutes(30);
    }
    private static byte[] ParseBase64WithPadding(string base64)
    {
        int padding = base64.Length % 4;
        if (padding > 0)
        {
            base64 += new string('=', 4 - padding);
        }
        return Convert.FromBase64String(base64);
    }
}