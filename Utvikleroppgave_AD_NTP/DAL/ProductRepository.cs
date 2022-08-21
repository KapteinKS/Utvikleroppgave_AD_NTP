using Utvikleroppgave_AD_NTP.Model;
using Microsoft.EntityFrameworkCore;

namespace Utvikleroppgave_AD_NTP.DAL
{
    public class ProductRepository : IProductRepository
    {
 
        private readonly ProductContext _db;

        public ProductRepository(ProductContext db)
        {
            _db = db;
        }

        public async Task<List<Product>> GetProducts()
        {
            try
            {
                /*List<Product> products = await _db.Products.Select(p => new Product
                {
                    Name = p.Name,
                    Unit = p.Unit,
                    Amount = p.Amount,
                    Priority = p.Priority,
                }).ToListAsync(); */
                List<Product> products = new()
                {
                    new Product("Adhesive", "Kg", 0, false),
                    new Product("Ink", "Liter", 0, false)
                };

                return products;

            } catch
            {
                return null;
            }
        }

        public async Task OrderProduct(Product product)
        {
            // This method included for illustrative purposes only
        }
    }
}
