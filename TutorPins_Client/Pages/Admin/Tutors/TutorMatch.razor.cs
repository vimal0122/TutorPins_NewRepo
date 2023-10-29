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
        protected List<spGetMatchedTutorDto> TutorsBeforeFilter { get; set; } = new List<spGetMatchedTutorDto>();
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
        protected string MatchRemarks;
        public bool flag = true;
        public bool studentInfoDialogflag = true;
        public bool tutorInfoDialogflag = true;
        public bool statusInfoDialogflag = true;

        protected List<GeneralText> Genders = new List<GeneralText>();
        protected List<GeneralText> TutorMode = new List<GeneralText>();
        protected List<GeneralText> Race = new List<GeneralText>();
        protected List<GeneralText> TutorCategory = new List<GeneralText>();
        protected List<GeneralText> MatchStatusList = new List<GeneralText>();
        protected List<LocationDto> locationList = new List<LocationDto>();
        protected List<GeneralText> RatingList = new List<GeneralText>();
        
        public int HourlyRateMinValue = 0;
        public int HourlyRateMaxValue = 0;

        protected string FilterTutorCategoryId;
        protected string FilterTutorGenderId;
        protected string FilterRaceId;
        protected string FilterRatingValue;

        protected string FilterLocationId;
        protected string FilterModeId;
        


        protected string Xvalue = "center";
        protected string Yvalue = "center";
        protected SfToast ToastObj;
        protected string ToastPosition = "Center";
        protected string ToastContent = "Tutor matched Successfully.";
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(5);
            //this.StateHasChanged();
            var objDto = await studentService.GetStudentSubject(Id);
            int courseCategoryId = objDto.CourseSubject.Course.CourseCategoryId;
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
            IEnumerable<LocationDto> locations = await courseCategoryService.GetAllLocations();
            locationList = locations.ToList();
            RatingList = genericService.GetRatings();
            List<GeneralText> tempTutorCategory = new List<GeneralText>();
            IEnumerable<TutorCategoryDto> tutorCategories = await courseCategoryService.GetTutorCategories(courseCategoryId.ToString());

            if (tutorCategories.Any())
            {
                GeneralText generalText;
                //TutorCategory.Clear();
                foreach (var item in tutorCategories)
                {
                    generalText = new GeneralText();
                    generalText.Name = item.TutorCategoryName;
                    generalText.Id = item.Id.ToString();
                    TutorCategory.Add(generalText);
                }
            }
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
                TutorsBeforeFilter = Tutors;
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
                string[] lstStrings = new string[] { Convert.ToString((int)MatchStatusValues.Requested), Convert.ToString((int)MatchStatusValues.NoShow), args.RowData.MatchStatusId.ToString() };                
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
                string[] lstStrings = new string[] { Convert.ToString((int)MatchStatusValues.Requested), Convert.ToString((int)MatchStatusValues.Completed), Convert.ToString((int)MatchStatusValues.Terminated), Convert.ToString((int)MatchStatusValues.NoShow), Convert.ToString((int)MatchStatusValues.InProcess), pos.MatchStatusId.ToString() };
                MatchStatusList = MatchStatusList.Where(x => !lstStrings.Contains(x.Id)).ToList();
                await StatusDialog.ShowAsync();
                statusInfoDialogflag = false;
            }
        }
        protected void OkClick()
        {
            //Grid.DeleteRecord();   //Delete the record programmatically while clicking OK button.
            int matchStatusId = (int)MatchStatusValues.Broadcasted;
            var t =  tutorService.SaveMatchedTutor(Id, TutorId, Convert.ToString(matchStatusId), MatchRemarks);
            
            Dialog.HideAsync();
               

            //Back();
        }
        protected void CancelClick()
        {
            Dialog.HideAsync();
        }
        protected void OkStatusClick()
        {
            
            var t = tutorService.SaveMatchedTutor(Id, TutorId, Convert.ToString(SelectedMatchStatusId),MatchRemarks);

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
        protected async Task FilterTutor()
        {
            await Task.Delay(1);
            if (!string.IsNullOrWhiteSpace(FilterLocationId))
            {
                FilterTutorRequest r = new FilterTutorRequest();
                r.Id = Convert.ToInt32(Id);
                r.FilterLocationId = Convert.ToInt32(FilterLocationId);
                if (!string.IsNullOrWhiteSpace(FilterTutorCategoryId))
                    r.FilterTutorCategoryId= FilterTutorCategoryId;

                if (!string.IsNullOrWhiteSpace(FilterTutorGenderId))
                    r.FilterTutorGenderId= FilterTutorGenderId;

                if (!string.IsNullOrWhiteSpace(FilterRaceId))
                    r.FilterRaceId= FilterRaceId;

                if (!string.IsNullOrWhiteSpace(FilterModeId))
                    r.FilterModeId= FilterModeId;

                if (!string.IsNullOrWhiteSpace(FilterRatingValue))
                    r.FilterRatingValue = FilterRatingValue;

				if (HourlyRateMinValue > 0)
					r.HourlyRateMinValue = HourlyRateMinValue;

				if (HourlyRateMaxValue > 0)
					r.HourlyRateMaxValue = HourlyRateMaxValue;

				var x = await tutorService.GetTutorsByFilters(r);
                Tutors = x.ToList();
            }
            else
            {
                Tutors = FilterTutorList().ToList();
            }
        }
        private IQueryable<spGetMatchedTutorDto> FilterTutorList()
        {
            var query = TutorsBeforeFilter.AsQueryable();

            if (!string.IsNullOrWhiteSpace(FilterTutorCategoryId))
                query = query.Where(d => d.TutorCategory == FilterTutorCategoryId);

            if (!string.IsNullOrWhiteSpace(FilterTutorGenderId))
                query = query.Where(d => d.TutorGender == FilterTutorGenderId);

            if (!string.IsNullOrWhiteSpace(FilterRaceId))
                query = query.Where(d => d.TutorRace == FilterRaceId);

            if (!string.IsNullOrWhiteSpace(FilterModeId))
                query = query.Where(d => d.TutorMode == FilterModeId);

            if (!string.IsNullOrWhiteSpace(FilterRatingValue))
                query = query.Where(d => d.TutorRating == FilterRatingValue);

			if (HourlyRateMinValue > 0)
				query = query.Where(d => d.TutorRate >= HourlyRateMinValue);

			if (HourlyRateMaxValue > 0)
				query = query.Where(d => d.TutorRate <= HourlyRateMaxValue);
			return query;
        }
        protected async Task ClearFilterTutor()
        {
            await Task.Delay(1);
                FilterTutorCategoryId  =string.Empty;
                FilterTutorGenderId    =string.Empty;
                FilterRaceId           =string.Empty;
                FilterRatingValue      =string.Empty;
                FilterLocationId       =string.Empty;
                FilterModeId            = string.Empty;
            Tutors = TutorsBeforeFilter;
        }
    }
}
