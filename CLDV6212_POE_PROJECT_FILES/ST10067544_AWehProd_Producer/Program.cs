using Azure.Messaging;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System.Text;

//Got this code from a video by the lecturer with a template on how to use storage queues and send messages.
//Source: https://myvc.iielearn.ac.za/webapps/blackboard/execute/content/file?cmd=view&content_id=_19831294_1&course_id=_195503_1&framesetWrapped=true
//Author: Isaac Leshaba

//Get the connection string
string connectionString = "DefaultEndpointsProtocol=https;AccountName=sathato;AccountKey=8PPOU83l/YDZG4/Bbl+clN/MxoE7Vcxt4tTz9X9QLMq2icRiPLq8tGMD/3ZXpGfKTUDDgOF8RPgI+AStuZS+GA==;EndpointSuffix=core.windows.net";

//Create the queue
string queueName = "awehprod-queue";
QueueClient queueClient = new QueueClient(connectionString, queueName);

Console.WriteLine($"Generating queue {queueName}");
await queueClient.CreateIfNotExistsAsync();

//Converted the message to Base64 due to it giving error when processing the messages that the message was not in Base64 due to the "##" of the Vaccination Serial Number.
//https://code-maze.com/base64-encode-decode-csharp/#:~:text=Implement%20the%20Base64%20Encoding%20in,a%20varying%20number%20of%20parameters.
//Author: Code Maze

//Insert messages into the queue using the format: (Id : VaccinationCenter : VaccinationDate : VaccineSerialNumber)
Console.WriteLine("\n Adding messages to the queue");
await queueClient.SendMessageAsync (Convert.ToBase64String(Encoding.UTF8.GetBytes(("0307195781280:Centurion:2020-07-19:##BF0319"))));
await queueClient.SendMessageAsync (Convert.ToBase64String(Encoding.UTF8.GetBytes(("9071205879823:Centurion:2020-08-01:##BF9012"))));
await queueClient.SendMessageAsync (Convert.ToBase64String(Encoding.UTF8.GetBytes(("0307095701080:WaterFall:2022-01-03:##MD5780"))));
await queueClient.SendMessageAsync (Convert.ToBase64String(Encoding.UTF8.GetBytes(("9905078958665:Mondeor:2021-11-20:##JZ5099"))));
await queueClient.SendMessageAsync (Convert.ToBase64String(Encoding.UTF8.GetBytes(("8612015552356:Alexandra:2021-03-19:##JZ8620"))));

Console.WriteLine("\nMessages have been successfully sent to the queue!");
