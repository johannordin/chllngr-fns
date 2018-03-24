
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace chllngr.functions
{
    public class RequestModel
    {
        public string Name { get; set; }
    }
    public class ResponseModel
    {
        public string Greeting { get; set; }
    }
    public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            var data = JsonConvert.DeserializeObject<RequestModel>(requestBody);
            
            return new JsonResult(new ResponseModel { Greeting = $"Hello, {data.Name}" });
        }
    }
}
