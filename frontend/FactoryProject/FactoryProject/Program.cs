using FactoryProject.Components;
using FactoryProject.DependencyInjection;
using FactoryProject.Infrastructure.Extensions;
using Blazored.LocalStorage;

namespace FactoryProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddBlazoredLocalStorage(); 

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor()
                            .AddCircuitOptions(options =>
                            { options.DetailedErrors = true; });

            builder.Services.AddDistributedMemoryCache();
            builder.Services.RegisterServices();
            builder.Services.ConfigureAuthentication();
            builder.Services.ConfigureApiSettings(builder.Configuration);
            builder.Services.AddCascadingAuthenticationState();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAntiforgery();

            app.MapRazorPages();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
         
}
