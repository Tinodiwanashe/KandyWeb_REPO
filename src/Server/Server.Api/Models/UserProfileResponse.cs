using KandyWeb.Domain.Entities;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Api.Models
{
    public class UserProfileResponse
    {
        [CosmosDBOutput("my-database", "my-container",
            ConnectionStringSetting = "CosmosDbConnectionString", CreateIfNotExists = true)]
        public UserProfile Document { get; set; }
        public HttpResponseData HttpResponse { get; set; }
    }
}
