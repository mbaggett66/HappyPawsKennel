DEPLOYMENT: 
Deploying HappyPawsKennel to Azure- Step-by-Step Guide

This document explains step-by-step how to deploy the HappyPawsKennel ASP.NET 
Core MVC application to Azure App Service. Although the deployment of the 
application is simulated due to exhausted Azure student credits, the following
steps explain the actual process.

Steps:

Set up an Azure App Service- This is where you'll deploy your application.

1. Go to App Services, then Create.
2. Select your Resource Group.
3. Name app: HappyPawsKennelApp.
4. Publish Type: Code
5. Runtime Stack: .NET 9
6. Region: East US
7. Choose an App Service Plan (Free tier)
8. Click Review + Create.

Create an Azure Resource Group- This is where all the Azure services for your
app will live.

1. Go to the Azure Portal.
2. Select Resource Groups, then Create.
3. Name it HappyPawsKennel-RG
4. Choose a region (East US)
5. Click Review + Create.

Provision a SQL Database- HappyPawsKennel uses SQL Server.

1. Go to Azure Portal.
2. Go to SQL Database, then Create.
3. Resource group: HappyPawsKennel-RG
4. Database: HappyPawsKennelDB
5. Configure a SQL Server.

Configure Connection Strings and App Settings.

1. Go to Azure Portal.
2. Go to App Service, them Configuration, then Application Settings.
3. Add:
ConnectionStrings__DefaultConnection
ASPNETCORE_ENVIRONMENT = Production

Publish the App from Visual Studio.

1. Right-click the project, then click Publish.
2. Select Azure, then Azure App Service (Windows).
3. Choose the App Service: HappyPawsKennelApp
4. Click Publish.

Verify Deployment.

1. Use the assigned URL: https://happypawskennelapp.azurewebsites.net
2. Check routes:
/Dogs
/Kennels
/SearchByBreed


