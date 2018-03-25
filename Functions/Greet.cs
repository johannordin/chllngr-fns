using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.IO;

namespace chllngr.Functions
{
    public class RequestModel
    {
        public string Name { get; set; }
    }
    public class ResponseModel
    {
        public string Greeting { get; set; }
    }
    public static class Greet
    {
        [FunctionName("Greet")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            var data = JsonConvert.DeserializeObject<RequestModel>(requestBody);

            var service = new GreetingService();

            return new JsonResult(service.Greet(data.Name));
        }
    }
}
