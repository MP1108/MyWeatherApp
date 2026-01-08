using System.Collections.Generic;

namespace WeatherApp1.Services
{
    public class WeatherData
    {
        public string name { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }
        public long dt { get; set; }
        public int timezone { get; set; }
    }

    public class ForecastData
    {
        public List<ListElement> list { get; set; }
        public City city { get; set; }
    }

    public class ListElement
    {
        public long dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public string dt_txt { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double humidity { get; set; }
        public double pressure { get; set; }
    }

    public class Weather
    {
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
    }

    public class Sys
    {
        public long sunrise { get; set; }
        public long sunset { get; set; }
        public string country { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public int timezone { get; set; }
    }
}