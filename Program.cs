using System;
using System.Collections.Generic;
using System.Globalization;

namespace FilPasRouge {
	class Program {
		static void Main (string[] args) {

			List<IAction> availableActions = new List<IAction> ()
			{
				new Hello (),
				new Add (),
				new Sub (),
				new Mul (),
				new Div ()
			};

			if (args.Length < 1) {
				Console.Write ("Liste des commandes disponnibles : \n\n");
				foreach (var item in availableActions)
				{
					Console.Write(" ► " + item.Description + "\n");
				}
			} 
			else {
				if (!availableActions.Exists(x => x.Name == args[0]))
				{
					Console.Write("Commande inconnue.");
				}
				else
				{
					availableActions.Find(x => x.Name == args[0]).Action(args);
				}
			}
		}		
	}
}