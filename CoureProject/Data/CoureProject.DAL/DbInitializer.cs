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

    //private List<Weather> AddWeatherData(CancellationToken cancel)
    //{
    //    var LW = new List<Weather>();

    //    var nw = new Weather() {
    //        id = "5154488944951296",
    //        weather_state_name = "Light Rain",
    //        weather_state_abbr = "lr",
    //        wind_direction_compass = "NW",
    //        crt = new DateTime("2022-05-04T13:10:32.063531Z"),
    //        applicable_date = new DateOnly("2022-05-04"),
    //        min_temp = 3,535,
    //        max_temp = 9,38,
    //        the_temp = 8,2,
    //        wind_speed = 6,860322984967788,
    //        wind_direction = 309,55991141870467,
    //        air_pressure = 1012.5,
    //        humidity = 63,
    //        visibility = 13.174933389008192,
    //        predictability = 75
    //    };
    //    LW.Add(nw); 

    //    return LW;
    //}
    private async Task AddData(CancellationToken cancel = default)
    {
        if(!await _db.Weathers.AnyAsync(cancel).ConfigureAwait(false))
        {
            string jsonUrl = $"https://www.metaweather.com/api/location/2122265/";

            var webClient = new WebClient();

            string jsonUrl1 = webClient.DownloadString(jsonUrl);

            Consolidated_Weather weatherData = JsonSerializer.Deserialize<Consolidated_Weather>(jsonUrl1);

            await _db.Weathers.AddRangeAsync(weatherData.weathers, cancel);
            await _db.SaveChangesAsync(cancel);
        }
    }
}
