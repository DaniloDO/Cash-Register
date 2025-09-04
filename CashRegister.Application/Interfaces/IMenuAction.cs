/*
 The IMenuAction interface defines the contract for all user-selectable actions 
within the application's menu system.  

 Key aspects:
 - Ensures each action has a descriptive Name property to be displayed in the menu.  
 - Enforces the implementation of the Execute method, which performs the action's logic.  
*/

using System;

namespace CashRegister.Application.Interfaces;

public interface IMenuAction
{
    public string Name { get; }

    public void Execute(); 
}
