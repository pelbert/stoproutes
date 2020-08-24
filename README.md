This consists of two parts.  
Client and server.  
Server's primary function is to mock route data and return to the client. 
Client will get next two stops for each route based on selected stop. 
Client will refresh its data every minute after a selection is made. 
Client is expecting port 5001 of the server so start the service using the "StopService" debug option in Visual Studio
  "StopService": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "Stops",
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }




To run the client simply run NPM Install from the client directory followed by ng serve. 
Navigate to localhost:4200 


