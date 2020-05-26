using System;
using System.Collections.Generic;
using System.Text;

namespace N_1.buisness_objects
{
   public class Product
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public string UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public string UntInStock { get; set; }
        public string UnitOnOrder { get; set; }
        public string ReorderLevel { get; set; }
        public string Discontinued { get; set; }
        public Product(string ProductName, string Category, string Supplier, string UnitPrice, string QuantityPerUnit,
            string UntInStock, string UnitOnOrder, string ReorderLevel,string Discontinued)
        {
            this.ProductName = ProductName;
            this.Category = Category;
            this.Supplier = Supplier;
            this.UnitPrice = UnitPrice;
            this.QuantityPerUnit = QuantityPerUnit;
            this.UntInStock = UntInStock;
            this.UnitOnOrder = UnitOnOrder;
            this.ReorderLevel = ReorderLevel;
            this.Discontinued = Discontinued;
        }
    }
}
