using NHapi.Base.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHapi.TestHarness
{
   class Program
   {
	  static void Main(string[] args)
	  {
		 var parser = new PipeParser();
		 var msgToAdd = "";
		 var temp = parser.Parse(msgToAdd);

		var seg= temp.GetRawSegmentString("ZBX");

		 Console.ReadLine();
	  }
   }
}
