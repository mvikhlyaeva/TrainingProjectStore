using Microsoft.AspNetCore.Mvc;
using TrainingProject.Core;

namespace TrainingProject.Controllers
{
    [Route("api/Hello")]
    [ApiController]
    public class HelloController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return ExceptionMessagesHelper.notFound;
        }

        [HttpGet("sqr")]
        public int Sqr(int x)
        {
            return x * x;
        }
    }
}