using System;
using System.Globalization;

namespace FilPasRouge
{
    public class Div : IAction
    {
        public string Name => "Div";

        public string Description => "Div(float,float) - Commande pour diviser deux nombres.";

        public void Action (string[] parameters) {
            float nombreA = float.Parse (parameters[1], CultureInfo.InvariantCulture);
            float nombreB = float.Parse (parameters[2], CultureInfo.InvariantCulture);

            if (parameters.Length < 3 || parameters.Length > 3) {
                Console.Write ("Veuillez vérifier la validité des paramètres passés.");
            }
            else
            {
                float result = nombreA / nombreB;
                Console.Write ("Le résultat est : " + result);
            }
        }
    }
}