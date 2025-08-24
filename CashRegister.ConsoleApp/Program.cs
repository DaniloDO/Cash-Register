// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using CashRegister.ConsoleApp.Menu;
using CashRegister.ConsoleApp.Menu.Actions;
using CashRegister.ConsoleApp.Models;


namespace CashRegister.ConsoleApp;

class Program
{
    public static void Main(string[] args)
    {
        var till = new Till();

        var actions = new List<IMenuAction>
        {
            new StartTransactionAction(till),
            new ViewTillStatusAction(till),
            new VoidTransactionAction(till), 
            new ExitAction() 
        };

        var menuManager = new MenuManager(actions); 
        menuManager.Run(); 

    }
}
