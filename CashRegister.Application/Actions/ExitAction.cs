using System;
using CashRegister.Application.Interfaces;

namespace CashRegister.Application.Actions;

public class ExitAction : IMenuAction
{
    public string Name { get; } = "Exit";

    public void Execute()
    {
        Console.WriteLine("Exiting application. Goodbye!");
    }
}
