using System;
using CashRegister.Domain.Models;

namespace CashRegister.Application.Interfaces;

public interface ITillRepository
{
    public Task Save(Till till); 
    public Till Load(); 
}
