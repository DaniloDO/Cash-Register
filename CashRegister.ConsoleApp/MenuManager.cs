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
