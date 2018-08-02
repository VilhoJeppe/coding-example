# coding-example
This document explains some architectural choices regarging implementation of the solution

To start solution: 
-Change database connection string to match SQL server in your database. 
-Set Sample.Server as Startup project and start debugging. Solution will create database automatically for now

Solution has 7 visual studio projects
Sample.DatabaseEF
-Encapsulates EF6 entities and datacontext.
-Code first used for speed as I nowadays do in the beginning of the project. Speeds up first stage database of development a lot.
-When database needs to be static later on, I use RoundHouse for database versioning

Sample.Services
-Main service for database access
-WCF-Service implementation
-Invokes managers through interfaces (in this case service uses IMovementManager)
-Maintains a collection of movements sent by other services (for demo purposes)
-When movement is received, handles concurrency and stores movement to internal collection
-When timer elapses, handles concurrency, uses manager interface to persist movement to database
-Retrieves movements straight from database
-Normally I would not store this kind of data to internal collection but something regards to scheduling or efficiency as services can locate over the network. 
-This is more to personally check if I can still to this from scratch

Sample.Businesslogic
-Manager implementation
-Managers persist and retrieve data to database with EF6
-Converts EF entities to DTO:s and back

Sample.BusinessLogicInterface
-Contain DTO:s (data transfer objects)
-Prevents dependency between Sample.Services and database

Sample.ServiceInterface.
-Contains datacontracts sent between services.
-If later on UI is implemented, prevents dependency between UI and Sample.Services

Sample.Server
-Handling IoC with Ninject to server and hosting the service in Console application

Sample.Device
-Maybe this will end up representing a mine loader device's WCF-service which will send movement events to persist to server on a certain time interval. 
-PLC runs on propably 1-2 ms frequency so could end up creating huge load to store to database

Sample.DeviceInterface
-Not implemented
-Will be simulating PLC-interface.
-Will be invoking .Net Events of movements to Sample.Device. These events will then be converted into notifications and sent to PersistingSvc
