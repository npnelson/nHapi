using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NHapi.TestHarness.Core
{
   public sealed class AzureStorageSettings
   {
	  public string ConnectionString { get; set; }
	  public string StorageContainerName { get; set; }
   }

   public sealed class AzureStorage
   {
	  CloudBlobContainer _container;
	  public AzureStorage(AzureStorageSettings settings)
	  {
		 var account = CloudStorageAccount.Parse(settings.ConnectionString);
		 var client = account.CreateCloudBlobClient();
		 _container = client.GetContainerReference(settings.StorageContainerName);
	  }

	  public async Task<string> DownloadToStringAsync(string path)
	  {
		 var ms = new MemoryStream();
		 var blobReference = _container.GetBlockBlobReference(path);
		 var retval = await blobReference.DownloadTextAsync();
		 return retval;
	  }
   }
}
