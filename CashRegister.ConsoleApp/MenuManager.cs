/*
 The MenuManager is responsible for handling the user interface loop of the 
 console application. It acts as the controller for all available menu actions, 
 displaying options, capturing user input, and executing the corresponding 
 action. 

 Key responsibilities include:
 - Rendering a menu based on the list of IMenuAction implementations.
 - Parsing and validating user input for menu navigation.
 - Coordinating the execution of actions, including special handling for 
   ExitAction to terminate the application.
*/

using System;
using CashRegister.Application.Interfaces; 
using CashRegister.Application.Actions; 

namespace CashRegister.ConsoleApp;

public class MenuManager
{
    private readonly List<IMenuAction> _actions;

    public MenuManager(List<IMenuAction> actions)
    {
        _actions = actions;
    }

    public void Run()
    {
        bool exitRequested = false;
        while (!exitRequested)
        {
            Console.Clear();
            Console.WriteLine("=== Cash Register Menu ===");

            for (int i = 0; i < _actions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_actions[i].Name}");
            }

            Console.WriteLine("Select an option");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value > 0 && value <= _actions.Count)
            {
                var action = _actions[value - 1];
                if (action is ExitAction)
                    exitRequested = true;

                action.Execute();
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to try again.");
                Console.ReadLine(); 
            }
        }
    }

}
