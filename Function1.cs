using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp34
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "{Name}")] HttpRequest req, string Name)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<User>(requestBody);
            if(data is null)
            {

            return new OkObjectResult("Please add valid user"); 
            }
            UserContext userContext = new UserContext();
            User user = new User();
            user.UserName = data.UserName;
            userContext.Users.Add(user);
            userContext.SaveChanges();

            

           
        

            return new OkObjectResult("");
        }
    }
}
