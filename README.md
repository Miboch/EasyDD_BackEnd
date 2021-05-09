# EasyDD_BackEnd
This project hosts the API and back-end for its sister project located [here](https://github.com/Miboch/EasyDD_FrontEnd)

## Features
 - Create User Accounts
 - Upload and group images
 - Live present images and swap between them in collaborative sessions
 - "Fog of war", where the presenter (Dungeon Master) can hide detail / tokens on the live presented images.
 - Add tags to images to more easily sort them.

## Prerequisites
To run this project you must have the .NET 5 SDK installed on your computer.

[Find the latest version here](https://dotnet.microsoft.com/download/dotnet/5.0)

Additionally, you will need the `DotNet-EF tools` added to your CLI Globally

```powershell
# ADDING DOTNET-EF TOOLS GLOBALLY (requires the .NET CLI to be installed first):
dotnet tool install --global dotnet-ef   
```

If you already have the tooling installed, you can ensure it is updated by running the following command instead

```powershell
# UPDATING DOTNET-EF TOOLS GLOBALLY (requires the .NET CLI to be installed first):
dotnet tool update --global dotnet-ef
```

## Installation
 - After downloading and extracting the project, open your terminal of choice and change directory into the project folder
 - Run `dotnet restore`
 - Run the migration script to create the database file (first time only, or after cleanup) `npm run udb`
 - Once the database file has been created (default name 'easydd.db') inside the `.\easydd.web` folder you should be ready to run the project 
 
 ### Using NPM
 ```
 npm run start
 ```

### Using .NET

```
dotnet run --project easydd.web
``` 

The server should now be running on localhost:5001.
