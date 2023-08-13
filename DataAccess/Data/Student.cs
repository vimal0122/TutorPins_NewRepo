using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class Student
    {
        [Key]
        public int Id {get;set;}
        public string StudentName {get;set;} 
        public string StudentEmail {get;set;}
        public string StudentPhoneNo {get;set;}
        public string ParentName {get;set;}
        public string ParentRelation {get;set;}
        public string ParentEmail {get;set;}
        public string ParentPhoneNo {get;set;}
        public string AdminRemarks {get;set;}
        public string StudentStatus {get;set;}
        public string CreatedBy {get;set;}
        public DateTime? CreatedDate {get;set;}
        public string UpdatedBy {get;set;}
        public DateTime? UpdatedDate {get;set;}
    }
}
