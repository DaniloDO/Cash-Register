/*
 The Till class represents the core domain model of the cash register. 
 It is responsible for tracking the current balance and managing the 
 collection of transactions that have been applied. 

 Key responsibilities include:
 - Supporting the register of operations through applying transactions and
   calculating the current state of the balance. 
 - Maintaining a read-only transaction history to ensure encapsulation and 
   prevent external modification. 
 - Supporting the reversal of operations through the voiding of transactions, 
   adjusting the balance accordingly. 
*/

using System;

namespace CashRegister.Domain.Models;

public class Till
{
    private readonly List<Transaction> _transactions = new(); 
    public IReadOnlyList<Transaction> Transactions { get => _transactions.AsReadOnly(); }
    public decimal Balance { get; private set; }

    public void ApplyTransaction(Transaction transaction)
    {
        switch (transaction.Type)
        {
            case TransactionType.Deposit:
                Balance += transaction.Amount;
                break; 
            case TransactionType.Withdrawal:
                if (transaction.Amount > Balance)
                {
                    throw new InvalidOperationException("Insufficient funds in till for withdrawal"); 
                }

                Balance -= transaction.Amount; 
                break;
            default:
                throw new InvalidOperationException("Unsupported transaction type");
        }

        _transactions.Add(transaction); 
    }

    public void VoidTransactionAction(Transaction transaction)
    {
        if (transaction.Type == TransactionType.Deposit)
        {
            Balance -= transaction.Amount; 
        }
        else if(transaction.Type == TransactionType.Withdrawal)
        {
            Balance += transaction.Amount; 
        }

        _transactions.Remove(transaction); 

    }
}
