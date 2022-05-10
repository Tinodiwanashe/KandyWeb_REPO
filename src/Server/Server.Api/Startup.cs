using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Server.Api;
using Server.Api.Extensions;

[assembly: WebJobsStartup(typeof(Startup))]
namespace Server.Api
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddDBContext();
        }
    }
}
