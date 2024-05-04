using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using Functional;
using SeanBeanBot.Extensions;
using SeanBeanBot.Contracts;
using SeanBeanBot.Domain.Services;

namespace SeanBeanBot
{
    public class SeanBeanFunction
    {
        private IDiscordMappingService _discordService {get; init;}
        public SeanBeanFunction(IDiscordMappingService discordService)
        {
            _discordService = discordService;
        }

        [FunctionName("SeanBeanBot")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return await req.ToCivPayload()
                .Select(payload => payload.ToModel())
                .BindAsync(model => _discordService.SendToDiscord(model))
                .Match(_ => new OkResult(),
                     failure => new OkResult());
                

            var civTurn = new CivPayload("", "", 0);
            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
