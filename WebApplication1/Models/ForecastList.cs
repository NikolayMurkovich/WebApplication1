using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ForecastList
    {
        public string Dt_txt { get; set; }

        public WeatherMain Main { get; set; }

        public WeatherWind Wind { get; set; }

        public WeatherClouds Clouds { get; set; }
    }
}
