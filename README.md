# EasyDD_BackEnd
This project hosts the API and back-end for its sister project located [here](https://github.com/Miboch/EasyDD_FrontEnd)

## Features
 - Create User Accounts
 - Upload and group images
 - Live present images and swap between them in collaborative sessions
 - "Fog of war", where the presenter (Dungeon Master) can hide detail / tokens on the live presented images.
 - Add tags to images to more easily sort them.

## Installation
 - After downloading and extracting the project, open your terminal of choice and change directory into the project folder
 - Depending on your package manager of choice, run one of the following: 
    - `npm install`  
    - `yarn install`
    
**note:** If you utilize yarn, you may wish to delete `package-lock.json` to avoid conflicts.

## Getting Started
Once the project has been downloaded and installed you can easily get started by running the `start` command.

However, before running the project, check the `environment.json` file for runtime configuration options.

### Persisting data
To ensure no loss of data, open `environment.json` and set `inMemoryDB: false` as the application will otherwise save all data in memory only.
