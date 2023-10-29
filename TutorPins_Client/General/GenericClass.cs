using System.Diagnostics;

namespace TutorPins_Client.General
{
    public class GenericClass
    {
        public static List<GeneralText> GetGenders()
        {
            List<GeneralText> Genders = new List<GeneralText>
            {
                new GeneralText() { Id = "1", Name = "Male" },
                new GeneralText() { Id = "2", Name = "Female" }

            };
            return Genders;
        }
        public static List<GeneralText> GetRaces()
        {
            List<GeneralText> Race = new List<GeneralText>
            {
                new GeneralText() { Id = "1", Name = "Indian" },
                new GeneralText() { Id = "2", Name = "Malay" },
                new GeneralText() { Id = "3", Name = "Chinese" },
                new GeneralText() { Id = "4", Name = "Others" },
                new GeneralText() { Id = "5", Name = "No Preference" }

            };
            return Race;
        }
        public static List<GeneralText> GetCategories()
        {
            List<GeneralText> Category = new List<GeneralText>
            {
                new GeneralText() { Id = "1", Name = "PartTime" },
                new GeneralText() { Id = "2", Name = "FullTime" },
                new GeneralText() { Id = "3", Name = "Ex-MOE" },
                new GeneralText() { Id = "4", Name = "Current MOE" },
                new GeneralText() { Id = "5", Name = "No Preference" }

            };
            return Category;
        }
        public static List<GeneralText> GetTutorModes()
        {
            List<GeneralText> TutorMode = new List<GeneralText>
            {
                new GeneralText() { Id = "1", Name = "Online" },
                new GeneralText() { Id = "2", Name = "Home" },
                new GeneralText() { Id = "3", Name = "No Preference" },

            };
            return TutorMode;
        }
        public static List<GeneralText> GetMatchStatus()
        {
            List<GeneralText> MatchStatus = new List<GeneralText>
            {
                new GeneralText() { Id = "1", Name = "Requested" },
                new GeneralText() { Id = "2", Name = "Broadcasted" },
                new GeneralText() { Id = "3", Name = "Accepted" },
                new GeneralText() { Id = "4", Name = "Rejected" },
                new GeneralText() { Id = "5", Name = "Matched" },
                new GeneralText() { Id = "6", Name = "Completed" },
                new GeneralText() { Id = "7", Name = "Terminated" },

				new GeneralText() { Id = "8", Name = "Awaiting Confirmation" },
				new GeneralText() { Id = "9", Name = "Taken" },
				new GeneralText() { Id = "10", Name = "No Show" },
				new GeneralText() { Id = "11", Name = "In Process" }				

			};
            return MatchStatus;
        }
        public static List<GeneralText> GetRatings()
        {
            List<GeneralText> Category = new List<GeneralText>
            {
                new GeneralText() { Id = "0", Name =  "0" },
                new GeneralText() { Id = "1", Name =  "1" },
                new GeneralText() { Id = "2", Name =  "2" },
                new GeneralText() { Id = "3", Name =  "3" },
                new GeneralText() { Id = "4", Name =  "4" },
                new GeneralText() { Id = "5", Name =  "5" }

            };
            return Category;
        }
    }
    public class GeneralText
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
    public enum MatchStatusValues
    {
        Requested=1,  
        Broadcasted,  
        Accepted,     
        Rejected,     
        Matched,      
        Completed,    
        Terminated,
		AwaitingConfirmation,
		Taken,
		NoShow,
        InProcess

    }
}
