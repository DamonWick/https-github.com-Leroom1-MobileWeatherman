using Xamarin.Forms;

namespace MobileWeatherman
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Title = "Weather in Warsaw";
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            WeatherToDisplay weather = await Core.GetCurrentWeatherForWarsaw();
            this.BindingContext = weather;
        }
    }
}
