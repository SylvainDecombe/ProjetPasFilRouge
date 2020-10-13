using System;
using System.Globalization;

namespace FilPasRouge
{
    public class Sub : IAction
    {
        public string Name => "Sub";

        public string Description => "Sub(float,float) - Commande pour soustraire deux nombres.";

        public void Action (string[] parameters) {
            float nombreA = float.Parse (parameters[1], CultureInfo.InvariantCulture);
            float nombreB = float.Parse (parameters[2], CultureInfo.InvariantCulture);

            if (parameters.Length < 3 || parameters.Length > 3) {
                Console.Write ("Veuillez vérifier la validité des paramètres passés.");
            }
            else
            {
                float result = nombreA - nombreB;
                Console.Write ("Le résultat est : " + result);
            }
        }
    }
}