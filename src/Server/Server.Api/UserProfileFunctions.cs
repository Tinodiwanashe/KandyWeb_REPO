using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using KandyWeb.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Server.Api.Models;

namespace Server.Api
{
    public static class Function
    {
        [Function("AddUserProfile")]
        public static async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "userProfile")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("AddUserProfile");
            logger.LogInformation("Called AddUserProfile with HTTP POST request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var document = JsonConvert.DeserializeObject<UserProfile>(requestBody);
            if (document == null)
            {
                logger.LogError("UserProfile object sent from client is null");
                //return BadRequest("UserProfile object is null");
            }
            document.Id = Guid.NewGuid().ToString();

            //FoodItemStore.fooditems.Add(fooditem);
             return new OkObjectResult(document);
            // Return a response to both HTTP trigger and Azure Cosmos DB output binding.
            //return new UserProfileResponse()
            //{
            //Document = document,
            //HttpResponse = response
            //};
        }
    }
}
