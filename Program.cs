using System;

namespace FilPasRouge
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 1){
				Console.Write("Ceci est une aide");
			}else{
				PremiereCommandes(args[0]);
			}
		}

		public static void PremiereCommandes(string val){

			switch (val)
			{
				case "Hello" : 
					Console.Write("Hello World !");
					break;				
				default: 
					Console.Write("Commande inconnue");
					break;
			}
		}
	}
}
