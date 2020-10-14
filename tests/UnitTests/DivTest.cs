using System.Collections.Generic;
using System.IO;
using FilPasRouge;
using Xunit;
using Moq;

namespace UnitTests
{    
	public class DivTest
	{
		private TextWriter _writer;
		private List<string> _output;

		public void Init()
		{
			_writer = Mock.Of<TextWriter>();
			_output = new List<string>();

			Mock.Get(_writer)
				.Setup(x => x.WriteLine(It.IsAny<string>()))
				.Callback<string>(x => _output.Add(x));

			Mock.Get(_writer)
				.Setup(x => x.WriteLine(It.IsAny<float>()))
				.Callback<float>(x => _output.Add(x.ToString()));
		}

		public TextWriter Writer => _writer;

		public IReadOnlyList<string> Lines
		{
			get { return _output; }
		}		

		[Fact]
		public void MustShowDiv()
		{
            Init();
			// arrange			
            string expected = "Div";

			IAction action = new Div(Writer);

            // act
            string nom = action.Name;

            //assert
            Assert.Equal(expected, nom);
		}

		[Fact]
		public void MustShowDivFloatFloatCommandePourDiviserDeuxNombres()
		{
            Init();
			// arrange			
            string expected = "Div(float,float) - Commande pour diviser deux nombres.";

			IAction action = new Div(Writer);

            // act
            string desc = action.Description;

            //assert
            Assert.Equal(expected, desc);
		}

		[Fact]
		public void MustShowLeResultatEst8()
		{
            Init();
			// arrange			
            string expected = "Le résultat est : 8";

			IAction action = new Div(Writer);
			
			string[] args = new string[]{
                "Div",
                "80",
                "10"
            };

            // act
            action.Action(args);

            //assert
            Assert.Equal(expected, Lines[0]);
		}

		[Fact]
        public void MustShowVeuillezVerifierLaValiditeDesParametresPassesDeuxParametres()
		{
            Init();
			// arrange			
            string expected = "Veuillez vérifier la validité des paramètres passés.";

			IAction action = new Div(Writer);
			
			string[] args = new string[]{
                "Div",
                "5"
            };

            // act
            action.Action(args);

            //assert
            Assert.Equal(expected, Lines[0]);
		}

        [Fact]
        public void MustShowVeuillezVerifierLaValiditeDesParametresPassesQuatreParametres()
		{
            Init();
			// arrange			
            string expected = "Veuillez vérifier la validité des paramètres passés.";

			IAction action = new Div(Writer);
			
			string[] args = new string[]{
                "Div",
                "5",
				"2",
				"3"
            };

            // act
            action.Action(args);

            //assert
            Assert.Equal(expected, Lines[0]);
		}
	}

}