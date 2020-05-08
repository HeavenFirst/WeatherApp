using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    class EnteringPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public EnteringPageViewModel()
        {
            DismissPageCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
            NoteText = "note";
            // PropertyChanged?.Invoke(this, args);
        }
        public Command DismissPageCommand { get; }

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                var args = new PropertyChangedEventArgs(nameof(NoteText));
                PropertyChanged?.Invoke(this, args);
            }
        }
    }
}
