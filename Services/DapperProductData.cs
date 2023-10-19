using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SiteProduct.Models;
using System.Data;

namespace SiteProduct.Services
{
    public class DapperProductData : IProductData
    {
        private readonly string cn;
        public DapperProductData(IConfiguration conf)
        {
            cn = conf.GetSection("ConnectionStrings")["DefaultConnection"]!;
        }

        public int Add(Product product)
        {
            using (IDbConnection db = new SqlConnection(cn))
            {
                var sqlQuery =
                    @"INSERT INTO Products (Name, Price, ProductionDate, CategoryId) 
                      VALUES 
                      (
                        @Name,
                        @Price, 
                        @ProductionDate,
                        @CategoryId
                      );
                    SELECT CAST(SCOPE_IDENTITY() as int)";
                int? productId = db.Query<int>(sqlQuery, product).FirstOrDefault();
                product.Id = productId.Value;
            }
            return product.Id;
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(cn))
            {
                var sqlQuery = "DELETE FROM Products WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Product Get(int id)
        {
            using (IDbConnection db = new SqlConnection(cn))
            {
                return db.Query<Product>("SELECT * FROM Products WHERE id = @id", new { id }).FirstOrDefault() ?? new Product() { Id = -1 };
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection db = new SqlConnection(cn))
            {
                return db.Query<Product>("SELECT * FROM Products").ToList();
            }
        }

        public void Save(Product product)
        {
            using (IDbConnection db = new SqlConnection(cn))
            {
                var sqlQuery = @"
                        UPDATE Products
                        SET
                        Name = @Name,
                        Price = @Price,
                        ProductionDate = @ProductionDate,
                        CategoryId = @CategoryId
                        WHERE Id = @id";
                db.Execute(sqlQuery, product);
            }
        }
    }
}
