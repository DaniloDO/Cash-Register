using System;

namespace CashRegister.ConsoleApp.Menu.Actions;

public interface IMenuAction
{
    public string Name { get; }

    public void Execute(); 
}
