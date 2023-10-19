using SiteProduct.Db;
using SiteProduct.Models;

namespace SiteProduct.Services
{
    public class SqlProductData : IProductData
    {
        private readonly Repository repository;
        public SqlProductData(Repository repository)
        {
            this.repository = repository;
        }

        public int Add(Product product)
        {
            repository.Add(product);
            repository.SaveChanges();
            return product.Id;
        }

        public void Delete(int id)
        {
            var product = repository.Find<Product>(id);
            if (product != null) repository.Remove(product);
            repository.SaveChanges();
        }

        public Product Get(int id)
        {
            return repository.Find<Product>(id) ?? new Product() { Id = -1 };
        }

        public IEnumerable<Product> GetAll()
        {
            return repository.Products.ToList();
        }

        public void Save(Product product)
        {
            repository.Update(product);
            repository.SaveChanges(); 
        }
    }
}
