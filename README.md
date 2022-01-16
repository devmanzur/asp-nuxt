# Simple Cart

> A sample application that demonstrates how to wire up a nuxt js based front end SPA powered by an .NET 6 on the backend with Azure AD authentication.

The application it self is a simple shopping cart
With functionalities like, 
1. View products
2. Add product to cart
3. Manage cart
4. Authentication using Microsoft
5. Place an order
6. View orders

![screenshot](./app_screenshot_1.png)
![screenshot](./app_screenshot_2.png)
![screenshot](./app_screenshot_3.png)
![screenshot](./app_screenshot_4.png)

## Built With
- C#, JavaScript
- .NET 6, VueJs, NUXTJS, and Tailwind CSS

## Resources
- Setting up nuxt SPA with .NET (https://samwalpole.com/how-to-run-nuxt-from-a-aspnet-core-web-application)
- Protecting front end with Azure AD (https://stuartpreston.net/2020/05/azure-ad-pkce-spa-nuxt/)
- Protecting your resource API with Azure AD (https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-v2-aspnet-core-web-api)

### Prerequisites
- Docker or (.NET 6 and MSSQL Server database access and npm)
- Azure Portal Access
- Replace `process.env.IDENTITY_CLIENT_ID` inside nuxt.config.js with your Azure AD client Id
- Replace `process.env.API_ACESS_SCOPE` inside nuxt.config.js with the custom API Scope you created in Expose an API menu
- Replace `AZURE_AD_CLIENT_ID` inside appsettings.Development.json with your Azure AD client Id
- *If you are using docker, Replace `AZURE_AD_CLIENT_ID` inside docker-compose.override.yml with your Azure AD client Id

## Running Application in local environment using IDE
- Go to ClientApplication folder inside SimpleCart.Web and run npm install
- Replace the SimleCartDb connection string with your own connection string for MSSQL database
- Run the application

## Running Application on docker
- Go to the src directory and run `docker-compose up`
- The application should be available on http://localhost:8000

