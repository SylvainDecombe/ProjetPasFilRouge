using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FilPasRouge {
	class Program {
		static void Main (string[] args) {

			Type actionType = typeof(IAction);

			IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies ()
				.SelectMany (s => s.GetTypes ())
				.Where (p => actionType.IsAssignableFrom (p));

			IAction[] availableActions = types
				.Where(t => !t.IsInterface)
				.Select (type => (IAction) Activator
				.CreateInstance (type))
				.ToArray ();
			
			if (args.Length < 1) {
				Console.Write ("Liste des commandes disponnibles : \n\n");
				foreach (var item in availableActions) {
					Console.Write (" ► " + item.Description + "\n");
				}
			} 
			else {
				if (!availableActions.Any (x => x.Name == args[0])) {
					Console.Write ("Commande inconnue.");
				} else {
					availableActions.Where(x => x.Name == args[0]).FirstOrDefault().Action(args);
				}
			}
		}
	}
}