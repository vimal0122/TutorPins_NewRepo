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
                new GeneralText() { Id = "4", Name = "Others" }

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
                new GeneralText() { Id = "3", Name = "Current MOE" }

            };
            return Category;
        }
        public static List<GeneralText> GetTutorModes()
        {
            List<GeneralText> TutorMode = new List<GeneralText>
            {
                new GeneralText() { Id = "1", Name = "Online" },
                new GeneralText() { Id = "2", Name = "Offline" },
                new GeneralText() { Id = "3", Name = "Both" },

            };
            return TutorMode;
        }

        
    }
    public class GeneralText
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
