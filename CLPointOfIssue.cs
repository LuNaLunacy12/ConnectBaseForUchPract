using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class CLPointOfIssue
    {
        public CLPointOfIssue() { }
        public CLPointOfIssue(int pointofissue_id, string adress)
        {
            this.PointofIssueId = pointofissue_id;
            this.Adress = adress;
        }
        public int PointofIssueId { get; set; }
        public string Adress { get; set; }
    }
}
