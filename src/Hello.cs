using System.Security.AccessControl;
using System.IO;
using System;

namespace FilPasRouge
{
    public class Hello : IAction
    {
        private readonly TextWriter _writer;

        public Hello(TextWriter writer){
            _writer = writer;
        }

        public string Name => "Hello";

        public string Description => "Hello - Commande de salutation.";

        public void Action(string[] parameters)
        {
            //Console.Write("Hello World !");
            _writer.WriteLine("Hello World !");
        }
    }
}