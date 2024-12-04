using DapperTestProject.Models;

namespace DapperTestProject.Interfaces
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void DeleteProduct(int id);
        Product GetProduct(int id);
        List<Product> GetProducts();
        void UpdateProduct(Product product);
    }
}
