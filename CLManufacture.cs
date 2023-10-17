using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class CLManufacture
    {
        public CLManufacture() { }
        public CLManufacture(string namemanufacturer)
        {
            this.NameManufacturer = namemanufacturer;
        }
        public string NameManufacturer { get; set; }
    }
}
