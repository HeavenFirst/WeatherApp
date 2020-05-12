using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
   //[XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class ViewDitails : ContentPage
    {
        public ViewDitails()
        {
            InitializeComponent();
        }
        public ViewDitails(Rain rain, Wind wind, Clouds clouds, Weather[] weather, Main main)
        {
            InitializeComponent();
           
            windSpeed.Text = wind.speed.ToString();
            pressure.Text = main.pressure.ToString();
            humidityTxt.Text = main.humidity.ToString();
            rainfall.Text =  (rain == null) ? "No rain" : rain._3h.ToString() ;           
        }
        private async void OnClickedBack(object sender, System.EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            button.BackgroundColor = Color.Red;
            await Navigation.PopModalAsync();
        }
         
        public void SomeMeth()
        {
            humidityTxt.Text = "";
        }
    }
}