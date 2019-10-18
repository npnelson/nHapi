using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using NHapi.Base.Parser;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NHapi.TestHarness.Core
{
   class Program
   {
	  static async Task Main(string[] args)
	  {
		 var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange:true).AddEnvironmentVariables().AddUserSecrets<Program>().Build();
		 var azureSettings = config.GetSection("AzureStorageSettings").Get<AzureStorageSettings>();
		 var storageAccount = CloudStorageAccount.Parse(azureSettings.ConnectionString);

		 var blobClient = storageAccount.CreateCloudBlobClient();
		 var container = blobClient.GetContainerReference(azureSettings.StorageContainerName);
		 var blob = container.GetBlockBlobReference("Test/201910/e55b99ab-8429-4c69-a726-8a03c7207505");
		 var msgString = await blob.DownloadTextAsync();
		 var parser = new PipeParser();
		 var message = parser.Parse(msgString);
		 var typedMessage = message as NHapi.Model.V23.Message.DFT_P03;
		 var financial = typedMessage.GetFINANCIAL();
		 var diag = financial.FT1.GetDiagnosisCode();

		 var pr = financial.GetFINANCIAL_PROCEDURE();
		 var pr1 = pr.PR1.ProcedureDateTime;
		 //var zpv=temp.GetRawSegmentString("ZPV").Single();
		 //var zpvFields = zpv.Split('|');
		 ////var segs=temp.Get	
		 Console.ReadLine();
	  }
   }
}
