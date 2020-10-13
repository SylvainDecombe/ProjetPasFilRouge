using System;
using System.Globalization;

namespace FilPasRouge
{
    public class Mul : IAction
    {
        public string Name => "Mul";

        public string Description => "Mul(float,float) - Commande pour multiplier deux nombres.";

        public void Action (string[] parameters) {
            float nombreA = float.Parse (parameters[1], CultureInfo.InvariantCulture);
            float nombreB = float.Parse (parameters[2], CultureInfo.InvariantCulture);

            if (parameters.Length < 3 || parameters.Length > 3) {
                Console.Write ("Veuillez vérifier la validité des paramètres passés.");
            }
            else
            {
                float result = nombreA * nombreB;
                Console.Write ("Le résultat est : " + result);
            }
        }
    }
}