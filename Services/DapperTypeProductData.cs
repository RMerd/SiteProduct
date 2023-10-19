using Dapper;
using Microsoft.Data.SqlClient;
using SiteProduct.Models;
using System.Data;

namespace SiteProduct.Services
{
    public class DapperTypeProductData : ITypeProductData
    {
        private readonly string cn;
        public DapperTypeProductData(IConfiguration conf)
        {
            cn = conf.GetSection("ConnectionStrings")["DefaultConnection"]!;
        }

        public IEnumerable<TypeProduct> GetCategory()
        {
            using (IDbConnection db = new SqlConnection(cn))
            {
                return db.Query<TypeProduct>("SELECT * FROM TypeProducts").ToList();
            }
        }
    }
}
