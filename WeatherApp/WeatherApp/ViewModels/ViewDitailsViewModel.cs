using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class ViewDitailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command OnClickedBackCommand { get; }
        string humidityTxt;
        string windSpeed;
        string pressure;
        string rainfall;

        public ViewDitailsViewModel()
        {

        }

        public ViewDitailsViewModel(Rain rain, Wind wind, Clouds clouds, Weather[] weather, Main main)
        {           
            OnClickedBackCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
            windSpeed = wind.speed.ToString();
            pressure = main.pressure.ToString();
            humidityTxt = main.humidity.ToString();
            rainfall = (rain == null) ? "No rain" : rain._3h.ToString();
        }

        public string HumidityTxt
        {
            get => humidityTxt;
            set
            {
                humidityTxt = value;
                var args = new PropertyChangedEventArgs(nameof(HumidityTxt));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string WindSpeed
        {
            get => windSpeed;
            set
            {
                windSpeed = value;
                var args = new PropertyChangedEventArgs(nameof(WindSpeed));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string Pressure
        {
            get => pressure;
            set
            {
                pressure = value;
                var args = new PropertyChangedEventArgs(nameof(Pressure));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string Rainfall
        {
            get => rainfall;
            set
            {
                rainfall = value;
                var args = new PropertyChangedEventArgs(nameof(Rainfall));
                PropertyChanged?.Invoke(this, args);
            }
        }
    }
}
