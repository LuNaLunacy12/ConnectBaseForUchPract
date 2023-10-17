using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class CLUsers
    {
        public CLUsers() { }
        public CLUsers(int usersid, string fullnameusers, string userphone, string userpassword) { 
            this.Usersid = usersid;
            this.FullNameUsers = fullnameusers;
            this.Userphone = userphone;
            this.Userpassword = userpassword;
        }
        public int Usersid { get; set; }
        public string FullNameUsers { get; set; }
        public string Userphone { get; set; }
        public string Userpassword { get; set; }

    }
}
