using BreakpointManagement.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BreakpointManagement.App.Shared.Services
{
    public class BreakpointManagementDataService: IBreakpointManagementDataService
    {
        private readonly HttpClient _httpClient;

        public BreakpointManagementDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
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
            var response = await _httpClient.GetAsync($"api/breakpoint/breakpointcount");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<List<BreakpointSummary>> GetBreakpointByGroup(int projectId)
        {
            return await JsonSerializer.DeserializeAsync<List<BreakpointSummary>>
                    (await _httpClient.GetStreamAsync($"api/breakpoint/breakpointbygroup"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
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
    }
}
