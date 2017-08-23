using Microsoft.Extensions.Configuration;
using NHapi.Base.Parser;
using System;

namespace NHapi.TestHarness.Core
{
   class Program
   {
	  static void Main(string[] args)
	  {
		 var config = new ConfigurationBuilder().AddUserSecrets()
		 var parser = new PipeParser();
		 var temp = parser.Parse("");
		 Console.ReadLine();
	  }
   }
}
