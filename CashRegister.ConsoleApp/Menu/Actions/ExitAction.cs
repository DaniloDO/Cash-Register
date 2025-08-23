using System;

namespace CashRegister.ConsoleApp.Menu.Actions;

public class ExitAction : IMenuAction
{
    public string Name { get; } = "Exit";

    public void Execute()
    {
        Console.WriteLine("Exiting application. Goodbye!");
    }
}
