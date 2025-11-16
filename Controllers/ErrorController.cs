using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoundTheCodeDotNet9.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        [HttpGet("error")]
        public IActionResult ThrowError()
        {
            throw new Exception("Broken");
        }
    }
}