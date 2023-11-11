using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class UserDetail
    {
        [Key]
        public Int64 Id { get; set; }
        public string FullName { get; set; }
	    public string EmailId {get; set; }
	    public string UserPassword {get; set; }
		public int PasswordChangeCount {get; set; }
		public string RoleId { get; set; }
		public string CreatedBy { get; set; }	
		public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UserStatus { get; set; }
    }
}
