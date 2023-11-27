using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
	public class spDashboardCount
	{
        public int TutorRequestCount { get; set; }
        public int TutorRegCount { get; set; }
        public int TutorMatchCount { get; set; }
		public int OngoingTuitionCount { get; set; }
		public int FeedbackCount { get; set; }
	}
    public class spTutorDashboardCount
    {
        public int BroadCastCount { get; set; }
        public int MyTutionCount { get; set; }
        public int CompletedCount { get; set; }
        public int PastRequestCount { get; set; }

    }
}
