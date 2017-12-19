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
		 var msgToAdd = "MSH|^~\\&|NovRad|MAN|SOARC|MH|201712121407||ORM^O01^ORM_O01|RMS|P|2.4\rZBX|1|CE|CTM724384^CT CHEST,ABDO,PELV W/ IV \\T\\ ORAL||H^Malignant neoplasm of colon, no new concerns per patient Isovue 370 100ml Lot 7F70561 Exp 5/20\rPID||MAN524557|MAN524557|524557|ERWIN^ROGER^A||194008130000|M||||||||||3103370506\rPV1||O|^^^MANSFIELD GENERAL HOSPITAL||||MAN000987^VISWANATHAN^SRIVIDYA||||||||||MAN000987^VISWANATHAN^SRIVIDYA||MANV5105075645ORC|SC|MAN3304310|||CM|||||||||||Malignant Neoplasm of colon\rOBR||MAN3304310|MAN114511568|MAN.CTM0135^CT CHEST,ABDO,PELV W/ IV \\T\\ ORAL^SIEMENS_RIS|||201712121407|||||||||MAN000987^VISWANATHAN^SRIVIDYA||||||||CT|||^^^201712121200^^R||||^Malignant Neoplasm of colon";
		 var temp = parser.Parse(msgToAdd);

		var seg= temp.GetRawSegmentString("ZBX");

		 Console.ReadLine();
	  }
   }
}
