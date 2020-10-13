using System;
namespace FilPasRouge
{
    public class Hello : IAction
    {
        public string Name => "Hello";

        public string Description => "Hello - Commande de salutation.";

        public void Action(string[] parameters)
        {
            Console.Write("Hello World !");
        }
    }
}