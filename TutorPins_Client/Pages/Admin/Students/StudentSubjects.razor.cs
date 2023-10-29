using DataAccess.Data;
using Microsoft.AspNetCore.Components;
using Models;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Popups;
using Syncfusion.Blazor.Spinner;
using System.Diagnostics;
using TutorPins_Client.General;
using TutorPins_Client.Pages.Admin.Courses;
using TutorPins_Client.Service;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Pages.Admin.Students
{
    public class StudentSubjectsBase:ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        IStudentService studentService { get; set; }
        [Inject]
        protected Microsoft.AspNetCore.Components.NavigationManager UriHelper { get; set; }
        [Inject]
        protected IGenericService genericService { get; set; }
        [Inject]
        protected ITutorService tutorService { get; set; }
        public List<StudentSubjectDto> SubjectDetails = new List<StudentSubjectDto>();
        public List<StudentSubjectDto> tempSubjectDetails = new List<StudentSubjectDto>();
        protected List<GeneralText> MatchStatusList = new List<GeneralText>();
        protected SfSpinner SpinnerObj;
        protected SfDialog StatusDialog;
        protected SfDialog LogDialog;
        protected string MatchRemarks;
        protected SfGrid<StudentSubjectDto> Grid;
        protected string StudentName;
        string studentStatus;
        protected string SelectedMatchStatusId;
        protected int SelectedSubjectId;
        public bool statusInfoDialogflag = true;
        public bool logInfoDialogflag = true;
        protected IList<spGetStudentRequestLogDto> studentRequestLogDtoList;    
        protected override async Task OnInitializedAsync()
        {
            var studentdto = await studentService.GetStudent(Convert.ToInt32(Id));
            tempSubjectDetails = studentdto.StudentSubjects.ToList();
            StudentName= studentdto.StudentName.ToUpper();
            studentStatus = studentdto.StudentStatus.ToLower();
            SubjectDetails = tempSubjectDetails;
            MatchStatusList = genericService.GetMatchStatusValues();
            this.StateHasChanged();
           
            //IEnumerable<CourseCategoryDto> courseCategories = await courseCategoryService.GetCourseCategories();
            //CourseCategoryList = courseCategories.ToList();



            //IEnumerable<LocationDto> locations = await courseCategoryService.GetAllLocations();
            //locationList = locations.ToList();

            //Genders = genericSerice.GetGenders();
            //Race = genericSerice.GetRaces();

            //TutorMode = genericSerice.GetTutorModes();
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var studentdto = await studentService.GetStudent(Convert.ToInt32(Id));
                studentStatus = studentdto.StudentStatus.ToLower();
                SubjectDetails = studentdto.StudentSubjects.ToList(); 
            }
        }
        protected void onBackclick()
        {
            Back();
        }
        private void Back()
        {
            if(studentStatus == "matched")
                UriHelper.NavigateTo("matchedstudents");
            else
            UriHelper.NavigateTo("students");
        }
        protected async Task UpdateStatus(StudentSubjectDto pos)
        {
            if (statusInfoDialogflag)
            {
                SelectedSubjectId = pos.Id;
                MatchStatusList = MatchStatusList.Where(x=>x.Id=="10").ToList();
                await StatusDialog.ShowAsync();
                statusInfoDialogflag = false;
            }
        }
        protected async Task ShowLog(StudentSubjectDto pos)
        {
            if (logInfoDialogflag)
            {
                SelectedSubjectId = pos.Id;
                StudentRequestLogRequest request = new StudentRequestLogRequest();
                request.StudentSubjectId = SelectedSubjectId;
                request.TutorId = 0;
                var x = await  studentService.GetStudentRequestLogs(request);
                studentRequestLogDtoList = x.ToList();
                await LogDialog.ShowAsync();
                logInfoDialogflag = false;
            }
        }
        
        protected void OkStatusClick()
        {
            //Grid.DeleteRecord();   //Delete the record programmatically while clicking OK button.
            int matchStatusId = (int)MatchStatusValues.NoShow;
            var t = tutorService.SaveMatchedTutor(SelectedSubjectId.ToString(), "0", Convert.ToString(matchStatusId), MatchRemarks);

            StatusDialog.HideAsync();


            //Back();
        }
        protected void CancelStatusClick()
        {
            StatusDialog.HideAsync();
        }
        public void StatusClosed()
        {
            statusInfoDialogflag = true;
            
        }
    }
}
