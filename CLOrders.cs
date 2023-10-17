using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class CLOrders
    {
        public CLOrders() { }
        public CLOrders(int order_id, int product_id, int quantity, int userid, int pointofissue, DateTime dataOrder, int kode) {
            this.Order_ID = order_id;
            this.Userid = userid;
            this.Pointofissue = pointofissue;
            this.DataOrder = dataOrder;
            this.Kode = kode;
        }
        public int Order_ID { get; set; }
        public int Userid { get; set; }
        public int Pointofissue { get; set;}
        public DateTime DataOrder { get; set; }
        public int Kode { get; set; }

    }
}
