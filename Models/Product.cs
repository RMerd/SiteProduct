﻿using System.ComponentModel.DataAnnotations;

namespace SiteProduct.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(50), Display(Name = "Наименование")]
        public string Name { get; set; }
        [Required, Range(0.01d, 10000d), Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Required, Display(Name = "Дата изготовления")]
        public DateTime ProductionDate { get; set; }
        [Required, Display(Name = "Категория")]
        public int CategoryId { get; set; }
    }
}
