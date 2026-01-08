using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;
using WeatherApp1.Services;

namespace WeatherApp1.Views
{
    [QueryProperty(nameof(CityName), "city")]
    public partial class MainPage : ContentPage
    {
        public string CityName
        {
            set => LoadWeatherData(value);
        }

        public class WeatherHourly
        {
            public string Time { get; set; }
            public string Icon { get; set; }
            public int Temperature { get; set; }
        }

        public class WeatherWeekly
        {
            public string Date { get; set; }
            public string Icon { get; set; }
            public int HTemp { get; set; }
            public int LTemp { get; set; }
        }

        public class TimeCheck
        {
            public int hour = DateTime.Now.Hour;
            public bool CheckTime() => hour > 6 && hour < 18;
        }

        public ObservableCollection<WeatherHourly> HourlyWeather { get; set; } = new ObservableCollection<WeatherHourly>();
        public ObservableCollection<WeatherWeekly> WeeklyWeather { get; set; } = new ObservableCollection<WeatherWeekly>();

        private readonly WeatherService _weatherService = new WeatherService();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            SetupTheme();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (City.Text == "Loading..." || City.Text == "Montreal") 
            {
               await LoadWeatherData("Krakow");
            }
        }

        private async Task LoadWeatherData(string cityName)
        {
            var currentData = await _weatherService.GetCurrentWeather(cityName);
            if (currentData != null)
            {
                City.Text = currentData.name;
                MainTempLabel.Text = $"{(int)currentData.main.temp}℃";
                MainConditionLabel.Text = currentData.weather[0].description;
                MaxTempLabel.Text = $"H:{(int)currentData.main.temp_max}℃";
                MinTempLabel.Text = $"L:{(int)currentData.main.temp_min}℃";

                PressureLabel.Text = $"{currentData.main.pressure}";
                WindLabel.Text = $"{currentData.wind.speed}";
                HumidityLabel.Text = $"{currentData.main.humidity}";
                
                var sunriseTime = DateTimeOffset.FromUnixTimeSeconds(currentData.sys.sunrise).ToLocalTime();
                var sunsetTime = DateTimeOffset.FromUnixTimeSeconds(currentData.sys.sunset).ToLocalTime();
                
                SunriseLabel.Text = sunriseTime.ToString("HH:mm");
                SunsetLabel.Text = $"Sunset: {sunsetTime.ToString("HH:mm")}";
            }

            var forecastData = await _weatherService.GetForecast(cityName);
            if (forecastData != null)
            {
                HourlyWeather.Clear();
                WeeklyWeather.Clear();

                foreach (var item in forecastData.list.Take(8))
                {
                    var time = DateTime.Parse(item.dt_txt).ToString("HH:mm");
                    HourlyWeather.Add(new WeatherHourly
                    {
                        Time = time,
                        Temperature = (int)item.main.temp,
                        Icon = WeatherService.GetIconForCondition(item.weather[0].icon)
                    });
                }

                var dailyGroups = forecastData.list.GroupBy(x => DateTime.Parse(x.dt_txt).Date);
                foreach (var group in dailyGroups.Skip(1))
                {
                    var maxTemp = group.Max(x => x.main.temp);
                    var minTemp = group.Min(x => x.main.temp);
                    var iconCode = group.First().weather[0].icon;

                    WeeklyWeather.Add(new WeatherWeekly
                    {
                        Date = group.Key.ToString("dd.MM"),
                        HTemp = (int)maxTemp,
                        LTemp = (int)minTemp,
                        Icon = WeatherService.GetIconForCondition(iconCode)
                    });
                }
            }
        }

        private void SetupTheme()
        {
            TimeCheck timeCheck = new TimeCheck();
            string backgroundColorD = "#1a5f8a";

            if (timeCheck.CheckTime())
            {
                BackgroundImageSource = "day_background.png";
                FullBorder.Background = new LinearGradientBrush(
                    new GradientStopCollection {
                        new GradientStop(Color.FromArgb("#E64598cc"), 0),
                        new GradientStop(Color.FromArgb("#E6153142"), 1)
                    }, new Point(0, 0), new Point(1, 1));

                HourlyBox.BackgroundColor = Color.FromArgb(backgroundColorD);
                WeeklyBox.BackgroundColor = Color.FromArgb(backgroundColorD);
                AirQualityBox.BackgroundColor = Color.FromArgb(backgroundColorD);
                Box1.BackgroundColor = Color.FromArgb(backgroundColorD);
                Box2.BackgroundColor = Color.FromArgb(backgroundColorD);
                Box3.BackgroundColor = Color.FromArgb(backgroundColorD);
                Box4.BackgroundColor = Color.FromArgb(backgroundColorD);
            }
            else
            {
                BackgroundImageSource = "backgroundimage.png";
                FullBorder.Background = new LinearGradientBrush(
                    new GradientStopCollection {
                        new GradientStop(Color.FromArgb("#E695ABD9"), 0),
                        new GradientStop(Color.FromArgb("#E61F1D47"), 1)
                    }, new Point(0, 0), new Point(1, 1));
            }
        }

        private async void GoToAllWeathers(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AllWeathers));
        }
    }
}