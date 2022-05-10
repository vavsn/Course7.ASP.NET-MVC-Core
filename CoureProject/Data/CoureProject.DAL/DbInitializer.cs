using CoureProject.DAL.Context;
using CoureProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace CoureProject.DAL;

public class DbInitializer
{
    private readonly CoureProjectDB _db;
    private readonly ILogger<DbInitializer> _logger;

    public DbInitializer(CoureProjectDB db, ILogger<DbInitializer> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<bool> RemoveDBAsync(CancellationToken cancel = default)
    {
        if(!await _db.Database.EnsureDeletedAsync(cancel).ConfigureAwait(false))
        {
            _logger.LogInformation("База данных отсутствует");
            return false;
        }

        _logger.LogInformation("База данных удалена");
        return true;

    }
    public async Task InitializeDBAsync(bool RemoveBefore = false, CancellationToken cancel = default)
    {
        if (RemoveBefore)
        {
            await RemoveDBAsync(cancel).ConfigureAwait(false);
        }

        await _db.Database.MigrateAsync(cancel).ConfigureAwait(false);

        _logger.LogInformation("БД создана");

        await AddData(cancel);
    }

    private async Task AddData(CancellationToken cancel = default)
    {
        if(!await _db.Consolidated_Weathers.AnyAsync(cancel).ConfigureAwait(false))
        {
            string jsonUrl = $"https://www.metaweather.com/api/location/2122265/";

            var webClient = new WebClient();

            string jsonUrl1 = webClient.DownloadString(jsonUrl);

            Consolidated_Weather weatherData = JsonSerializer.Deserialize<Consolidated_Weather>(jsonUrl1);

            await _db.Consolidated_Weathers.AddRangeAsync(weatherData, cancel);
            await _db.SaveChangesAsync(cancel);
        }
    }
}
