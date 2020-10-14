using System.IO;

namespace FilPasRouge
{
    public class Mul : IAction
    {
        private readonly TextWriter _writer;

        public Mul(TextWriter writer){
            _writer = writer;
        }

        public string Name => "Mul";

        public string Description => "Mul(float,float) - Commande pour multiplier deux nombres.";

        public void Action (string[] parameters) {

            if (parameters.Length < 3 || parameters.Length > 3) {
                _writer.WriteLine ("Veuillez vérifier la validité des paramètres passés.");
            }
            else
            {
                float nombreA = float.Parse (parameters[1]);
                float nombreB = float.Parse (parameters[2]);
                float result = nombreA * nombreB;
                _writer.WriteLine ("Le résultat est : " + result);
            }
        }
    }
}