# Software 2 - Class Exercise 4
# Goal
Learn how to add Entity Framework Core to your project and write basic queries

# Instructions
## Database Setup
1. Create a new class library project in the solution called `PetStore.Data`.  Add a project reference from the `PetStore` project to the `PetStore.Data`.
1. Add the nuget package `Microsoft.EntityFrameworkCore.Sqlite` to that project.
1. Create a new class called `ProductContext`.  Use [this link](https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli#create-the-model) to guide you through setting up your `DbContext` class.  Feel free to either move the Product class or make a new class called `ProductEntity`.  Either way, `Product` will need to have a property called `ProductId`.
1. [Run these commands](https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio#create-the-database) to create your database.  I would advise following the PowerShell commands instead of the Visual Studio ones.
1. In the `PetStore.Data` project, add a class called `ProductRepository` and add an interface for it.
1. In the constructor of that class, create a new instance of `ProductContext` and assign it to a `private` `readonly` variable.
1. Add a method to add a product to the database.  Don't forget to call the `SaveChanges` method.
1. Add a method to get a product by it's id.
1. Add a method to get all products from the database.
1. Add the repository class to the services like you did with the `ProductLogic` class.
1. In the `ProductLogic` class.  Add a `private` `readonly` variable with the type being the interface for your repository class.  Add an argument to the constructor of the logic class of the type of the interface for your repository class.  Assign the argument to the private variable.
1. Replace the `AddProduct` code with a call to your repositories add method.
1. Change the `GetProductByName` method to no longer be generic, and change it's name to be `GetProductById`.  Replace the contents of the method with a call to your repositories get method.

## Clean Up
At this point, your application will probably have a bunch of errors.  That's fine, we'll go ahead and clean those up before testing the database.
Remove the following:
- DogLeash class
- CatFood class
- DryCatFood class
- The products list and both dictionaries from ProductLogic.
- GetOnlyInStockProducts from ProductLogic
- GetTotalPriceOfInventory from ProductLogic

Change the following:
- Update the validator to validate products now.  Add that to your ProductLogic add method.
- Update the program class to work with the new logic class.  You can remove options 3 and 4 completely.
- There will probably be some errors in using statements to clean up at this point too, so feel free to look around and fix errors as you see them.

## Test
1. Add a product to yor database.  
1. View your product
1. If this worked, congrats!  You just setup a database and connected it to your application.