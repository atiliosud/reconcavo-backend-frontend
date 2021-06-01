using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;
using WpfApi.Models;
using WpfApi.Repository.Interfaces;

namespace WpfApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrugStoreController : ControllerBase

    {
        private readonly ILogger<DrugStoreController> _logger;        
        private readonly IDrugStoreRepository drugStoreRepository;

        public DrugStoreController(ILogger<DrugStoreController> logger, IDrugStoreRepository drugStoreRepository)
        {
            _logger = logger;
            this.drugStoreRepository = drugStoreRepository;            
        }

        [HttpGet]
        public ActionResult<List<DrugStore>> Get(int size, string drugStoreName)
        {
            var result = drugStoreRepository.Get(size, drugStoreName);  
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<DrugStore> GetById(int id)
        {
            var result = drugStoreRepository.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByNeighborhood")]
        public ActionResult<List<DrugStore>> GetByNeighborhood(int idNeighborhood, bool flg_round_the_clock)
        {
            var result = drugStoreRepository.GetByNeightborhood(idNeighborhood, flg_round_the_clock);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<bool> Post(DrugStore drugStore)
        {
            var result = drugStoreRepository.Add(drugStore);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<int> Put(DrugStore drugStore)
        {
            var result = drugStoreRepository.Update(drugStore);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult<bool> Delete(int id)
        {
            var result = drugStoreRepository.Delete(id);
            return Ok(result);
        }
    }
}
