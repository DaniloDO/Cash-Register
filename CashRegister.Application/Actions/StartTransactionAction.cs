using System;
using CashRegister.Domain.Models; 
using CashRegister.Application.Factories;
using CashRegister.Application.Interfaces;

namespace CashRegister.Application.Actions;

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
        var transaction = factory.CreateTransaction(_till); 

        if (transaction == null)
            return; 
            
        _till.ApplyTransaction(transaction);
        Console.WriteLine($"Transaction recorded: {transaction.Type} of {transaction.Amount:C} on {transaction.Timestamp}");
        Console.WriteLine($"Till balance: {_till.Balance:C}");

        Console.WriteLine("Press Enter to return to menu");
        Console.ReadLine();
    }
}
