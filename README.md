# UHub Marketplace API (Development Version)
## Overview

Welcome to the Development Version of the Marketplace API! This API is actively under development and serves as the backend for a marketplace application. Feel free to observe or follow along with the development progress.

## Table of Contents
- [The Team](#The-Team)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
  - [Clone the Repository](#clone-the-repository)
  - [Database Setup](#database-setup)
  - [Configuration](#configuration)
- [Observing Development](#observing-development)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## The Team
The two developers currently working on this project are:

- Kinggoz18
- emmanuelU17

## Prerequisites

For the best experience such as having access to SwaggerUI please run on Visual Studio 2022. 
Make sure you have the following installed on your machine:

- [.NET SDK 7.0](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/)
- [Git](https://git-scm.com/downloads)

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/Kinggoz18/uHub_API.git
cd uHub_API
dotnet build
```

### Database Setup
Create a MySQL database for the application.

Add your appsettings.json and appsettings.Development.json files with your MySQL connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=YourDatabase;User=root;Password=YourPassword;"
  },
}
```
## Configuration

Adjust any additional configurations in the appsettings.json file, such as API keys, logging settings, etc.
Observing Development

To observe the development progress, you can:

    Check the commit history for recent changes.

## Current API Endpoints
- AppUser

Feel free to explore the available API endpoints in Swagger UI when the API is running.

## Contributing

Feel free to contribute ideas, suggestions, or feedback. For major changes, please open an issue first to discuss what you would like to change.
