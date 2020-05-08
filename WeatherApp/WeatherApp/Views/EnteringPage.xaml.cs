using System;
using System.Collections.Generic;
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

        private async void OnClickedBack(object sender, System.EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            button.BackgroundColor = Color.Red;
            await Navigation.PopModalAsync();
        }
    }
}