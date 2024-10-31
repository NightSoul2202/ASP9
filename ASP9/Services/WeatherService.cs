using ASP9.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "2c54ec91d47f7f1a6cb260d7d6eb7f21";

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherInfo> GetWeatherAsync(string region)
    {
        var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={region}&units=metric&appid={_apiKey}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var weatherData = JsonDocument.Parse(json);

        return new WeatherInfo
        {
            Description = weatherData.RootElement.GetProperty("weather")[0].GetProperty("description").GetString(),
            Temperature = weatherData.RootElement.GetProperty("main").GetProperty("temp").GetDouble(),
            Humidity = weatherData.RootElement.GetProperty("main").GetProperty("humidity").GetDouble(),
            WindSpeed = weatherData.RootElement.GetProperty("wind").GetProperty("speed").GetDouble()
        };
    }
}
