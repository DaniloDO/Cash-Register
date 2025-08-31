// See https://aka.ms/new-console-template for more information

namespace CashRegister.ConsoleApp;

class Program
{
    public static void Main(string[] args)
    {
        var menuManager = CompositionRoot.BuildApplication(); 
        menuManager.Run(); 

    }
}
