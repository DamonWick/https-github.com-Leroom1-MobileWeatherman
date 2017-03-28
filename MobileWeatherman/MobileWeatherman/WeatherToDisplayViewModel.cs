using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileWeatherman
{
    public class WeatherToDisplayViewModel : INotifyPropertyChanged
    {
        private double _humidity;

        private int _selectedWeatherStationIndex;

        private string _sunrise;

        private string _sunset;

        private double _temperature;

        private double _wind;

        public static List<WeatherStation> ListOfWeatherStations = new List<WeatherStation>
        {
            new WeatherStation {Id = 6695624, Name = "Warszawa"},
            new WeatherStation {Id = 3093133, Name = "Łódź"},
            new WeatherStation {Id = 760778, Name = "Radom"},
            new WeatherStation {Id = 769250, Name = "Kielce"},
            new WeatherStation {Id = 3096576, Name = "Karpacz"},
            new WeatherStation {Id = 763534, Name = "Nowy Sącz"}
        };

        public string CurrentDate => DateTime.Now.Date.ToString("dd.MM.yyyy");

        public double Temperature
        {
            get { return _temperature; }
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Wind
        {
            get { return _wind; }
            set
            {
                if (_wind != value)
                {
                    _wind = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Humidity
        {
            get { return _humidity; }
            set
            {
                if (_humidity != value)
                {
                    _humidity = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Sunrise
        {
            get { return _sunrise; }
            set
            {
                if (_sunrise != value)
                {
                    _sunrise = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Sunset
        {
            get { return _sunset; }
            set
            {
                if (_sunset != value)
                {
                    _sunset = value;
                    OnPropertyChanged();
                }
            }
        }

        public int SelectedWeatherStationIndex
        {
            get { return _selectedWeatherStationIndex; }
            set
            {
                if (_selectedWeatherStationIndex != value)
                {
                    _selectedWeatherStationIndex = value;
                    OnPropertyChanged();
                    GetWeatherCommand.Execute(value);
                }
            }
        }

        public Command GetWeatherCommand;

        public WeatherToDisplayViewModel()
        {
            GetWeatherCommand = new Command<int>(async (selectedItemIndex) => await GetWeather(selectedItemIndex));
        }

        private async Task GetWeather(int selectedItemIndex)
        {
            var selectedStation = ListOfWeatherStations[(int)selectedItemIndex];
            var weather = await Core.GetCurrentWeatherRaw(selectedStation.Id);
            
            Temperature = weather.main.temp;
            Wind = weather.wind.speed;
            Humidity = weather.main.humidity;
            Sunrise = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(weather.sys.sunrise).TimeOfDay + " UTC";
            Sunset = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(weather.sys.sunset).TimeOfDay + " UTC";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}