using SiteProduct.Db;
using SiteProduct.Models;

namespace SiteProduct.Services
{
    public class SqlTypeProductData : ITypeProductData
    {
        private readonly Repository repository;
        public SqlTypeProductData(Repository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<TypeProduct> GetCategory()
        {
            return repository.TypeProducts.ToList();
        }
    }
}
