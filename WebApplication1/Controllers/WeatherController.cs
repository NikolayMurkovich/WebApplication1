using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet("/current/{name}")]
        public object GetCurrent(string name)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + name + "&units=metric&appid=c37bd644e32f7c0ebeaaa246de06be0b";
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                string response;

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }

                CurrentWeather weatherResponse = JsonConvert.DeserializeObject<CurrentWeather>(response);
                weatherResponse.Date = DateTime.Now.Date;
                return weatherResponse;
            }
            catch (Exception e)
            {
                Error errorResponse = new Error
                {
                    Messege = e.Message
                };
                return errorResponse;
            }
        }

        [HttpGet("/forecast/{name}")]
        public object GetForecast(string name)
        {
            try
            {
                string url = "http://api.openweathermap.org/data/2.5/forecast?q=" + name + "&units=metric&appid=c37bd644e32f7c0ebeaaa246de06be0b";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string response;

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }

                Forecast weatherResponse = JsonConvert.DeserializeObject<Forecast>(response);
                return weatherResponse;
            }
            catch (Exception e)
            {
                Error errorResponse = new Error
                {
                    Messege = e.Message
                };
                return errorResponse;
            }
        }
    }
}
