# CodingChallenge
## Technologies
- ASP.NET Core 6
- Entity Framework Core 6
- Vue 3
- Bootstrap 5
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
2. Access folder *Backend* to open file *CommissionFactory.sln* with visual studio
3. Run command line with Package Manager Console to create database by using code first approach 
   `PM > Update-Database`
4. Start the project by pressing *F5*
5. Open Swagger with localhost port automatically
6. Access folder *Frontend* to open Vue with visual studio code
7. Run command line `npm install`
8. Copy localhost port in step 5 and replace value of environment *VUE_APP_BASE_URL* in file *.env.dev*
9. Run command line `yarn serve`
### Some changes to improve UI/UX
- [x] Move *Create a new task* from bottom to top to help the user see the button at first glance, what if the users has 1000 task records, the user has to scroll down to the bottom of the page to see it.
- [x] Truncate details if the details have more than 150 characters to avoid horizontal scroll, the user can hover on details to display tooltip with full details
- [x] Display Edit/Delete icons to help user aware these actions
- [x] Responsive with mobile/laptop view
- [x] Customize confirmation box UI when the user delete a task
- [ ] Pagination with 50 records by using infinite scroll
