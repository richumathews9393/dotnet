using CustomWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidController : ControllerBase
    {
        private readonly ISingletonService _singletonService;
        private readonly IScopedService _scopedService;
        private readonly ITransientService _transientService;

        private readonly ISingletonService _singletonService1;
        private readonly IScopedService _scopedService1;
        private readonly ITransientService _transientService1;
        public GuidController(ISingletonService singletonService, IScopedService scopedService, ITransientService transientService, ISingletonService singletonService1, IScopedService scopedService1, ITransientService transientService1)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;

            _singletonService1 = singletonService1;
            _scopedService1 = scopedService1;
            _transientService1 = transientService1;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Singleton = _singletonService.GetGuid(),
                Singleton1 = _singletonService1.GetGuid(),
                Scoped = _scopedService.GetGuid(),
                Scoped1 = _scopedService1.GetGuid(),
                Transient = _transientService.GetGuid(),
                Transient1 = _transientService1.GetGuid()
            });
        }

        [HttpPost]
        [Route("/minLoss")]
        public IActionResult minimumLoss(List<long> price)
        {
            var pricePerIndex = new List<(long Price, int Index)>();

            for (int i = 0; i < price.Count; i++)
            {
                pricePerIndex.Add((price[i], i));
                Console.WriteLine($"Price: {price[i]}, Index: {i}");

            }
            return Ok();

        }
    }
}
