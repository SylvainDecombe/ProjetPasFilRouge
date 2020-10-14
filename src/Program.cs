using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace FilPasRouge
{
    class Program {
		static void Main (string[] args) {

			Type actionType = typeof (IAction);

			//WebClient client = new WebClient ();
			//Console.Write (client.DownloadString ("https://www.viedemerde.fr"));

			var html = "https://www.viedemerde.fr";
			HtmlWeb web = new HtmlWeb ();
			var htmlDoc = web.Load (html);
			HtmlNodeCollection body = htmlDoc.DocumentNode.SelectNodes ("//article[@class='article-panel']");

			foreach (HtmlNode item in body)
			{
				HtmlNode titre = htmlDoc.DocumentNode.SelectSingleNode ("//h2[@class='classic-title']");
				titre.Remove();
				Console.WriteLine(titre.InnerText);

				HtmlNode contenu = htmlDoc.DocumentNode.SelectSingleNode ("//a[@class='article-link']");
				contenu.Remove();
				Console.WriteLine(contenu.InnerText);

				HtmlNode auteur = htmlDoc.DocumentNode.SelectSingleNode("//div[@class=' article-topbar']");
				auteur.Remove();
				Console.WriteLine(auteur.InnerText.Split("Par")[1].Split(" -")[0]); 

				HtmlNode valideCount = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='vote-brick vote-count ']");
				auteur.Remove();
				Console.WriteLine(valideCount.InnerText);

				HtmlNode meriteCount = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='vote-brick vote-count']");
				auteur.Remove();
				Console.WriteLine(meriteCount.InnerText);
			}

			IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies ()
				.SelectMany (s => s.GetTypes ())
				.Where (p => actionType.IsAssignableFrom (p));

			IAction[] availableActions = types
				.Where (t => !t.IsInterface)
				.Select (type => (IAction) Activator
					.CreateInstance (type, new object[] { new StringWriter () }))
				.ToArray ();

			if (args.Length < 1) {
				Console.WriteLine ("Liste des commandes disponnibles : \n\n");
				foreach (var item in availableActions) {
					Console.WriteLine (" ► " + item.Description + "\n");
				}
			} else {
				if (!availableActions.Any (x => x.Name == args[0])) {
					Console.WriteLine ("Commande inconnue.");
				} else {
					availableActions.Where (x => x.Name == args[0]).FirstOrDefault ().Action (args);
				}
			}
		}
	}
}