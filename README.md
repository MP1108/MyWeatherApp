# 🌤️ Pixel Weather App

<div align="center">

[![.NET MAUI](https://img.shields.io/badge/.NET-10.0-blueviolet?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/en-us/apps/maui)
[![Platform](https://img.shields.io/badge/Platform-Android%20%7C%20iOS%20%7C%20Windows%20%7C%20macOS-blue?style=for-the-badge)](https://dotnet.microsoft.com/en-us/apps/maui)
[![License: MIT](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)](https://opensource.org/licenses/MIT)
[![OpenWeatherMap](https://img.shields.io/badge/API-OpenWeatherMap-orange?style=for-the-badge)](https://openweathermap.org/api)

*A cross-platform weather application built with .NET 10 MAUI, featuring a pixel-art aesthetic and real-time data from OpenWeatherMap.*

<p align="center">
  <img src="WeatherApp1/Resources/Images/README_Images/homepageview.png" width="230" alt="Home Screen"/>
  &nbsp;&nbsp;
  <img src="WeatherApp1/Resources/Images/README_Images/View2.png" width="220" alt="Forecast & Details"/>
  &nbsp;&nbsp;
  <img src="WeatherApp1/Resources/Images/README_Images/View3.png" width="220" alt="All Cities"/>
</p>

</div>

---

## Features

| Feature | Details |
|---|---|
| **Current Weather** | Temperature, condition, humidity, wind, pressure |
| **Hourly Forecast** | Next 24h in 3-hour intervals |
| **10-Day Forecast** | Daily high/low with pixel icons |
| **Sunrise / Sunset** | Local times pulled from API |
| **Day / Night Theme** | Background and palette switch automatically |
| **Multi-City** | Save and browse multiple cities |

---

## Tech Stack

- **Framework:** .NET 10 MAUI
- **Language:** C# 13
- **API:** [OpenWeatherMap](https://openweathermap.org/api) — Current Weather, Forecast, Air Pollution endpoints
- **Serialization:** Newtonsoft.Json
- **Concurrency:** `Task.WhenAll` for parallel city fetching

---

## Getting Started

### Installation

**1. Clone the repo**
```bash
git clone https://github.com/MP1108/MyWeatherApp.git
cd pixel-weather-app
```

**2. Configure API key**

Copy the example config and fill in your key:
```bash
cp WeatherApp1/AppConfig.Example.cs WeatherApp1/AppConfig.cs
```

Edit `AppConfig.cs`:
```csharp
public static class AppConfig
{
    public const string OpenWeatherMapApiKey = "YOUR_API_KEY_HERE";
    public const string BaseUrl = "https://api.openweathermap.org/data/2.5/";
}
```

**3. Restore & run**
```bash
dotnet restore
dotnet build
```

---

## Day / Night Theming

Theme is determined at launch by local device time (06:00–18:00 = day):

```csharp
public class TimeCheck
{
    public int hour = DateTime.Now.Hour;
    public bool CheckTime() => hour > 6 && hour < 18;
}
```

Day → `day_background.png` + blue accent palette  
Night → `backgroundimage.png` + purple/indigo palette
