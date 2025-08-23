using System;

namespace CashRegister.ConsoleApp.Menu.Actions;

public class StartTransactionAction : IMenuAction
{
    public string Name { get; } = "Start Transaction"; 

    public void Execute()
    {
        Console.WriteLine("Starting new transaction");
        //Add transaction logic here
        Console.WriteLine("Press Enter to return to menu"); 
        Console.ReadLine(); 
    }
}
