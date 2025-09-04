/*
 The ExitAction class represents a simple menu option to terminate the application.  

 Key responsibilities include:
 - Providing a clear and user-friendly way to signal the end of the session.  
 - Displaying a closing message to confirm the exit.  
 - Integrating into the menu system through the IMenuAction interface, 
   ensuring consistency with other user actions.  
*/

using System;
using CashRegister.Application.Interfaces;

namespace CashRegister.Application.Actions;

public class ExitAction : IMenuAction
{
    public string Name { get; } = "Exit";

    public void Execute()
    {
        Console.WriteLine("Exiting application. Goodbye!");
    }
}
