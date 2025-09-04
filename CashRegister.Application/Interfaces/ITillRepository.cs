/*
 The ITillRepository interface defines the contract for persistence operations 
on the Till aggregate in the application.  

 Key aspects:
 - Save(Till till): Persists the current state of the till asynchronously.  
 - Load(): Retrieves a till instance from the chosen storage source.  
*/

using System;
using CashRegister.Domain.Models;

namespace CashRegister.Application.Interfaces;

public interface ITillRepository
{
    public Task Save(Till till); 
    public Till Load(); 
}
