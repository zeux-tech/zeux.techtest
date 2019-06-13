# Zeux Tech Test

## Background
This is a sample solution that implements the following set of requirements

Create the following web page: 

![alt text](http://bit.ly/2EzzpXo)

Please use a mobile first design approach. It’s a bonus if you can simply demonstrate fluid layout and responsive design when the screen size increases. 

The navigation bar should direct you to different routes. Routes other than “Assets” will be empty. The top bar with the title and the bottom navigation bar should always be visible. 

The “Opportunities” tab can be empty but should be integrated with routing. 

The “Savings, P2P, Funds” tabs can be empty but should be integrated with routing. 

The data to populate the list of investment products should be retrieved from a RESTful api. This api should be **secured** so that only authenticated users can retrieve it. 

You have the freedom to choose how you secure the api. An example would be using Http verb attributes, and authenticating a token for this API call. We don't need full authentication but we do expect you to demonstrate your understanding as to how an API endpoint can be restricted to authenticated users. 

You only need to retrieve 10 products each containing the following information 

Name 
Product Type 
Price 
Returns (e.g. 2.34% Yearly) 

## Application
- Startup project: Zeux.Test.Server

- Client: Angular 7.1.0
- Server: .NET Core 2.1 API
- Unit tests: Xunit
- Responsible design
- Authorization: JWT (JSON Web Tokens)

To run the application simple build and run Zeux.Test.sln in Visual Studio.
