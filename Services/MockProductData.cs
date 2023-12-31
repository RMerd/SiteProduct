﻿using SiteProduct.Models;

namespace SiteProduct.Services
{
    public class MockProductData : IProductData
    {
        private readonly List<Product> _products;
        public MockProductData()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Шилдт Г. С# 4.0: Полное руководство",
                    Price = 750.0m,
                    ProductionDate = DateTime.Parse("01.04.2017"),
                    CategoryId = 2
                },
                new Product
                {
                    Id = 2,
                    Name = "Оперативная память Kingston RAM 1x4GB DDR4",
                    Price = 1975.0M,
                    ProductionDate = DateTime.Parse("01.05.2021"),
                    CategoryId = 3
                },
                new Product
                {
                    Id = 3,
                    Name = "Apple IPhone SE 64GB",
                    Price = 34789.0M,
                    ProductionDate = DateTime.Parse("01.12.2020"),
                    CategoryId = 4
                }
            };
        }

        public int Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
            return product.Id;
        }

        public void Save (Product product)
        {
            _products.Where(p => p.Id == product.Id).ToList().ForEach(p => 
            { 
                p.Name = product.Name; 
                p.Price = product.Price; 
                p.ProductionDate = product.ProductionDate; 
                p.CategoryId = product.CategoryId; 
            });
        }
        
        public void Delete(int id)
        {
            _products.Remove(_products.FirstOrDefault(p => p.Id == id)!);
        }

        public Product Get(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id) ?? new Product { Id = -1 };
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
    }
}
