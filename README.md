<h1 align="center">api-data-access</h1>

<p align="center">
  <a href="#about">About</a> •
  <a href="#features">Features</a> •
  <a href="#dependencies">Dependencies</a> •
  <a href="#building">Building</a> •
  <a href="#installation">Installation</a> •
  <a href="#usage">Usage</a> •
  <a href="#configuration">Configuration</a>
</p>

---

## About

The smart-meter-collector is a C# application designed to collect and process data from smart meters. It reads data from various energy sources, processes it, and stores it in a MongoDB database. The application is highly configurable via JSON configuration files, allowing users to easily adjust settings to fit their specific needs. It supports multiple energy sources such as Solar, Wind, and Other, and provides functionality for JSON serialization and file export.

## Features

- Collects data from smart meters.
- Supports multiple energy sources (Solar, Wind, Other).
- Stores data in MongoDB.
- Provides JSON serialization and file export functionality.
- Configurable via JSON configuration files.
- Secure API access with API key authentication.
- Supports HTTPS redirection.
- OpenAPI documentation for development environments


## Building


To build the project, use the following command:
```bash
dotnet build
```

## Installation

To install the project, clone the repository and navigate to the project directory:
```bash
git clone https://github.com/TriSAT-Collective/api-data-access.git
```
```bash
cd api-data-access
```

## Usage

To run the application, use the following command:
```bash
dotnet run
```

## Configuration

The application can be configured using a config.json file. Below is an example configuration:
```JSON
{
  "AppSettings": {
    "MongoDB": {
      "ConnectionString": "mongodb://root:password@localhost:27017",
      "SmartMeter": {
        "DatabaseName": "smartmeter_db"
      },
      "Weather": {
        "DatabaseName": "weather_db"
      }
    },
    "Api": {
      "PathBase": "/api",
      "ApiKey": "changeme"
    },
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
      }
    },
    "AllowedHosts": "*"
  }
}
```
