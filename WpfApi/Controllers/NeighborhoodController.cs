using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WpfApi.Models;
using WpfApi.Repository.Interfaces;

namespace WpfApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NeighborhoodController : ControllerBase
    {
        private readonly ILogger<NeighborhoodController> _logger;
        private readonly INeightborhoodRepository neightborhoodRepository;

        public NeighborhoodController(ILogger<NeighborhoodController> logger,
            INeightborhoodRepository neightborhoodRepository)
        {
            this.neightborhoodRepository = neightborhoodRepository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Neighborhood>> Get(string neighborhoodSearch, int size)
        {
            var result =  neightborhoodRepository.Get(neighborhoodSearch, size);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<bool> Post(Neighborhood item)
        {
            return Ok(neightborhoodRepository.Add(item));
        }
    }
}
