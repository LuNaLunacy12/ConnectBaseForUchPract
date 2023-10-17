using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class CLProducts
    {
        public CLProducts() {}
        public CLProducts(int product_id, string photo, string nameproduct, string description, int price, int discount, string manufactures, int quantity)
        {
            this.Product_ID = product_id;
            this.Photo = photo;
            this.NameProduct = nameproduct;
            this.Description = description;
            this.Manufactures = manufactures;
            this.Price = price;
            this.Discount = discount;
            this.Quantity = quantity;

        }
        public int Product_ID { get; set; }
        public string Photo { get; set;}
        public string NameProduct { get; set;}
        public string Description { get; set;}
        public string Manufactures { get; set;}
        public int Price { get; set;}
        public int Discount { get; set;}
        public int Quantity { get; set;}

    }
}
