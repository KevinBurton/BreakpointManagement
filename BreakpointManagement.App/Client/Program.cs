using BlazorState.Redux.Extensions;
using BlazorState.Redux.Storage;
using BreakpointManagement.Services;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.BreakpointManagement;
using BreakpointManagement.Shared.State.Reducers;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakpointManagement.App.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Logging.AddConfiguration(
                builder.Configuration.GetSection("Logging"));

            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IBreakpointManagementDataService, BreakpointManagementDataService>(client => client.BaseAddress = new Uri("https://localhost:44370/"));
            services.AddReduxStore<BreakpointManagementState>(cfg =>
            {
                cfg.UseReduxDevTools();
                cfg.UseLocalStorage();
                // Store current page location in state
                cfg.TrackUserNavigation(s => s.Location);
                // Register Async actions
                // Register reducers
                cfg.Map<DrugReducer, Drug>(s => s.Drug);
                cfg.Map<OrganismReducer, OrganismName>(s => s.Organism);
                cfg.Map<ProjectReducer, Project>(s => s.Project);
                cfg.Map<StandardReducer, BreakpointStandard>(s => s.Standard);
                cfg.Map<GroupReducer, Breakpointgroup>(s => s.Group);

                cfg.Map<DrugListReducer, List<Drug>>(s => s.DrugList);
                cfg.Map<OrganismListReducer, IList<OrganismName>>(s => s.OrganismList);
                cfg.Map<ProjectListReducer, List<Project>>(s => s.ProjectList);
                cfg.Map<StandardListReducer, List<BreakpointStandard>>(s => s.StandardList);
                cfg.Map<GroupListReducer, List<Breakpointgroup>>(s => s.GroupList);
            });

            // register the Telerik services
            services.AddTelerikBlazor();
        }
    }
}
