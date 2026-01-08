# 🌤️ Pixel Weather App (.NET MAUI)

A stylish weather application built with **.NET MAUI**, featuring a unique pixel-art aesthetic. This app provides real-time weather data and a sleek dashboard for multiple cities.

## ✨ Features
- **Real-time Weather:** Fetches live data from OpenWeatherMap API.
- **City Dashboard:** Monitor weather for multiple cities in a scrollable list.
- **Fast Performance:** Uses asynchronous parallel data fetching for optimal speed.
- **Secure Configuration:** API keys are managed via a template system to keep them private.

## 📸 Preview
App design is based on a pixel-art theme:
![App Preview](https://github.com/MP1108/MyWeatherApp/raw/main/WeatherApp1/Resources/Images/pixel_art_preview.png)
*(Note: Replace this link with a direct path to your screenshot if needed)*

## 🚀 Setup & Installation
To protect my private API keys, they are not included in this repository. To run the app:
1. **Clone the repository:** `git clone https://github.com/MP1108/MyWeatherApp.git`
2. **Setup Config:** Go to `WeatherApp1/Services/`.
3. **Rename File:** Create a copy of `AppConfig.Example.cs` and name it `AppConfig.cs`.
4. **Add Key:** Open `AppConfig.cs` and insert your [OpenWeatherMap API Key](https://openweathermap.org/api).
5. **Run:** Open the solution in Rider or Visual Studio and hit Run.

## 🛠️ Tech Stack
- **Framework:** .NET MAUI
- **Language:** C# / XAML
- **Data:** Newtonsoft.Json (JSON Parsing)
- **Design Source:** [Weather App UI Design by Aksonvady](https://www.figma.com/community/file/11008262945364295)

---
*Created by [MP1108](https://github.com/MP1108)*
