# Beginner tasks

The purpose of this repository is to learn the structure of a web api based on dotnet with c#. First we will understand how to work with git, then how the project itself is structured and then we will proceed to build our very own **Random Quote Generator**. This generator will have an endpoint to give a random quote, the authers name, the years they have lived in and the category of said quote. The tasks will gradually extend the fuctionality of this service.

## Git

- Fork this repository
- Clone this repository locally
- Make a slight change to the files
- Commit the change
- push the changes

## First steps

- Look into the src folder and understand the project structure
- Build and run the project
- Open the swagger documentation of this project in the browser
- Call the weather endpoint
- Modify the weather endpoint to log the timestamp when it was triggered

## First controller

- Add your own quotation controller
- Add a get endpoint that returns a quote from a random set of quotes

## First Database

- Implement a database to store and retrieve quotes

## Further controller actions

- Add controller endpoints to add quotes
- Add controller endpoints to delete quotes
- Add controller endpoints to get all quotes of a specified author
- Add controller endpoints to get all quotes of a specified category

## Optimizations

- Add a limiter to how many quotes are being returned
