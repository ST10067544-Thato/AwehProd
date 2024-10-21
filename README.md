# AWehProd - Azure Queue & Cosmos DB Integration🌩️

## Overview
Welcome to the AWehProd project! 🚀 This application is a sleek, cloud-based solution that leverages the power of Azure Storage Queues and Azure Cosmos DB to handle messaging in a distributed environment.

The project consists of two key components:
- **AWehProd Producer:** A console app that pushes messages into an Azure Storage Queue.
- **AWehProd QueueTrigger:** An Azure Function that consumes messages from the queue and inserts them into Cosmos DB for further processing.

## Components 
1. **AWehProd Producer - The Messenger 🚴‍♂️**   
This is the messaging engine. Written in C#, it uses Azure's QueueClient to send Base64-encoded messages to a storage queue. Whether you're pushing new orders, logs, or notifications, this producer makes sure your messages reach their destination.

   Key Features:
   - Azure Storage Queue integration.
   - Base64 encoding for message processing.
   - Simple, scalable, and easy to configure.
  
2. **AWehProd QueueTrigger - The Guardian 🛡️**  
On the other end, we have an Azure Function waiting to pounce on every message received by the queue. Once triggered, it processes the message and stores it securely in Azure Cosmos DB. This ensures that your data is stored efficiently and remains highly available.

   Key Features:
   - Azure Function Queue Trigger.
   - Cosmos DB integration for scalable storage.
   - Resilient and asynchronous processing.
  
## How It Works ✨
1. **Step 1:** The Producer app sends messages to the Azure Storage Queue.
2. **Step 2:** The QueueTrigger wakes up whenever a new message arrives.
3. **Step 3:** Messages are processed and stored in Cosmos DB, ready for future use!

## Setup Instructions - Get Started Like a Pro 🛠️
1. **Clone the Repository:** Clone the project and navigate to the solution folder.
2. **Azure Setup:**
   - Create an Azure Storage Queue and note the connection string.
   - Set up an Azure Cosmos DB instance.
3. **Configure Environment:** Update the connection strings in the appsettings.json for the Producer and QueueTrigger projects.
4. **Run the Producer:**
   - Build and run the Producer to start sending messages to the queue.
5. **Deploy the QueueTrigger:**
   - Deploy the Azure Function to start processing the messages automatically.

## Cool Stuff 😎
- **Highly Scalable:** Both components scale independently, making this solution robust for handling large volumes of messages.
- **Cloud Native:** Take advantage of Azure's cloud infrastructure for easy deployments and management.
- **Customizable:** Easily tweak the message structure, processing logic, or storage mechanism to fit your needs.
