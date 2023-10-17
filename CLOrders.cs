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
        public CLOrders(int order_id, int userid, int pointofissue, string kode, DateTime dataOrder) {
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
        public string Kode { get; set; }

    }
}
