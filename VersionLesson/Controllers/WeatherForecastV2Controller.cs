using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using VersionLesson.Model;

namespace VersionLesson.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/weatherforecast")]
[ApiVersion("2.0")]
public class WeatherForecastV2Controller : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    /// <summary>
    /// Получает список прогнозов погоды на 5 дней.
    /// </summary>
    /// <remarks>
    /// Пример ответа:
    ///
    ///     GET /api/v2/weatherforecast
    ///     [
    ///       {
    ///         "date": "2026-07-14T00:00:00",
    ///         "temperatureC": 22,
    ///         "temperatureF": 72,
    ///         "summary": "Warm",
    ///         "windSpeed": 15
    ///       },
    ///       ...
    ///     ]
    /// </remarks>
    /// <returns>Массив объектов WeatherForecastV2</returns>
    /// <response code="200">Успешно возвращён список прогнозов</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<WeatherForecastV2>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IEnumerable<WeatherForecastV2> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastV2
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            WindSpeed = Random.Shared.Next(0, 100),
        })
        .ToArray();
    }
}
