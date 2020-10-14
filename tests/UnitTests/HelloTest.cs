using System.Collections.Generic;
using System.IO;
using FilPasRouge;
using Xunit;
using Moq;

namespace UnitTests
{    
	public class HelloTest
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
		public void MustShowHelloWorld()
		{
            Init();
			// arrange			
            string expected = "Hello World !";

			IAction action = new Hello(Writer);
			
			string[] args = new string[]{
                "Hello"
            };

            // act
            action.Action(args);

            //assert
            Assert.Equal(expected, Lines[0]);
		}

		[Fact]
		public void MustShowHello()
		{
            Init();
			// arrange			
            string expected = "Hello";

			IAction action = new Hello(Writer);

            // act
            string nom = action.Name;

            //assert
            Assert.Equal(expected, nom);
		}

		[Fact]
		public void MustShowHelloCommandeDeSalutation()
		{
            Init();
			// arrange			
            string expected = "Hello - Commande de salutation.";

			IAction action = new Hello(Writer);

            // act
            string desc = action.Description;

            //assert
            Assert.Equal(expected, desc);
		}
	}

}