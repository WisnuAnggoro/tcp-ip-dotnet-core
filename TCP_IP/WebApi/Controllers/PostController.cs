using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("gps_api/[controller]")]
    public class PostController : Controller
    {
        public PostController()
        {
            
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]string value)
        {
            return "success post " + value;
        }
    }
}