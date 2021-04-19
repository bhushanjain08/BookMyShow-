# BookMyShow-
Miniature of BMS c# and Azure

I would like to inform you that that I have completed the training on Azure Essentials, With the help of CLAD (Diaspark Technologies) team I learned multiple types of Azure Services and how to use it.  I have developed a miniature version of book my show(BMS) using c# .net and Azure services. With the help of BMS we can book a movie ticket or seat for a particular theatre. I have used azure services to achieve different functionalities.
Created a miniature of Book my show in C# usind Azure Services mentioned below.

List of services used for various implementations:

1. GoogleAPI/Azure Active Directory - For user login
2. API Apps - For dispalying information about theatres.
3. Azure Sql server - For storing theatre information in db.
4. Azure Storage blobs - For displaying movie posters.
5. Azure Redis Cache - Movie description, actors, length, genre.
6. Function app - For taking message(email id) from queue and automatically triggering email.
7. Microservices 8. SMTP Server/Send grid -Sending confirmation email.
9. Azure WebApps : For publishing the app.
10. Virtual Machine.
11. Azure queue - storing user email id and learned many more services. 



Requirement : 
 Create a miniature version of Book My Show application, so with the help of BMS we can book a movie ticket or seat for a particular theatre. Multiple theatres are available for multiple movies. Tickets should be approved by theatres. With the help of Microsoft learn we can access the azure services for a limited period by using sandboxes. With the help of one sandbox, we can create multiple services on azure according to their compatibility. Members can create multiple users to activate multiple subscriptions at the same time, services deployed in one subscription should easily be able to use other services in other subscription and from localhost as well. The details of the application are listed below:
 
1)	The admin page of BMS DB & services includes CRUD operations of movies. 
2)	Theatre DB and services are responsible for booking tickets. BMS backend needs to call theatre’s api for booking a ticket and getting latest seat availability.
3)	Use caching to keep movie info like actors, genre, length, image urls, movie long and short description etc 
4)	For BMS: 
a.	Frontend should be on Angular or any other language as per your comfortability.
b.	For backend, we can use c#, WebApps, VM based deployment.
5)	For Theatre:
a.	We can use API apps for backend.
b.	No frontend needed here.
6)	Once ticket is issued, its information needs to be sent to a queue from where a third service should pick it up and send mail to user.

Here is the list of services that need to be used for this implementation:

1)	Azure SQL Server DB / Cosmos DB
2)	Azure WebApps
3)	Azure VMs
4)	Azure Redis Cache
5)	Azure API apps
6)	Azure Blob storage

Thanks & Regards,
Bhushan Jain
 
