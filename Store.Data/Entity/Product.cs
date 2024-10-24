﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entity
{
    public class Product:BaseEntity<int>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public int BrandID { get; set; }
        public  ProductBrand ProductBrand { get; set; }
        public int TypeID { get; set; }
        public ProductType ProductType { get; set; }
    }
}
