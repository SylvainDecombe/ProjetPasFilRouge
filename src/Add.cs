using System.IO;

namespace FilPasRouge
{
    public class Add : IAction {

        private readonly TextWriter _writer;

        public Add(TextWriter writer){
            _writer = writer;
        }
        
        public string Name => "Add";

        public string Description => "Add(float,float) - Commande pour aditionner deux nombres.";

        public void Action (string[] parameters) {

            if (parameters.Length < 3 || parameters.Length > 3) {
                _writer.WriteLine ("Veuillez vérifier la validité des paramètres passés.");
            }
            else
            {
                float nombreA = float.Parse (parameters[1]);
                float nombreB = float.Parse (parameters[2]);
                float result = nombreA + nombreB;
                _writer.WriteLine ("Le résultat est : " + result);
            }
        }
    }
}