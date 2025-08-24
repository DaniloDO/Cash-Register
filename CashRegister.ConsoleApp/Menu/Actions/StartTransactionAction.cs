using System;
using CashRegister.ConsoleApp.Factories;
using CashRegister.ConsoleApp.Models;

namespace CashRegister.ConsoleApp.Menu.Actions;

public class StartTransactionAction : IMenuAction
{
    private readonly Till _till;
    public string Name { get => "Start Transaction"; }

    public StartTransactionAction(Till till)
    {
        _till = till;
    }

    public void Execute()
    {
        var factory = new TransactionFactory();
        var transaction = factory.CreateTransaction(); 

        if (transaction == null)
            return; 
            
        _till.ApplyTransaction(transaction);
        Console.WriteLine($"Transaction recorded: {transaction.Type} of {transaction.Amount:C} on {transaction.Timestamp}");
        Console.WriteLine($"Till balance: {_till.Balance:C}");

        Console.WriteLine("Press Enter to return to menu");
        Console.ReadLine();
    }
}
