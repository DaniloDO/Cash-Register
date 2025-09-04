/*
 The VoidTransactionAction class provides functionality for reversing or 
removing previously recorded transactions in the Till.  

 Key responsibilities include:
 - Allowing users to input and validate a transaction ID for voiding.  
 - Confirming user intent before modifying the Till state.  
 - Reversing the effects of deposits or withdrawals on the Till balance.  
 - Removing the specified transaction from the transaction history.  
*/

using System;
using CashRegister.Application.Interfaces;
using CashRegister.Domain.Models; 

namespace CashRegister.Application.Actions;

public class VoidTransactionAction : IMenuAction 
{
    private readonly Till _till;
    public string Name { get => "Void Transaction"; }
    public VoidTransactionAction(Till till)
    {
        _till = till;
    }

    public void Execute()
    {
        Console.WriteLine("Enter the ID of the transaction to void:");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input. Operation cancelled.");
            Console.ReadLine(); 
            return;
        }

        if (!Guid.TryParse(input, out Guid transactionId))
        {
            Console.WriteLine("Invalid ID format. Operation cancelled.");
            Console.ReadLine(); 
            return;
        }

        var transaction = _till.Transactions.FirstOrDefault(tx => tx.Id == transactionId);

        if (transaction == null)
        {
            Console.WriteLine("Transaction not found");
            Console.ReadLine(); 
            return;
        }

        Console.WriteLine($"Are you sure you want to void transaction {transaction.Id}? (y/n)");
        string? confirm = Console.ReadLine();

        if (confirm?.ToLower() != "y")
        {
            Console.WriteLine("Operation cancelled.");
            return;
        }

        _till.VoidTransactionAction(transaction); 
        Console.WriteLine("Transaction eliminated successfully"); 
        Console.ReadLine(); 
    }
}
