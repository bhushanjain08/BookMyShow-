using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace queue.Controllers
{
    public class HomeController : Controller
    {


        const string StorageAccountNAme = "emailqueue";
        const string StorageAccountKey = "kcYN+08WSJrqcgEnhOgjWtz6ARJEs+KKmMA+Qxy0qXcIDjygx0JJhOuzQxOa84FziKw84Nx+jwP+VdF7cFSulg==";

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //// Get azure table storage connection string.  
            //string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=azqueuestorageaccount;AccountKey=kcYN+08WSJrqcgEnhOgjWtz6ARJEs+KKmMA+Qxy0qXcIDjygx0JJhOuzQxOa84FziKw84Nx+jwP+VdF7cFSulg==;EndpointSuffix=core.windows.net";
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);


             var storageAccount = new CloudStorageAccount(
               new StorageCredentials(StorageAccountNAme, StorageAccountKey), true);

            var client = storageAccount.CreateCloudQueueClient();
            var queue = client.GetQueueReference("my-queue");
            queue.CreateIfNotExists();
            for (int number = 0; number < 5; number++)
            {
                queue.AddMessage(new CloudQueueMessage(number.ToString()));
            }

            return View();
        }
    }
}
