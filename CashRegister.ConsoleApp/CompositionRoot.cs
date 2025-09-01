using System;
using CashRegister.Application.Actions;
using CashRegister.Application.Interfaces;
using CashRegister.Domain.Models;
using CashRegister.Infrastructure;

namespace CashRegister.ConsoleApp;

public static class CompositionRoot
{
    public static MenuManager BuildApplication()
    {
        var till = new Till();
        ITillRepository repository = new JsonTillRepository();

        var actions = new List<IMenuAction>
        {
            new StartTransactionAction(till), 
            new ViewTillStatusAction(till),
            new VoidTransactionAction(till),
            new ExportTillToJsonAction(till, repository), 
            new ExitAction()
        }; 

        return new MenuManager(actions); 
    }
}
