using Microsoft.AspNetCore.Components;
using Models;
using Syncfusion.Blazor.Popups;
using TutorPins_Client.Service;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Pages.GenericComponents
{
    public class StudentHistoryBase : ComponentBase
    {
        [Parameter]
        public IList<spGetTuitionByTutorAndStatusDto> OldTuitions { get; set; }
		[Inject]
		IStudentService studentService { get; set; }
		protected SfDialog LogDialog;
		public bool logInfoDialogflag = true;
		protected IList<spGetStudentRequestLogDto> studentRequestLogDtoList;
		protected async Task ShowLog(spGetTuitionByTutorAndStatusDto pos)
		{
			if (logInfoDialogflag)
			{
				
				StudentRequestLogRequest request = new StudentRequestLogRequest();
				request.StudentSubjectId = pos.StudentSubjectId.Value;
				request.TutorId = 0;
				var x = await studentService.GetStudentRequestLogs(request);
				studentRequestLogDtoList = x.ToList();
				await LogDialog.ShowAsync();
				logInfoDialogflag = false;
			}
		}
	}
}
