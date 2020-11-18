using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace queue.Controllers
{
    public class queueController : ApiController
    {
        const string StorageAccountNAme = "emailqueue";
        const string StorageAccountKey = "kcYN+08WSJrqcgEnhOgjWtz6ARJEs+KKmMA+Qxy0qXcIDjygx0JJhOuzQxOa84FziKw84Nx+jwP+VdF7cFSulg==";

        static void Main()
        {
            var storageAccount = new CloudStorageAccount(
                new StorageCredentials(StorageAccountNAme, StorageAccountKey), true);

            var client = storageAccount.CreateCloudQueueClient();
            var queue = client.GetQueueReference("my-queue");
            queue.CreateIfNotExists();

            for(int number =0; number < 5; number++)
            {
                queue.AddMessage(new CloudQueueMessage(number.ToString()));
            }
        }
         
    }
}
