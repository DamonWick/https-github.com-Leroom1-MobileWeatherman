using System;

namespace MobileWeatherman
{
    public class WeatherToDisplay
    {
        private double _temperature { get; }
        private double _windSpeed { get; }
        private int _airHumidity { get; }
        private long _sunrise { get; }
        private long _sunset { get; }

        public WeatherToDisplay()
        {
        }

        public WeatherToDisplay(double temperature, double windSpeed, int airHumidity, long sunrise, long sunset)
        {
            _temperature = temperature;
            _windSpeed = windSpeed;
            _airHumidity = airHumidity;
            _sunrise = sunrise;
            _sunset = sunset;
        }

        public string CurrentDate => DateTime.Now.Date.ToString("dd.MM.yyyy");
        public string Temperature => $"{_temperature} C";
        public string Wind => $"{_windSpeed} mph";
        public string Humidity => $"{_airHumidity}%";
        public string Sunrise => new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(_sunrise).TimeOfDay + " UTC";
        public string Sunset => new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(_sunset).TimeOfDay + " UTC";
    }
}
