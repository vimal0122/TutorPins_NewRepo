using Microsoft.AspNetCore.Components;
using Models;
using Syncfusion.Blazor.Spinner;

namespace TutorPins_Client.Pages.GenericComponents
{
    public class StudentRequestLogBase : ComponentBase
    {
        [Parameter]
        public IList<spGetStudentRequestLogDto> RequestLogs { get; set; }

    }
}
