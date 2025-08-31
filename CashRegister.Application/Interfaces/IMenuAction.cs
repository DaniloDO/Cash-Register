using System;

namespace CashRegister.Application.Interfaces;

public interface IMenuAction
{
    public string Name { get; }

    public void Execute(); 
}
