using System;

namespace CashRegister.ConsoleApp.Menu.Actions;

public class ViewTillStatusAction : IMenuAction
{
    public string Name { get; } = "View Till Status";

    public void Execute()
    {
        Console.WriteLine("Displaying till status...");
        //Add Till logic here
        Console.WriteLine("Press Enter to return to menu");
        Console.ReadLine();
    }
}
