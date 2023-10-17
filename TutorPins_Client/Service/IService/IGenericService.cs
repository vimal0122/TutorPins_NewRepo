using TutorPins_Client.General;

namespace TutorPins_Client.Service.IService
{
    public interface IGenericService
    {
        public  List<GeneralText> GetGenders();
        public  List<GeneralText> GetRaces();
        public List<GeneralText> GetCategories();
        public List<GeneralText> GetTutorModes();
        public List<GeneralText> GetMatchStatusValues();
        public List<GeneralText> GetRatings();
    }
    
}
