using BreakpointManagement.ComponentLibrary;
using BreakpointManagement.Services;
using BreakpointManagement.Shared.Models;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BreakpointManagement.Test.Components
{
    public class ComponentTests : TestContext
    {
        [Fact]
        public void ProjectListComponentRenders()
        {
            var mockProjectList = new List<BreakpointProjectSummary>() { 
                new BreakpointProjectSummary()
                {
                    ProjectId = 0
                },
                new BreakpointProjectSummary()
                {
                    ProjectId = 1
                }, 
                new BreakpointProjectSummary()
                {
                    ProjectId = 2
                }, 
                new BreakpointProjectSummary()
                {
                    ProjectId = 3
                }, 
                new BreakpointProjectSummary()
                {
                    ProjectId = 4
                }
            };
            var expectedMarkup = "<div class=\"form-group row\"><label for=\"projects\" class=\"col-sm-3\">Project: </label>\n        <select name=\"projects\" id=\"projects\">" +
                                 String.Join("", mockProjectList.Select(p => $"<option value=\"{p}\">{p}</option>")) + "</select></div>";
            // Arrange
            var mockService = new Mock<IBreakpointManagementDataService>();
            mockService.Setup(s => s.GetBreakpointProject(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(mockProjectList);
            Services.AddSingleton<IBreakpointManagementDataService>(mockService.Object);

            //Act
            var cut = RenderComponent<ProjectPicker>();

            // Assert
            cut.MarkupMatches(expectedMarkup);

            Assert.Equal(5, cut.FindAll("option").Count);
        }
        [Fact]
        public void DrugListComponentRenders()
        {
            var mockDrugList = new List<Drug>() 
            { 
                new Drug()
                {
                    DrugId = 0,
                    DrugName = "Test0"
                },
                new Drug()
                {
                    DrugId = 1,
                    DrugName = "Test1"
                }, 
                new Drug()
                {
                    DrugId = 2,
                    DrugName = "Test2"
                },
                new Drug()
                {
                    DrugId = 3,
                    DrugName = "Test3"
                },
                new Drug()
                {
                    DrugId = 4,
                    DrugName = "Test4"
                }
            };
            var expectedMarkup = "<div class=\"form-group row\"><label for=\"drugs\" class=\"col-sm-3\">Drug: </label>\n        <select name=\"drugs\" id=\"drugs\">" +
                                 String.Join("", mockDrugList.Select(p => $"<option value=\"{p.DrugId}\">{p.DrugName}</option>")) + "</select></div>";
            // Arrange
            var mockService = new Mock<IBreakpointManagementDataService>();
            mockService.Setup(s => s.GetAllDrugs(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(mockDrugList);
            Services.AddSingleton<IBreakpointManagementDataService>(mockService.Object);

            //Act
            var cut = RenderComponent<ActiveDrugs>();

            // Assert
            cut.MarkupMatches(expectedMarkup);

            Assert.Equal(5, cut.FindAll("option").Count);
        }
        [Fact]
        public void OrganismListComponentRenders()
        {
            var mockOrganismList = new List<OrganismName>()
            {
                new OrganismName()
                {
                    OrganismId = 0,
                    Name = "Test0"
                },
                new OrganismName()
                {
                    OrganismId = 1,
                    Name = "Test1"
                },
                new OrganismName()
                {
                    OrganismId = 2,
                    Name = "Test2"
                },
                new OrganismName()
                {
                    OrganismId = 3,
                    Name = "Test3"
                },
                new OrganismName()
                {
                    OrganismId = 4,
                    Name = "Test4"
                }
            };
            var expectedMarkup = "<div class=\"form-group row\"><label for=\"organisms\" class=\"col-sm-3\">Organism: </label>\n        <select name=\"organisms\" id=\"organisms\">" +
                                 String.Join("", mockOrganismList.Select(p => $"<option value=\"{p.OrganismId}\">{p.Name}</option>")) + "</select></div>";
            // Arrange
            var mockService = new Mock<IBreakpointManagementDataService>();
            mockService.Setup(s => s.GetAllOrganisms(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(mockOrganismList);
            Services.AddSingleton<IBreakpointManagementDataService>(mockService.Object);

            //Act
            var cut = RenderComponent<OrganismPicker>();

            // Assert
            cut.MarkupMatches(expectedMarkup);

            Assert.Equal(5, cut.FindAll("option").Count);
        }
        [Fact]
        public void BreakpointStandardListComponentRenders()
        {
            var mockStandardList = new List<BreakpointStandard>()
            {
                new BreakpointStandard()
                {
                    BpstandardId = 0,
                    Bpstandard = "Test0"
                },
                new BreakpointStandard()
                {
                    BpstandardId = 1,
                    Bpstandard = "Test1"
                },
                new BreakpointStandard()
                {
                    BpstandardId = 2,
                    Bpstandard = "Test2"
                },
                new BreakpointStandard()
                {
                    BpstandardId = 3,
                    Bpstandard = "Test3"
                },
                new BreakpointStandard()
                {
                    BpstandardId = 4,
                    Bpstandard = "Test4"
                }
            };
            var expectedMarkup = "<div class=\"form-group row\"><label for=\"standards\" class=\"col-sm-3\">Standard: </label>\n        <select name=\"standards\" id=\"standards\">" +
                                 String.Join("", mockStandardList.Select(p => $"<option value=\"{p.BpstandardId}\">{p.Bpstandard}</option>")) + "</select></div>";
            // Arrange
            var mockService = new Mock<IBreakpointManagementDataService>();
            mockService.Setup(s => s.GetAllBreakpointStandards(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(mockStandardList);
            Services.AddSingleton<IBreakpointManagementDataService>(mockService.Object);

            //Act
            var cut = RenderComponent<BreakpointStandardPicker>();

            // Assert
            cut.MarkupMatches(expectedMarkup);

            Assert.Equal(5, cut.FindAll("option").Count);
        }
    }
}
