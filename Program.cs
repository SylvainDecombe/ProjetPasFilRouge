using System;
using System.Globalization;

namespace FilPasRouge
{
	class Program
	{
		static void Main(string[] args)
		{

			string[] tabCommandes = {"Hello", "Add", "Sub", "Mul", "Div"};

			if (args.Length < 1){
				Console.Write("Liste des commandes disponnibles : \n\n");
				for (int i = 0; i < tabCommandes.Length; i++)
				{
					Console.Write(tabCommandes[i] + "\n");
				}				
			}
			else
			{
				switch (args[0])
				{
					case "Hello" : 
						Console.Write("Hello World !");
						break;
					case "Add" : 
					case "Sub" :
					case "Mul" :
					case "Div" :
						Calcul(args[0], float.Parse(args[1], CultureInfo.InvariantCulture), float.Parse(args[2], CultureInfo.InvariantCulture));
						break;
					default: 
						Console.Write("Commande inconnue");
						break;
				}
			}
		}

		public static void Calcul(string val, float nombre1, float nombre2){

			float result = 0;
			switch (val)
			{
				case "Add" : 
					result = nombre1 + nombre2;
					Console.Write("Resultat = " + result);
					break;
				case "Sub" : 
					result = nombre1 - nombre2;
					Console.Write("Resultat = " + result);
					break;
				case "Mul" : 
					result = nombre1 * nombre2;
					Console.Write("Resultat = " + result);
					break;
				case "Div" : 
					result = nombre1 / nombre2;
					Console.Write("Resultat = " + result);
					break;				
				default: 
					Console.Write("Commande inconnue");
					break;
			}
		}
	}
}
