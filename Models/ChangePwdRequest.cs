using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ChangePwdRequest
    {
        public Int64 UserId { get; set; }
        public string CurrentPwd { get; set; }
        public string NewPwd { get; set; }
        public string ConfirmPwd { get; set; }
    }
}
