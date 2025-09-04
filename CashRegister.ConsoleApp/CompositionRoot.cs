/*
 The CompositionRoot class acts as the central place where the application’s 
 dependencies are created and wired together. 

 Its primary role is to construct the core objects, bind them to their 
 interfaces, and pass them into higher-level services such as menu actions. 

 In this project, the CompositionRoot:
 - Instantiates the Till (domain model) that represents the cash register state.
 - Creates concrete repository implementations (JSON and CSV) for persistence.
 - Builds a list of available menu actions, wiring them with their required 
   dependencies.
 - Returns a fully configured MenuManager that orchestrates user interaction.
*/

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
        ITillRepository JsonRepository = new JsonTillRepository();
        ITillRepository CsvRepository = new CsvTillRepository(); 

        var actions = new List<IMenuAction>
        {
            new StartTransactionAction(till), 
            new ViewTillStatusAction(till),
            new VoidTransactionAction(till),
            new ExportTillToJsonAction(till, JsonRepository), 
            new ExportTillToCsvAction(till, CsvRepository),
            new ExitAction()
        }; 

        return new MenuManager(actions); 
    }
}
