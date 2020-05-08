using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnteringPage : ContentPage
    {
        public EnteringPage()
        {
            InitializeComponent();
        }
        //string city;
        //public string City
        //{
        //    get => city;
        //    set
        //    {
        //        city = value;
        //        var args = new PropertyChangedEventArgs(nameof(City));
        //        PropertyChanged?.Invoke(this, args);
        //    }
        //}
        private async void OnClickedBack(object sender, System.EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            button.BackgroundColor = Color.Red;
            await Navigation.PopModalAsync();
        }

        private async void OnClickedWeather(object sender, System.EventArgs e)
        {           
            await Navigation.PushAsync(new CurrentWeatherPage("Mountain View,United States"));
        }
    }
}