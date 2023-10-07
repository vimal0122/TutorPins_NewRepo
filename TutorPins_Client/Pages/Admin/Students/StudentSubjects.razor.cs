using DataAccess.Data;
using Microsoft.AspNetCore.Components;
using Models;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Spinner;
using System.Diagnostics;
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
        public List<StudentSubjectDto> SubjectDetails = new List<StudentSubjectDto>();
        public List<StudentSubjectDto> tempSubjectDetails = new List<StudentSubjectDto>();
        protected SfSpinner SpinnerObj;
        protected SfGrid<StudentSubjectDto> Grid;
        protected string StudentName;
        string studentStatus;
        protected override async Task OnInitializedAsync()
        {
            var studentdto = await studentService.GetStudent(Convert.ToInt32(Id));
            tempSubjectDetails = studentdto.StudentSubjects.ToList();
            StudentName= studentdto.StudentName.ToUpper();
            studentStatus = studentdto.StudentStatus.ToLower();
            SubjectDetails = tempSubjectDetails;
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
    }
}
