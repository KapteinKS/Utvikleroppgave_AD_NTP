using Microsoft.AspNetCore.Mvc;
using Utvikleroppgave_AD_NTP.DAL;

namespace Utvikleroppgave_AD_NTP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _db;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductRepository repository, ILogger<ProductController> logger)
        {
            this.logger = logger;
            _db = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            Console.WriteLine("####################    Product get call    ######################");
            try
            {
                List<Model.Product> products = await _db.GetProducts();
                
                return Ok(products);
            } catch
            {
                return BadRequest("Could not fetch products from server");
            }
        }
    }
}