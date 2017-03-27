using System.Threading.Tasks;

namespace MobileWeatherman
{
    public class Core
    {
        public static async Task<WeatherToDisplay> GetCurrentWeather(long stationId)
        {
            var weatherDto = await GetCurrentWeatherRaw(stationId);

            return ConvertToWeatherForDisplay(weatherDto);
        }

        public static async Task<WeatherDto> GetCurrentWeatherRaw(long stationId)
        {
            const string key = "YOUR KEY GOES HERE";

            string queryString =
                $"http://api.openweathermap.org/data/2.5/weather?id={stationId}&appid={key}&units=metric&mode=json";

            var response = await DataService.RequestDataFromService(queryString);
            var weatherDto = ResponseParser.Parse<WeatherDto>(response);
            return weatherDto;
        }

        private static WeatherToDisplay ConvertToWeatherForDisplay(WeatherDto results)
        {
            if (results == null)
                return new WeatherToDisplay();

            return new WeatherToDisplay(results.main.temp,
                results.wind.speed,
                results.main.humidity,
                results.sys.sunrise,
                results.sys.sunset);
        }
    }
}
