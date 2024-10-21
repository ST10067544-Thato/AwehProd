using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Function1
{
    private readonly IConfiguration _configuration;
    private readonly CosmosClient _cosmosClient;
    private readonly Container _container;

    public Function1(IConfiguration configuration)
    {
        _configuration = configuration;
        string cosmosConnectionString = _configuration.GetConnectionString("CosmosDBCon");
        string cosmosDatabaseName = _configuration["CosmosDBDatabaseName"];
        string cosmosContainerName = _configuration["CosmosDBContainerName"];

        _cosmosClient = new CosmosClient(cosmosConnectionString);
        _container = _cosmosClient.GetContainer(cosmosDatabaseName, cosmosContainerName);
    }

    [FunctionName("Function1")]
    public async Task Run([QueueTrigger("awehprod-queue", Connection = "QueueCon")] string myQueueItem, ILogger log)
    {
        log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

        try
        {
            string[] attributes = myQueueItem.Split(":");

            var vaccinationData = new
            {
                id = attributes[0],
                VaccinationCenter = attributes[1],
                VaccinationDate = attributes[2],
                VaccineSerialNumber = attributes[3]
            };

        }
        catch (Exception ex)
        {
            log.LogError($"Error processing queue message: {ex.Message}");

            if (ex.InnerException != null)
            {
                log.LogError($"Inner Exception: {ex.InnerException.Message}");
            }
        }
    }


}
