using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetStore;
using PetStore.Logic;
using PetStore.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

var services = CreateServiceCollection();

var productLogic = services.GetService<IProductLogic>();

string userInput = DisplayMenuAndGetInput();

while (userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        Console.WriteLine("Please add a Dog Leash in JSON format");
        var userInputAsJson = Console.ReadLine();
        var dogLeash = JsonSerializer.Deserialize<DogLeash>(userInputAsJson);
        productLogic.AddProduct(dogLeash);
    }
    if (userInput == "2")
    {
        Console.Write("What is the name of the dog leash you would like to view? ");
        var dogLeashName = Console.ReadLine();
        var dogLeash = productLogic.GetProductByName<DogLeash>(dogLeashName);
        Console.WriteLine(JsonSerializer.Serialize(dogLeash));
        Console.WriteLine();
    }
    if (userInput == "3")
    {
        Console.WriteLine("The following products are in stock: ");
        var inStock = productLogic.GetOnlyInStockProducts();
        foreach (var item in inStock)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
    if (userInput == "4")
    {
        Console.WriteLine($"The total price of inventory on hand is {productLogic.GetTotalPriceOfInventory()}");
        Console.WriteLine();
    }

    userInput = DisplayMenuAndGetInput();
}

static string DisplayMenuAndGetInput()
{
    Console.WriteLine("Press 1 to add a product");
    Console.WriteLine("Press 2 to view a Dog Leash Product");
    Console.WriteLine("Press 3 to view in stock products");
    Console.WriteLine("Press 4 to view the total price of current inventory");
    Console.WriteLine("Type 'exit' to quit");

    return Console.ReadLine();
}

static IServiceProvider CreateServiceCollection()
{
    return new ServiceCollection()
        .AddTransient<IProductLogic, ProductLogic>()
        .BuildServiceProvider();
}