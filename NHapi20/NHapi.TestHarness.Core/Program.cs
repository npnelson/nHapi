using NHapi.Base.Parser;
using System;

namespace NHapi.TestHarness.Core
{
    class Program
    {
        static void Main(string[] args)
        {
		 var parser = new PipeParser();
		 var temp = parser.Parse("MSH|^~\\&|EPIC|RMH||RMH|20170821173353|KEG564|ADT^A08|290186945|P|2.3|||||||||||\r\n");
		 Console.ReadLine();
	  }
    }
}
