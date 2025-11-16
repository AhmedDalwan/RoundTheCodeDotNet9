using Microsoft.AspNetCore.Mvc;
using RoundTheCodeDotNet9.LinqMethods;

namespace RoundTheCodeDotNet9.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinqController : ControllerBase
    {
        [HttpGet("count-by")]
        public Dictionary<string, int> CountBy()
        {
            return new LinqCountBy().GetCountForEachSurname();
        }

        [HttpGet("aggregate-by")]
        public Dictionary<string, int> AggregateBy()
        {
            return new LinqAggregateBy().GetPoints();
        }

        [HttpGet("index")]
        public Dictionary<string, int> Index()
        {
            return new LinqIndex().GetIndexForEachProduct();
        }
    }
}