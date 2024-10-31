using ASP9.Models;
using Microsoft.AspNetCore.Mvc;

public class WeatherViewComponent : ViewComponent
{
    private readonly WeatherService _weatherService;

    public WeatherViewComponent(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string region)
    {
        WeatherInfo weatherInfo = await _weatherService.GetWeatherAsync(region);
        return View(weatherInfo);
    }
}
