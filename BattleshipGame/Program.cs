using BattleshipGame.Application;
using BattleshipGame.UI.Console;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Welcome to Battleship!");

// Set up the DI container.
var serviceCollection = new ServiceCollection();
Startup.ConfigureServices(serviceCollection);
var serviceProvider = serviceCollection.BuildServiceProvider();

// Resolve the Game instance from the container.
var game = serviceProvider.GetRequiredService<Game>();

while (!game.AreAllShipsSunk())
{
    Console.Write("Enter coordinates to fire between A1 - J10: ");
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Please enter a valid coordinate.");
        continue;
    }

    var message = game.FireShot(input);
    Console.WriteLine(message);
}

Console.WriteLine("All the ships have been sunk!");
