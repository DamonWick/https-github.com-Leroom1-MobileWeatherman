using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileWeatherman
{
    public class WeatherStation
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    
    public partial class MainPage : ContentPage
    {
        public List<WeatherStation> ListOfWeatherStations = new List<WeatherStation> {
            new WeatherStation { Id = 6695624, Name = "Warszawa" },
            new WeatherStation { Id = 3093133, Name = "Łódź" },
            new WeatherStation { Id = 760778, Name = "Radom" },
            new WeatherStation { Id = 769250, Name = "Kielce" },
            new WeatherStation { Id = 3096576, Name = "Karpacz" },
            new WeatherStation { Id = 763534, Name = "Nowy Sącz" }
        };

        public MainPage()
        {
            InitializeComponent();
            foreach (var weatherStation in ListOfWeatherStations)
            {
                WeatherStationPicker.Items.Add(weatherStation.Name);
            }

            this.Title = "Weather forecast";
        }

        private async void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;

            var selectedElement = ListOfWeatherStations[picker.SelectedIndex];
            
            WeatherToDisplay weather = await Core.GetCurrentWeather(selectedElement.Id);
            this.BindingContext = weather;
        }
    }
}
