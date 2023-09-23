﻿namespace TutorPins_Api
{
    public static class GenericClass
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
    }
    public class GeneralText
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
