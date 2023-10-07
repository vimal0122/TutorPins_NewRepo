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
    }
}
