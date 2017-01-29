using System.Threading.Tasks;

namespace MobileWeatherman
{
    public class Core
    {
        public static async Task<WeatherToDisplay> GetWeatherForWarsaw()
        {
            const string key = "38d3f118f3e15607e38b19dfdbec7562";
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
