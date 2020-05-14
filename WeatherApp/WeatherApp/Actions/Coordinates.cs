using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WeatherApp.Actions
{
   public  class Coordinates
    {
        private string Location { get; set; } = "France";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Coordinates()
        {

        }
        public async Task<string> GetCoordinates()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Latitude = location.Latitude;
                    Longitude = location.Longitude;
                    Location = await GetCity(location);

                   // GetWetherInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
            return  Location;
        }

        private async Task<string> GetCity(Location location)
        {
            var places = await Geocoding.GetPlacemarksAsync(location);
            var currentPlace = places?.FirstOrDefault();

            if (currentPlace != null)
            {
                return $"{currentPlace.Locality},{currentPlace.CountryName}";
            }
            return null;
        }
    }
}
