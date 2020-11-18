using System;
using System.Net.Mail;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp2
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            var emailAddress = myQueueItem;
            string fromEmail = "ekn.user.dp@gmail.com";
            string toEmail = myQueueItem;



            int smtpPort = 587;
            bool smtpEnableSsl = true;
            string smtpHost = "smtp.gmail.com";

            string smtpUser = "ekn.user.dp@gmail.com";

            string smtpPass = "xvzlwmjmphfikwmx";

            string subject = "Your ticket is confirmed.";

            string message = "Hello, you are recieving message from BMS.Your ticket has been confirmed. Thanks";

            MailMessage mail = new MailMessage();

            SmtpClient client = new SmtpClient();
            client.Port = smtpPort;

            client.EnableSsl = smtpEnableSsl;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.UseDefaultCredentials = false;

            client.Host = smtpHost;

            client.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);

            mail.Subject = subject;
            mail.From = new MailAddress(fromEmail);

            mail.Body = message;

            mail.To.Add(new MailAddress(toEmail));

            try
            {

                client.Send(mail);

                log.LogInformation("Email sent");

            }

            catch (Exception ex)
            {

                log.LogInformation(ex.ToString());
            }
            }
    }
}
