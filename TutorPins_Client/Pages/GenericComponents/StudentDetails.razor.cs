using Microsoft.AspNetCore.Components;
using Models;
using TutorPins_Client.Service;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Pages.GenericComponents
{
    public class StudentDetailsBase : ComponentBase
    {
        [Parameter]
        public StudentDto StudentObject { get; set; }
        [Parameter]
        public bool IsDetailed { get; set; }
        [Parameter]
        public bool ShowSubjects { get; set; }
        [Inject]
        protected IGenericService genericService { get; set; }
        
    }
}
