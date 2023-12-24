using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserSession
    {
        public Int64 UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public int ExpiresIn { get;set; }
        public DateTime ExpiryTimeStamp { get; set;}
    }
}
