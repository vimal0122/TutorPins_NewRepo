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
using Newtonsoft.Json.Linq;

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
        protected SfDialog TutorDialog;
        protected SfDialog StatusDialog;
        protected string StudentName;
        protected string SubjectFullName;
        protected StudentDto student;
        protected TutorDto tutorInfo;
        protected string StudentId;
        protected string TutorId;
        protected string PreferedTutorCategory;
        protected string SelectedMatchStatusId;
        protected string tempTutorCategory;
        public bool flag = true;
        public bool studentInfoDialogflag = true;
        public bool tutorInfoDialogflag = true;
        public bool statusInfoDialogflag = true;

        protected List<GeneralText> Genders = new List<GeneralText>();
        protected List<GeneralText> TutorMode = new List<GeneralText>();
        protected List<GeneralText> Race = new List<GeneralText>();
        protected List<GeneralText> TutorCategory = new List<GeneralText>();
        protected List<GeneralText> MatchStatusList = new List<GeneralText>();
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
            if (!student.PreferedTutorCategory.Equals("-1"))
            {
                var tutorCategory = await courseCategoryService.GetTutorCategory(student.PreferedTutorCategory);
                student.PreferedTutorCategory = tutorCategory.TutorCategoryName;
            }
            else
            {
                student.PreferedTutorCategory = "No Preference";
            }
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
            MatchStatusList=genericService.GetMatchStatusValues();
            TutorMode = genericService.GetTutorModes();
        }
        private async Task LoadTutors()
        {
            var t = await tutorService.GetTutorsBySubject(Id);
            if (t != null && t.Count() > 0)
            {
                Tutors = t.ToList();     
                for (int i = 0; i < Tutors.Count(); i++) 
                {
                    var enumDisplayStatus = (MatchStatusValues)Tutors[i].MatchStatusId;
                    string stringValue = Tutors[i].MatchStatusId >0? enumDisplayStatus.ToString():"No";
                    Tutors[i].AlreadyMatched = stringValue;
                }
            }
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await SpinnerObj.ShowAsync();
            }
        }
        public async void OnCommandClicked(CommandClickEventArgs<spGetMatchedTutorDto> args)
        {
            if(args.CommandColumn.Title=="add" && flag)
            {
                TutorId = args.RowData.Id.ToString();
                await Dialog.ShowAsync();
                flag = false;
            }
            else if(args.CommandColumn.Title == "View" && tutorInfoDialogflag)
            {
                TutorId = args.RowData.Id.ToString();
                var t = await tutorService.GetTutor(TutorId);
                tutorInfo = t;
                tutorInfo.TutorGender = genericService.GetGenders().Where(t => t.Id == tutorInfo.TutorGender || t.Name == tutorInfo.TutorGender).FirstOrDefault().Name;
                if(tempTutorCategory == null)
                {
                    tempTutorCategory = tutorInfo.TutorCategory;
                }
                var tutorCategory = await courseCategoryService.GetTutorCategory(tempTutorCategory);
                tutorInfo.TutorCategory = tutorCategory.TutorCategoryName;
                
                tutorInfo.TutorRace = genericService.GetRaces().Where(t => t.Id == tutorInfo.TutorRace || t.Name == tutorInfo.TutorRace).FirstOrDefault().Name;
                tutorInfo.TutorMode = genericService.GetTutorModes().Where(t => t.Id == tutorInfo.TutorMode || t.Name == tutorInfo.TutorMode).FirstOrDefault().Name;
                tutorInfo.LocationDetails = tutorInfo.TutorLocations.Select(t => t.Location.LocationName).ToArray().Aggregate("", // start with empty string to handle empty list case.
                (current, next) => current + ", " + next);
                tutorInfo.QualificationDetails = tutorInfo.TutorQualifications.Select(t => t.Qualification.QualificationName).ToArray().Aggregate("", // start with empty string to handle empty list case.
                (current, next) => current + ", " + next);
                await TutorDialog.ShowAsync();
                tutorInfoDialogflag = false;
            }
            else if (args.CommandColumn.Title == "statusupdate" && statusInfoDialogflag)
            {
                TutorId = args.RowData.Id.ToString();
                string[] lstStrings = new string[] { Convert.ToString((int)MatchStatusValues.Requested), Convert.ToString((int)MatchStatusValues.Completed), Convert.ToString((int)MatchStatusValues.Terminated), args.RowData.MatchStatusId.ToString() };                
                MatchStatusList = MatchStatusList.Where(x => !lstStrings.Contains(x.Id)).ToList();
                await StatusDialog.ShowAsync();
                statusInfoDialogflag = false;
            }
        }
        protected async Task AssignTutor(spGetMatchedTutorDto pos)
        {
            if (flag)
            {
                TutorId = pos.Id.ToString();
                await Dialog.ShowAsync();
                flag = false;
            }
        }
        protected async Task UpdateStatus(spGetMatchedTutorDto pos)
        {
            if (statusInfoDialogflag)
            {
                TutorId = pos.Id.ToString(); //args.RowData.Id.ToString();
                string[] lstStrings = new string[] { Convert.ToString((int)MatchStatusValues.Requested), Convert.ToString((int)MatchStatusValues.Completed), Convert.ToString((int)MatchStatusValues.Terminated), pos.MatchStatusId.ToString() };
                MatchStatusList = MatchStatusList.Where(x => !lstStrings.Contains(x.Id)).ToList();
                await StatusDialog.ShowAsync();
                statusInfoDialogflag = false;
            }
        }
        protected void OkClick()
        {
            //Grid.DeleteRecord();   //Delete the record programmatically while clicking OK button.
            int matchStatusId = (int)MatchStatusValues.Broadcasted;
            var t =  tutorService.SaveMatchedTutor(Id, TutorId, Convert.ToString(matchStatusId));
            
            Dialog.HideAsync();
               

            //Back();
        }
        protected void CancelClick()
        {
            Dialog.HideAsync();
        }
        protected void OkStatusClick()
        {
            
            var t = tutorService.SaveMatchedTutor(Id, TutorId, Convert.ToString(SelectedMatchStatusId));

            StatusDialog.HideAsync();

            //Back();
        }
        protected void CancelStatusClick()
        {
            StatusDialog.HideAsync();
        }
        public void Closed()
        {
            flag = true;
           // Back();
            //this.StateHasChanged();
            //Grid.Refresh();
            //ToastObj.ShowAsync();
            //UriHelper.NavigateTo("tutors/matchtutor/" + Id, forceLoad: true);
        }
        public void StatusClosed()
        {
            statusInfoDialogflag = true;
            // Back();
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
        public void TutorInfoClosed()
        {
            tutorInfoDialogflag = true;
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
