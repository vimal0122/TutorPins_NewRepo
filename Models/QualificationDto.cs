﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class QualificationDto
    {
        public int Id { get; set; }
        public string QualificationName { get; set; }
        public int Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual ICollection<TutorQualificationDto> TutorQualifications { get; set; }
    }
}
