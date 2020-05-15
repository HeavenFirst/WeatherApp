using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Actions;
using WeatherApp.Models;
using WeatherApp.StaticVariables;
using WeatherApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [DesignTimeVisible(false)]
    public partial class CurrentWeatherPage : ContentPage
    {
        public  CurrentWeatherPage()
        { 
                InitializeComponent();                
        }       
    }
}