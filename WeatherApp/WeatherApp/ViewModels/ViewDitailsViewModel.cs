using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class ViewDitailsViewModel : BaseViewModel 
    {
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
            WindSpeed = wind.speed.ToString();
            Pressure = main.pressure.ToString();
            HumidityTxt = main.humidity.ToString();
            Rainfall = (rain == null) ? "No rain" : rain._3h.ToString();
        }
        #region Properties
        public string HumidityTxt
        {
            get => humidityTxt;
            set
            {
                humidityTxt = value;
                OnPropertyChanged(HumidityTxt);
            }
        }

        public string WindSpeed
        {
            get => windSpeed;
            set
            {
                windSpeed = value;
                OnPropertyChanged(WindSpeed);
            }
        }

        public string Pressure
        {
            get => pressure;
            set
            {
                pressure = value;
                OnPropertyChanged(Pressure);
            }
        }

        public string Rainfall
        {
            get => rainfall;
            set
            {
                rainfall = value;
                OnPropertyChanged(Rainfall);
            }
        }
        #endregion
    }
}
