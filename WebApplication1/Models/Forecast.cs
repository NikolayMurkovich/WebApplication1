using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Forecast
    {
        public List<ForecastList> List { get; set; }

        public CurrentCity City { get; set; }

    }
}
