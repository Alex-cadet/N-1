using System;
using System.Collections.Generic;
using System.Text;

namespace N_1.buisness_objects
{
   public class Product
    {
        public string Url { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public string UnitPrice { get; set; }
       
        public Product(string Url, string Login, string Password, string ProductName, string Category, string Supplier, string UnitPrice)
        {
            this.Url = Url;
            this.Login = Login;
            this.Password = Password;
            this.ProductName = ProductName;
            this.Category = Category;
            this.Supplier = Supplier;
            this.UnitPrice = UnitPrice;
           
        }
    }
}
