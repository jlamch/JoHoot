using Johoot.Data;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Johoot.Services
{
  public class QuizeService : IQuizeService
  {
    private readonly HttpClient _httpClient;

    public QuizeService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<IList<Quize>> GetAll(bool includeAll = true)
    {
      string relativeUri = $"{nameof(Quize)}?includeAll={includeAll}";
      return await JsonSerializer.DeserializeAsync<IList<Quize>>(
        await _httpClient.GetStreamAsync(relativeUri),
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<Quize> GetById(long id)
    {
      string relativeUri = $"{nameof(Quize)}/{id}?includeAll=true";
      return await JsonSerializer.DeserializeAsync<Quize>(
        await _httpClient.GetStreamAsync(relativeUri),
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<Quize> Create(Quize item)
    {
      string relativeUri = $"{nameof(Quize)}";
      var bodyJson =
             new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync(relativeUri, bodyJson);

      if (response.IsSuccessStatusCode)
      {
        return await JsonSerializer.DeserializeAsync<Quize>(
          await response.Content.ReadAsStreamAsync(),
          new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
      }

      return null;
    }

    public async Task Update(Quize item)
    {
      string relativeUri = $"{nameof(Quize)}/{item.Id}";
      var bodyJson =
                 new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

      await _httpClient.PutAsync(relativeUri, bodyJson);
    }
  }
}
