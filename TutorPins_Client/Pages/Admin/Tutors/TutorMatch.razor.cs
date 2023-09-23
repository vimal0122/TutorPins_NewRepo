using Microsoft.AspNetCore.Components;
using Models;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Spinner;
using System;
using TutorPins_Client.Service;
using TutorPins_Client.Service.IService;
using Syncfusion.Blazor.Popups;
using DataAccess.Data;
using TutorPins_Client.General;
using System.Diagnostics;
using Syncfusion.Blazor.Notifications;

namespace TutorPins_Client.Pages.Admin.Tutors
{
    public class TutorMatchBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        protected ITutorService tutorService { get; set; }
        [Inject]
        IStudentService studentService { get; set; }
        [Inject]
        ICourseCategoryService courseCategoryService { get; set; }
        [Inject]
        protected IGenericService genericService { get; set; }
        [Inject]
        protected Microsoft.AspNetCore.Components.NavigationManager UriHelper { get; set; }
        [Inject]
        protected IConfiguration Configuration { get; set; }
        protected List<spGetMatchedTutorDto> Tutors { get; set; } = new List<spGetMatchedTutorDto>();
        protected SfSpinner SpinnerObj;
        protected SfGrid<spGetMatchedTutorDto> Grid;
        protected SfDialog Dialog;
        protected SfDialog StudentDialog;
        protected string StudentName;
        protected string SubjectFullName;
        protected StudentDto student;
        protected string StudentId;
        protected string TutorId;
        protected string PreferedTutorCategory;
        public bool flag = true;
        public bool studentInfoDialogflag = true;

        protected List<GeneralText> Genders = new List<GeneralText>();
        protected List<GeneralText> TutorMode = new List<GeneralText>();
        protected List<GeneralText> Race = new List<GeneralText>();
        protected List<GeneralText> TutorCategory = new List<GeneralText>();
        protected string Xvalue = "center";
        protected string Yvalue = "center";
        protected SfToast ToastObj;
        protected string ToastPosition = "Center";
        protected string ToastContent = "Tutor matched Successfully.";
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(10);
            //this.StateHasChanged();
            var objDto = await studentService.GetStudentSubject(Id);
            StudentId = objDto.StudentId.ToString();
            student = objDto.Student;
            student.PreferedTutorGender = genericService.GetGenders().Where(t => t.Id == student.PreferedTutorGender || t.Name == student.PreferedTutorGender).FirstOrDefault().Name;
            var tutorCategory = await courseCategoryService.GetTutorCategory(student.PreferedTutorCategory);
            student.PreferedTutorCategory = tutorCategory.TutorCategoryName;
            student.PreferedTutorRace = genericService.GetRaces().Where(t => t.Id == student.PreferedTutorRace || t.Name == student.PreferedTutorRace).FirstOrDefault().Name;
            student.PreferedTutoringMode = genericService.GetTutorModes().Where(t => t.Id == student.PreferedTutoringMode || t.Name == student.PreferedTutoringMode).FirstOrDefault().Name;
            if (student.StudentLocations != null)
            {
                student.LocationDetails = student.StudentLocations.Select(t => t.Location.LocationName).ToArray().Aggregate("", // start with empty string to handle empty list case.
                (current, next) => current + ", " + next);
            }
            SubjectFullName = objDto.SubjectFullName;
            await LoadTutors();
            await SpinnerObj.HideAsync();
            Genders = genericService.GetGenders();
            Race = genericService.GetRaces();

            TutorMode = genericService.GetTutorModes();
        }
        private async Task LoadTutors()
        {
            var t = await tutorService.GetTutorsBySubject(Id);
            if (t != null && t.Count() > 0)
            {
                Tutors = t.ToList();                
            }
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await SpinnerObj.ShowAsync();
            }
        }
        public void OnCommandClicked(CommandClickEventArgs<spGetMatchedTutorDto> args)
        {
            if(args.CommandColumn.Title=="add" && flag)
            {
                TutorId = args.RowData.Id.ToString();
                Dialog.ShowAsync();
                flag = false;
            }
        }
        protected void OkClick()
        {
            //Grid.DeleteRecord();   //Delete the record programmatically while clicking OK button.
            var t =  tutorService.SaveMatchedTutor(Id, TutorId);
            
            Dialog.HideAsync();
               

            //Back();
        }
        protected void CancelClick()
        {
            Dialog.HideAsync();
        }
        
        public void Closed()
        {
            flag = true;
            Back();
            //this.StateHasChanged();
            //Grid.Refresh();
            //ToastObj.ShowAsync();
            //UriHelper.NavigateTo("tutors/matchtutor/" + Id, forceLoad: true);
        }
        protected void onStudentInfoClick()
        {
            if (studentInfoDialogflag)
            {
                StudentDialog.ShowAsync();
                studentInfoDialogflag = false;
            }
        }
        public void StudentInfoClosed()
        {
            studentInfoDialogflag = true;
        }
        protected void onBackclick()
        {
            Back();
        }
        private void Back()
        {
            UriHelper.NavigateTo("students/studentsubjects/" + StudentId);
        }
    }
}
