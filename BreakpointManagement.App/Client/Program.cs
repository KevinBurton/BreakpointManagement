using BlazorState;
using BlazorTable;
using BreakpointManagement.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace BreakpointManagement.App.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44370/")
            };
            //httpClient.DefaultRequestHeaders.Add("Origin", "https://localhost:44311/");
            builder.Services.AddScoped(sp => httpClient);
            builder.Services.AddHttpClient<IBreakpointManagementDataService, BreakpointManagementDataService>(client => client.BaseAddress = new Uri("https://localhost:44370/"));
            builder.Services.AddBlazorTable();
            builder.Services.AddBlazorState
                  ((aOptions) =>
                    {
                        aOptions.UseReduxDevToolsBehavior = true;
                        aOptions.Assemblies =
                        new Assembly[]
                        {
                            typeof(Program).GetTypeInfo().Assembly,
                        };
                    });
            ConfigureServices(builder.Services);
            
            await builder.Build().RunAsync();
        }
        public static void ConfigureServices(IServiceCollection aServiceCollection)
        {

            aServiceCollection.AddBlazorState
            (
              (aOptions) =>
              {
                  aOptions.UseReduxDevToolsBehavior = true;
                  aOptions.Assemblies =
                  new Assembly[]
                  {
                    typeof(Program).GetTypeInfo().Assembly
                  };
              }
            );
        }
    }
}
