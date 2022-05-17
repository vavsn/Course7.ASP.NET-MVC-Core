using CoureProject.Domain;
using CoureProject.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace CoureProject.WebAPI.Clients;

public class WeatherClient : IRepositoryAsync<Consolidated_Weather>
{
    private readonly HttpClient _client;
    public ILogger<WeatherClient> _logger { get; }

    public WeatherClient(HttpClient client, ILogger<WeatherClient> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<IEnumerable<Consolidated_Weather>> GetAllAsync(CancellationToken cancel = default)
    {
        var weathers = await _client
            .GetFromJsonAsync<IEnumerable<Consolidated_Weather>>("api/values", cancel)
            .ConfigureAwait(false);
        if (weathers is null)
        {
            throw new InvalidOperationException("Не удалось получить данные от сервиса");
        }
        return weathers;
    }

    public async Task<Consolidated_Weather?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        var weather = await _client
            .GetFromJsonAsync<IEnumerable<Consolidated_Weather>>($"api/values{id}", cancel)
            .ConfigureAwait(false);
        if (weather is null)
        {
            throw new InvalidOperationException("Не удалось получить данные от сервиса");
        }
        return (Consolidated_Weather?)weather;
    }

    public async Task<int> CountAsync(CancellationToken cancel = default)
    {
        var count = await _client
            .GetFromJsonAsync<int>("api/values/count", cancel)
            .ConfigureAwait(false);
        return count;
    }

    public Task<int> AddAsync(Consolidated_Weather item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Consolidated_Weather item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<Consolidated_Weather?> DeleteAsync(Consolidated_Weather item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }
}

