// See https://aka.ms/new-console-template for more information

/*
 This is the entry point of the Cash Register application.
 It delegates application startup responsibilities to the CompositionRoot,
 ensuring the Main method remains minimal and focused only on execution flow.
 
 From here, the menu system is launched, providing user interaction
 with the cash register features.
*/

namespace CashRegister.ConsoleApp;

class Program
{
    public static void Main(string[] args)
    {
        var menuManager = CompositionRoot.BuildApplication(); 
        menuManager.Run(); 

    }
}
