using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Net;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;

namespace MailFunctionApp
{
    public static class Function1
    {
        const string StorageAccountNAme = "emailqueue";
        const string StorageAccountKey = "kcYN+08WSJrqcgEnhOgjWtz6ARJEs+KKmMA+Qxy0qXcIDjygx0JJhOuzQxOa84FziKw84Nx+jwP+VdF7cFSulg==";

        [FunctionName("Function1")]
        public async static void Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            //var storageAccount = new CloudStorageAccount(
            //new StorageCredentials(StorageAccountNAme, StorageAccountKey), true);

            //var client = storageAccount.CreateCloudQueueClient();
            //var queue = client.GetQueueReference("my-queue");
            //queue.CreateIfNotExistsAsync();

            //Console.WriteLine("waiting for response");

            //var emailAddress = myQueueItem;
            //var senderEmail = "ekn.user.dp@gmail.com";
            //var password = "User@123";
            //string recemail = "bhushan.jain@diaspark.com";
            //string fromEmail = ConfigurationManager.AppSettings[senderEmail];
            //string toEmail = myQueueItem;


            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //   // Credentials = new NetworkCredential(senderEmail.Address, password)
            //};

            //int smtpPort = Int32.Parse(ConfigurationManager.AppSettings[smtp.Port]);
            //bool smtpEnableSsl = true;

            //string smtpHost = ConfigurationManager.AppSettings[smtp.Host]; // your smtp host 
            //string smtpUser = ConfigurationManager.AppSettings[senderEmail]; // your smtp user
            //string smtpPass = ConfigurationManager.AppSettings[password]; // your smtp password
            //string subject = ConfigurationManager.AppSettings["Hello from visual studio"];
            //string message = "Hello, you are recieving message from Azure Function /n Thanks, /n bhushan";

            //MailMessage mail = new MailMessage();
            //SmtpClient client = new SmtpClient();
            //client.Port = smtpPort;
            //client.EnableSsl = smtpEnableSsl;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Host = smtpHost;
            //client.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);
            //mail.Subject = subject;
            //mail.From = new MailAddress(fromEmail);
            //mail.Body = message;
            //mail.To.Add(new MailAddress(toEmail));

            //try
            //{
            //    client.Send(mail);
            //    //  log.Verbose("Email sent");
            //    log.LogTrace("mail sent");
            //    System.Diagnostics.Debug.WriteLine("You click me Email sent");
            //    log.LogTrace("mail sent");
            //}

            //catch (Exception ex)
            //{
            //    // log.Verbose();
            //    log.LogTrace(ex.ToString());
            //    System.Diagnostics.Debug.WriteLine(ex.ToString());
            //}




            var client = new SendGridClient("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");
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("bhushan.jain@diaspark.com", "Azure Tips and Tricks"));

            var recipients = new List<EmailAddress>
                {
                    new EmailAddress("bhushanjainabc@gmail.com"),
                    new EmailAddress("bhushanjain81097@gmail.com"),
                    new EmailAddress("bhushan.jain@diaspark.com")
                };
            msg.AddTos(recipients);

            msg.SetSubject("Mail from Azure and SendGrid");

            msg.AddContent(MimeType.Text, "This is just a simple test message!");
            msg.AddContent(MimeType.Html, "<p>This is just a simple test message!</p>");
            var response =await client.SendEmailAsync(msg);



        }
    }
}
