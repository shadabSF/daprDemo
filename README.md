# daprDemo

What is Dapr.
Dapr is an open-source runtime to build microservices applications. It provides a set of building blocks that simplify the development of distributed applications, such as service-to-service invocation, state management, pub/sub messaging.
It supports multiple programming languages, including .NET, Java, Node.js, Python, and Go.
One of the most compelling features of Dapr is its ability to provide code-level abstraction. By implementing Dapr in our application, we can significantly reduce our dependencies on cloud services. In fact, with Dapr.NET, we can achieve complete independence from cloud services and enjoy greater portability across different environments. This makes Dapr a powerful tool for building distributed applications that are flexible, portable, and easy to maintain.

DAPR ENVIRONMENT SETUP
First of all, We need to install DAPR CLI on Windows using the below command in powershell. Powershell should be open with admin mode.
powershell -Command "iwr -useb https://raw.githubusercontent.com/dapr/cli/master/install/install.ps1 | iex"
If this command is not working, Please copy the latest command from the below URL.
https://docs.dapr.io/getting-started/install-dapr-cli/
By default, Dapr uses Docker containers to provide you the best out-of-the-box experience.
So first of all install Docket Desktop on the system and check if docker is successfully installed and running with the below command.
docker ps or docker --v
Now, run the dapr command to setup the default environment of dapr
dapr init
This command will download the dependencies of dapr at global location. (C:\Users\username\).
Now we can check if dapr sidecar is working by executing the below command.
dapr run --app-id testappid  --dapr-http-port 3500 
Above command will launch the dapr sidecar on port number 3500 and appid will be testappid
Command to run applications with sidecar.
dapr run --app-id daprpoc  --dapr-http-port 3500 --app-port 7218 -- dotnet run
where daprpoc is the appid name, it can be anything but must be unique. 3500 is the port will be used by dapr sidecar and 7218 is the port of
application defined inside the launchsettings.json file.
Above running application will read all yaml files from a global location.
Command to run applications with sidecar and read all yaml files from custom location.
dapr run --app-id daprpoc  --dapr-http-port 3500  --components-path ./config --app-port 7218 -- dotnet run
config is the folder name and it must be present at the root folder of the application.
To open dapr UI run the following command
dapr dashboard
It will allow us to browse the dashboard at http://localhost:8080 where you can check the yaml configuration files present at global location and applications running through dapr sidecar.
Note - Required Dapr nuget packages are below:
Dapr.AspNetCore:
Dapr.Extensions.Configuration
