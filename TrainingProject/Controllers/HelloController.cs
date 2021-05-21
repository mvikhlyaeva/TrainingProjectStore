using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingProject.Controllers
{
    [Route("api/Hello")]
    [ApiController]
    public class HelloController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Hello";
        }

        [HttpGet("sqr")]
        public int Sqr (int x)
        {
            return x*x;
        }

    }
}
