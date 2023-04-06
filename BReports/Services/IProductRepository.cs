using BReports.Models.DBModels;

namespace BReports.Services
{
    public interface IProductRepository : IRepository<Product>
    {
        void changeSomething(Product product);
    }
}
