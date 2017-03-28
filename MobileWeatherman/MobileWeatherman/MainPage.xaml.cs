using Xamarin.Forms;

namespace MobileWeatherman
{
    public partial class MainPage : ContentPage
    {
        private WeatherToDisplayViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();

            ViewModel = new WeatherToDisplayViewModel();
            foreach (var weatherStation in WeatherToDisplayViewModel.ListOfWeatherStations)
            {
                WeatherStationPicker.Items.Add(weatherStation.Name);
            }

            this.BindingContext = ViewModel;
        }
    }
}S
