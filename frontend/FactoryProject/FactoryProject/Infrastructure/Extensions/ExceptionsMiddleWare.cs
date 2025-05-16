using Microsoft.AspNetCore.Builder;

namespace FactoryProject.Infrastructure.Extensions;
public static class ExceptionsMiddleWare
{
    public static void UseNotFoundRazorPages(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            await next();

            if (context.Response.StatusCode == 404 && !context.Request.Path.StartsWithSegments("/_blazor"))
            {
                context.Request.Path = "/notfound"; // Redirige vers votre composant NotFound
                await next();
            }
        });
    }
}