using Microsoft.AspNetCore.Mvc;
using ProductApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productsController : ControllerBase
    {
        private readonly IProductsRepository productsRepository;
        public productsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        // GET: api/<productsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await productsRepository.GetProductsAsync();
            if(result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<productsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<productsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<productsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<productsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
