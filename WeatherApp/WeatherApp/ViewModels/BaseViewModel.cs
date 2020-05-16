using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeatherApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
		protected BaseViewModel()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
