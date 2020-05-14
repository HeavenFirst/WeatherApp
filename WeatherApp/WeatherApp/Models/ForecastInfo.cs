using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class ForecastInfo
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List[] list { get; set; }
        public City city { get; set; }
    }
}
