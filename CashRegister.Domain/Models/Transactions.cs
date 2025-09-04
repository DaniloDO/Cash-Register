/*
 The Transaction class represents a single financial operation within the 
 cash register. 

 Key properties include:
 - A unique identifier (Id) to distinguish each transaction. 
 - The type of transaction (deposit or withdrawal) as defined by the 
   TransactionType enum. 
 - The amount of money involved, validated to ensure it is greater than zero. 
 - A timestamp marking when the transaction occurred. 
*/

using System;

namespace CashRegister.Domain.Models;

public class Transaction
{
    public Guid Id { get; }
    public TransactionType Type { get; private set; }
    public DateTime Timestamp { get; private set; }
    public decimal Amount { get; private set; }

    public Transaction(TransactionType type, decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Transaction amount must be greater than zero.");
        }

        Id = Guid.NewGuid();
        Type = type;
        Timestamp = DateTime.Now;
        Amount = amount;
    }
}
