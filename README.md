# CMPG-323-PROJECT-2-35760338
The Development of API Web.

## About the project
I used Visual Studio to build the Web API. I created Controllers that I will use to manipulate database tables. The database and API Web are hosted on Microsoft Azure. Thereafter, I secured the API web to prevent other unauthorized users from accessing it.

## Microsoft Azure SetUp
+ Set up the account
+ Created a resource group called rgProject2API
+ Created an SQL Server
+ Added a database called Project2DB
+ Created an App service from Visual Studio

## Database and Tables
I created the tables on SQL Server Management Studio. Table names:
+ Client
+ Process
+ Project
+ JobTelemetry

## API Web User Guide
1. Run the API, It will open Swagger UI tab.
2. Register with your credentials on the POST authenticate/register endpoint.
3. Use your credentials to login on the POST authenticate/login.
4. If successful, you will get a token, copy it.
5. Go to the controller you want to access, at the top right-hand corner, click on the lock, a message box will appear with a textbox to paste the token you copied, click authorize, then execute.
6. You are successfully authorized to access the controllers.

## ENDPOINTS
### Clients Data
+ GET/api/Clients: retrieves all Clients entries from the database
+ POST/api/Clients: create a new Client entry on the data
+ GET/api/Clients{id}: retrieve one Client from the database based on the ID parsed through
+ PUT/api/Clients{id}: update Client database
+ DELETE/api/Clients{id}: delete an existing Client entry on the database

### JobTelemetries Data
+ GET/api/JobTelemetries: retrieves all Telemetry entries from the database
+ POST/api/JobTelemetries: create a new Telemetry entry on the database
+ GET/api/JobTelemetries{id}: retrieve one Telemetry from the database based on the ID parsed through
+ PUT/api/JobTelemetries{id}: update Telemetry database
+ PATCH/api/JobTelemetries{id}: update an existing Telemetry entry on the database
+ DELETE/api/JobTelemetries{id}: delete an existing Telemetry entry on the database
+ GET/api/JobTelemetries/GetSavingsProject: queries all telemetry per project and calculates the cumulative time and cost saved.
+ GET/api/JobTelemetries/GetSavingsClient: queries all telemetry per client and calculates the cumulative time and cost saved

### Processes Data
+ GET/api/Processes: retrieves all Processes entries from the database
+ POST/api/Processes: create a new Process entry on the data
+ GET/api/Processes{id}: retrieve one Process from the database based on the ID parsed through
+ PUT/api/Processes{id}: update Processes database
+ DELETE/api/Processes{id}: delete an existing Process entry on the database

### Projects Data
+ GET/api/Projects: retrieves all Projects entries from the database
+ POST/api/Projects: create a new Project entry on the data
+ GET/api/Projects{id}: retrieve one Project from the database based on the ID parsed through
+ PUT/api/Projects{id}: update Projects database
+ DELETE/api/Projects{id}: delete an existing Project entry on the database

### API Link
https://projecttwo35760338-dev.azurewebsites.net/ 

### Resource Group
https://portal.azure.com/#@nwuac.onmicrosoft.com/resource/subscriptions/4518c73e-ffcc-4821-9457-023e3f2a6f3d/resourceGroups/rgProject2API/overview 
