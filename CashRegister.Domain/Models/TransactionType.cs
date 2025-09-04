/*
 The TransactionType enum defines the supported types of financial operations 
 in the cash register. 

 - Deposit: Adds funds to the till.  
 - Withdrawal: Removes funds from the till.  
*/

namespace CashRegister.Domain.Models;

public enum TransactionType
{
    Deposit = 1,
    Withdrawal = 2
}
