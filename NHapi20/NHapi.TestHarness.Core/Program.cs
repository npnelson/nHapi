using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using NHapi.Base.Parser;
using System;
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
		 var blob = container.GetBlockBlobReference("004c789c-b152-47d6-8e99-0f816c0619a9");
		 var msgString = await blob.DownloadTextAsync();
		 var parser = new PipeParser();
		 var temp = parser.Parse(msgString);
			
		 Console.ReadLine();
	  }
   }
}
