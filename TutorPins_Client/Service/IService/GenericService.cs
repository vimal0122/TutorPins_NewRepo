using TutorPins_Client.General;

namespace TutorPins_Client.Service.IService
{
    public class GenericService : IGenericService
    {
        public List<GeneralText> GetCategories()
        {
            return GenericClass.GetCategories();
        }

        public List<GeneralText> GetGenders()
        {
            return GenericClass.GetGenders();
        }

        public List<GeneralText> GetRaces()
        {
            return GenericClass.GetRaces();
        }

        public List<GeneralText> GetTutorModes()
        {
            return GenericClass.GetTutorModes();
        }
        public List<GeneralText> GetMatchStatusValues()
        {
            return GenericClass.GetMatchStatus();
        }

        public List<GeneralText> GetRatings()
        {
            return GenericClass.GetRatings();
        }
        public List<GeneralText> GetRoles()
        {
            return GenericClass.GetRoles();
        }
        public List<GeneralText> GetUserStatus()
        {
            return GenericClass.GetUserStatus();
        }
    }
}
