/*
 The TransactionFactory class encapsulates the process of creating new Transaction 
 instances based on user input.  

 Key aspects:
 - Prompts the user to select a transaction type (Deposit or Withdrawal).  
 - Requests and validates the transaction amount.  
 - Prevents invalid operations, such as:
   • Withdrawals exceeding the current till balance.  
   • Transactions above the maximum allowed threshold (10,000).  
   • Non-numeric or negative amounts.  
*/

using System;
using CashRegister.Domain.Models;

namespace CashRegister.Application.Factories;

public class TransactionFactory
{
    public Transaction? CreateTransaction(Till till)
    {
        Console.WriteLine("Select Transaction Type:");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdrawal");

        string? input = Console.ReadLine();
        TransactionType type;
        switch (input)
        {
            case "1":
                type = TransactionType.Deposit;
                break;
            case "2":
                type = TransactionType.Withdrawal;
                break;
            default:
                Console.WriteLine("Invalid choice. Transaction cancelled.");
                Console.ReadLine();
                return null;
        }

        Console.Write("Enter transaction amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine("Invalid amount. Transaction cancelled.");
            Console.ReadLine();

            return null;
        }

        if (type == TransactionType.Withdrawal && amount > till.Balance)
        {
            Console.WriteLine("Refund denied. Not enough balance in the till.");
            Console.ReadLine();

            return null;
        }

        if (amount > 10000)
        {
            Console.WriteLine("Transaction exceeds allowed limit.");
            Console.ReadLine();

            return null;
        }

        return new Transaction(type, amount);
    }
}
