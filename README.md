# 🌤️ Pixel Weather App (.NET MAUI)

[![.NET MAUI](https://img.shields.io/badge/.NET-10.0-blueviolet)](https://dotnet.microsoft.com/en-us/apps/maui)
[![Platform](https://img.shields.io/badge/Platforms-Android%20|%20iOS%20|%20Windows%20|%20Mac-blue)](https://dotnet.microsoft.com/en-us/apps/maui)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

A cutting-edge, cross-platform weather application built with **.NET 10 MAUI**, featuring a unique pixel-art aesthetic.

---

## 📸 Preview
<p align="center">
  <img src="WeatherApp1/Resources/Images/README_Images/homepageview.png" width="350" alt="Pixel Weather App Interface">
</p>

## ✨ Technical Highlights
* **Built on .NET 10:** Leveraging the latest performance optimizations and language features of C#.
* **Modern API Integration:** Robust consumption of OpenWeatherMap API services.
* **Optimized Concurrency:** Utilizes `Task.WhenAll` for non-blocking, parallel city data fetching.
* **Secure Configuration:** API keys are managed via a template system (`AppConfig.Example.cs`) to prevent exposure of sensitive credentials.

## 🛠️ Tech Stack
* **Framework:** .NET MAUI v10.0
* **Language:** C#
* **Architecture:** MVVM (Model-View-ViewModel)
* **Libraries:** Newtonsoft.Json

## 📂 Project Structure
```text
WeatherApp1/
├── Services/          # Data Providers & API Clients
├── Views/             # XAML Pages
├── Models/            # POCO Classes
└── Resources/         # Pixel-art Assets & Fonts
