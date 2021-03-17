using BreakpointManagement.ComponentLibrary;
using BreakpointManagement.Services;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Linq;
using Xunit;
using System;

namespace BereakpointManagement.Test.Integration
{
    public class ComponentTests : TestContext
    {
        [Fact]
        public void ProjectListComponentRenders()
        {
            // Arrange
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri("https://localhost:44370/");
            var service = new BreakpointManagementDataService(httpClient);
            Services.AddSingleton<IBreakpointManagementDataService>(service);

            //Act
            var cut = RenderComponent<BreakpointProjectPicker>();
            cut.WaitForState(() => cut.FindAll("label").FirstOrDefault()?.TextContent == "Project: ", TimeSpan.FromSeconds(5));

            // Assert
            Assert.Contains("select", cut.Markup);
            var options = cut.FindAll("option");
            Assert.True(options.Count > 0);
        }
        [Fact]
        public void DrugListComponentRenders()
        {
            // Arrange
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri("https://localhost:44370/");
            var service = new BreakpointManagementDataService(httpClient);
            Services.AddSingleton<IBreakpointManagementDataService>(service);

            //Act
            var cut = RenderComponent<ActiveDrugPicker>();
            cut.WaitForState(() => cut.FindAll("label").FirstOrDefault()?.TextContent == "Drug: ", TimeSpan.FromSeconds(30));

            // Assert
            Assert.Contains("select", cut.Markup);
            var options = cut.FindAll("option");
            Assert.True(options.Count > 0);
        }
        [Fact]
        public void OrganismListComponentRenders()
        {
            // Arrange
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri("https://localhost:44370/");
            var service = new BreakpointManagementDataService(httpClient);
            Services.AddSingleton<IBreakpointManagementDataService>(service);

            //Act
            var cut = RenderComponent<OrganismPicker>();
            cut.WaitForState(() => cut.FindAll("label").FirstOrDefault()?.TextContent == "Organism: ", TimeSpan.FromSeconds(30));

            // Assert
            Assert.Contains("select", cut.Markup);
            var options = cut.FindAll("option");
            Assert.True(options.Count > 0);
        }
        [Fact]
        public void BreakpointStandardListComponentRenders()
        {
            // Arrange
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri("https://localhost:44370/");
            var service = new BreakpointManagementDataService(httpClient);
            Services.AddSingleton<IBreakpointManagementDataService>(service);

            //Act
            var cut = RenderComponent<BreakpointStandardPicker>();
            cut.WaitForState(() => cut.FindAll("label").FirstOrDefault()?.TextContent == "Standard: ", TimeSpan.FromSeconds(30));

            // Assert
            Assert.Contains("select", cut.Markup);
            var options = cut.FindAll("option");
            Assert.True(options.Count > 0);
        }
    }
}
