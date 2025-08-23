// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using CashRegister.ConsoleApp.Menu;
using CashRegister.ConsoleApp.Menu.Actions;


namespace CashRegister.ConsoleApp;

class Program
{
    public static void Main(string[] args)
    {
        var actions = new List<IMenuAction>
        {
            new StartTransactionAction(),
            new ViewTillStatusAction(),
            new ExitAction() 
        };

        var menuManager = new MenuManager(actions); 
        menuManager.Run(); 

    }
}
