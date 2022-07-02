# CodingChallenge
## Technologies
- ASP.NET Core 6
- Entity Framework Core 6
- Vue 3
- Bootstrap
- SQL Server
## Getting started
Use these instructions to get the project up and running.
### Prerequisites
You will need the following tools:
- Visual Studio Professtional
- MS SQL
- Node.js version 16
- NPM version 8
### Prerequisites
Follow these steps to get your development environment set up:

1. Clone the repository

2. Access folder *Backend* to open file *CommissionFactory.sln* with VS

3. Run command line with Package Manager Console to create database by using code first approach 
   `PM > Update-Database`

dotnet restore
Next, build the solution by running:

dotnet build
Next, within the \Src\WebUI\ClientApp directory, launch the front end by running:

npm start
Once the front end has started, within the \Src\WebUI directory, launch the back end by running:

dotnet run
Launch https://localhost:44376/ in your browser to view the Web UI

Launch https://localhost:44376/api in your browser to view the API



Visual Studio Code or Visual Studio 2019 (version 16.3 or later)
.NET Core SDK 3
Node.js (version 10 or later) with npm (version 6.11.3 or later)
