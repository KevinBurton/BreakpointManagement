using BreakpointManagement.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BreakpointManagement.Services
{
    public class BreakpointManagementDataService : IBreakpointManagementDataService
    {
        private readonly HttpClient _httpClient;

        public BreakpointManagementDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public HttpClient Client => _httpClient;
        public async Task<IEnumerable<Breakpoint>> GetAllBreakpoints()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Breakpoint>>
                    (await _httpClient.GetStreamAsync($"api/breakpoint"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task<Breakpoint> GetBreakpointDetails(int breakpointId)
        {
            return await JsonSerializer.DeserializeAsync<Breakpoint>
                (await _httpClient.GetStreamAsync($"api/breakpoint/{breakpointId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task<string> GetBreakpointCount(int projectId)
        {
            var response = await _httpClient.GetAsync($"api/breakpoint/count");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<IList<BreakpointProjectSummary>> GetBreakpointProject(int top = 100, int skip = 0, string sort = null)
        {
            var url = $"api/breakpoint/breakpointproject?top={top}&skip={skip}";
            if (!string.IsNullOrWhiteSpace(sort))
            {
                url += $"&sort={sort}";
            }
            return await JsonSerializer.DeserializeAsync<IList<BreakpointProjectSummary>>
                    (await _httpClient.GetStreamAsync(url), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task<string> GetBreakpointProjectCount()
        {
            var response = await _httpClient.GetAsync($"api/breakpoint/breakpointproject/count");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<IList<BreakpointSummary>> GetBreakpointByProject(int projectId, int top = 100, int skip = 0, string sort = null)
        {
            var url = $"api/breakpoint/project/{projectId}?top={top}&skip={skip}";
            if (!string.IsNullOrWhiteSpace(sort))
            {
                url += $"&sort={sort}";
            }
            return await JsonSerializer.DeserializeAsync<List<BreakpointSummary>>
                    (await _httpClient.GetStreamAsync(url), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task<string> GetBreakpointByProjectCount(int projectId)
        {
            var response = await _httpClient.GetAsync($"api/breakpoint/project/{projectId}/count");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<IEnumerable<Breakpointgroup>> GetAllBreakpointGroups()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Breakpointgroup>>
                    (await _httpClient.GetStreamAsync($"api/breakpointgroup"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Breakpointgroup> GetBreadpointGroupDetails(int breakpointGroupId)
        {
            return await JsonSerializer.DeserializeAsync<Breakpointgroup>
                (await _httpClient.GetStreamAsync($"api/breakpointgroup/{breakpointGroupId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task<IList<Drug>> GetAllDrugs(int top = 100, int skip = 0, string sort = null)
        {
            var url = $"api/drug?top={top}&skip={skip}";
            if (!string.IsNullOrWhiteSpace(sort))
            {
                url += $"&sort={sort}";
            }
            return await JsonSerializer.DeserializeAsync<IList<Drug>>
                    (await _httpClient.GetStreamAsync(url), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task<string> GetDrugCount()
        {
            var response = await _httpClient.GetAsync($"api/drug/count");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<IList<OrganismName>> GetAllOrganisms(int top = 100, int skip = 0, string sort = null)
        {
            var url = $"api/organismname?top={top}&skip={skip}";
            if(!string.IsNullOrWhiteSpace(sort))
            {
                url += $"&sort={sort}";
            }
            return await JsonSerializer.DeserializeAsync<IList<OrganismName>>
                    (await _httpClient.GetStreamAsync(url), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task<string> GetOrganismCount()
        {
            var response = await _httpClient.GetAsync($"api/organismname/count");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<IList<BreakpointStandard>> GetAllBreakpointStandards(int top = 100, int skip = 0, string sort = null)
        {
            var url = $"api/breakpointstandard?top={top}&skip={skip}";
            if (!string.IsNullOrWhiteSpace(sort))
            {
                url += $"&sort={sort}";
            }
            return await JsonSerializer.DeserializeAsync<IList<BreakpointStandard>>
                    (await _httpClient.GetStreamAsync(url), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task<string> GetBreakpointStandardCount()
        {
            var response = await _httpClient.GetAsync($"api/breakpointstandard/count");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
