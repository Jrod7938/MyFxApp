# MyFxApp – Forex Account Progress Tracker

MyFxApp is a multiplatform .NET MAUI application developed as a final project for the Microsoft Software & Systems Academy. It leverages the MyFxBook API to track forex account progress in real time. The app utilizes local SQLite caching (with a 5-minute refresh policy), MVVM architecture, dependency injection, and Microcharts for data visualization.

[MYFXAPP DOWNLOAD LINK](https://github.com/Jrod7938/MyFxApp/releases)

![MyFxApp Screenshot](https://github.com/user-attachments/assets/a7ea42a1-eb73-4253-8221-7a640af5ce1f)


---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Video Demo](#video-demo)
- [Usage](#usage)
- [Installation](#installation)
- [Project Structure](#project-structure)
- [Credits](#credits)
- [License](#license)

---

## Overview

MyFxApp is designed to help forex traders monitor their account performance on the go. The application:

- **Authenticates** with the MyFxBook API using user credentials.
- **Retrieves and caches** account details locally using SQLite.
- **Displays a list** of all forex accounts with custom widget images.
- **Shows detailed account information** along with historical performance charts powered by Microcharts.
- Utilizes a **clean MVVM architecture** with dependency injection for maintainability and future expansion.

---

## Features

- **Multi-Platform:** Runs on Windows, Android, iOS, and Mac Catalyst using .NET MAUI.
- **Real-Time Data:** Retrieves account data via the MyFxBook API and updates every 5 minutes.
- **Local Caching:** Uses SQLite for efficient local storage and caching.
- **Modern UI:** Implements a clean and responsive user interface with custom widget images and charts.
- **Data Visualization:** Visualizes historical forex data using Microcharts.
- **User Authentication:** Secure login and logout via MyFxBook API endpoints.
- **MVVM Architecture:** Provides a modular, scalable codebase suitable for further expansion.

---

## Video Demo

Watch the demonstration video showcasing the development of MyFxApp and showcasing it's key features and UI in action:  
[MyFxApp Development Video](https://www.youtube.com/watch?v=HsHktsUuUec)

---

## Usage

1. **Login:**  
   Enter your MyFxBook credentials to log in. The session is used for subsequent API calls.

2. **Accounts Screen:**  
   View a list of all your forex accounts. Each account displays a custom widget image and basic details.

3. **Account Details:**  
   Tap an account to view detailed information including open trades, orders, historical performance, and a performance chart.

4. **Logout:**  
   Use the Logout button in the toolbar to sign out.

---

## Installation

### Requirements

- .NET MAUI (latest stable release)
- Visual Studio 2022 (or later) with MAUI workload installed
- Access to the MyFxBook API (valid credentials)

### Setup

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/Jrod7938/MyFxApp.git
   cd MyFxApp
   ```

2. **Restore NuGet Packages:**

   ```bash
   dotnet restore
   ```

3. **Build and Run:**

   - **Windows:**
     ```bash
     dotnet maui run -f net8.0-windows10.0.19041.0
     ```
   - **Android:**
     ```bash
     dotnet maui run -f net8.0-android
     ```
   - **iOS:**
     ```bash
     dotnet maui run -f net8.0-ios
     ```
   - **Mac Catalyst:**
     ```bash
     dotnet maui run -f net8.0-maccatalyst
     ```

---

## Project Structure

- **App.xaml / AppShell.xaml:**  
  Defines the Shell navigation structure and global resources.

- **MauiProgram.cs:**  
  Configures dependency injection, registers services, view models, and views.

- **Models:**  
  Contains data models representing MyFxBook API responses (e.g., Account, OpenTrade, HistoryEntry).

- **Services:**  
  Provides API services (IMyFxBookApiService) and local storage (ILocalStorageService) for data retrieval and caching.

- **ViewModels:**  
  Implements MVVM logic for login, account listing, and account detail screens.

- **Views:**  
  Contains XAML pages for Login, Accounts, and Account Details screens.

---

## Credits

- **Developed by:** [Jancarlos Rodriguez](https://github.com/Jrod7938)
- **Microsoft Software & Systems Academy Final Project**
- **Powered by:** MyFxBook API, .NET MAUI, Microcharts, SQLite-net, and CommunityToolkit.MVVM

---

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/Jrod7938/MyFxApp/blob/master/LICENSE.txt) file for details.
