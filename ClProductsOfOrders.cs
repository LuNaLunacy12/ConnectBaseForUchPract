using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class ClProductsOfOrders
    {
        public ClProductsOfOrders(int orderid, int productid, int quntity)
        {
            this.OrderID = orderid;
            this.ProductID = productid;
            this.Quntity = quntity;
        }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quntity { get; set; }
    }
}
