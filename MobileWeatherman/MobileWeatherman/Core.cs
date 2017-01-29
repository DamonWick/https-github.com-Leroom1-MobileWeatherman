using System.Threading.Tasks;

namespace MobileWeatherman
{
    public class Core
    {
        public static async Task<WeatherToDisplay> GetCurrentWeatherForWarsaw()
        {
            const string key = "YOUR KEY GOES HERE";
            const int warsawId = 6695624;

            string queryString =
                $"http://api.openweathermap.org/data/2.5/weather?id={warsawId}&appid={key}&units=metric&mode=json";

            var response = await DataService.RequestDataFromService(queryString);
            var weatherDto = ResponseParser.Parse<WeatherDto>(response);

            return ConvertToWeatherForDisplay(weatherDto);
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
