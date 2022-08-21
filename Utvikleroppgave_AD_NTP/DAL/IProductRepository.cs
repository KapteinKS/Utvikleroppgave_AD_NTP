using System.Reflection;

namespace Utvikleroppgave_AD_NTP.DAL
{
    public interface IProductRepository
    {
        Task<List<Model.Product>> GetProducts();
        Task OrderProduct(Model.Product product);
    }
}
