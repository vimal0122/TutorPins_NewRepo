using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TutorPins_Client.Service.IService;
using System;
using Models;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Spinner;


namespace TutorPins_Client.Pages.Admin.Students
{
    public class MatchedStudentListBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime {get;set;}
        [Inject]
        IStudentService studentService { get; set; }
        [Inject] 
        IGenericService genericService { get; set; }
        protected IEnumerable<StudentDto> Students { get; set; } = new List<StudentDto>();
        public StudentDto RowDetails { get; set; }
        public bool IsVisible { get; set; } = false;
        protected string Xvalue = "center";
        protected string Yvalue = "center";

       protected SfSpinner SpinnerObj;
       protected SfGrid<StudentDto> Grid;
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1000);
            await LoadStudents();
            await SpinnerObj.HideAsync();

        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await SpinnerObj.ShowAsync();
            }
        }
        protected async Task LoadStudents()
        {
            Students = await studentService.GetMatchedStudents();
        }
        protected void OnCommandClicked(CommandClickEventArgs<StudentDto> args)
        {
            RowDetails = args.RowData;
            RowDetails.PreferedTutorGender = genericService.GetGenders().Where(t => t.Id == RowDetails.PreferedTutorGender || t.Name == RowDetails.PreferedTutorGender).FirstOrDefault().Name;
            RowDetails.PreferedTutorCategory = RowDetails.PreferedTutorCategory == "-1" ? "No Preference" : genericService.GetCategories().Where(t => t.Id == RowDetails.PreferedTutorCategory || t.Name == RowDetails.PreferedTutorCategory).FirstOrDefault().Name;
            RowDetails.PreferedTutorRace = genericService.GetRaces().Where(t => t.Id == RowDetails.PreferedTutorRace || t.Name == RowDetails.PreferedTutorRace).FirstOrDefault().Name;
            RowDetails.PreferedTutoringMode = genericService.GetTutorModes().Where(t => t.Id == RowDetails.PreferedTutoringMode || t.Name == RowDetails.PreferedTutoringMode).FirstOrDefault().Name;
            RowDetails.LocationDetails = RowDetails.StudentLocations.Select(t => t.Location.LocationName).ToArray().Aggregate("", // start with empty string to handle empty list case.
            (current, next) => current + ", " + next);
            IsVisible = true;
        }
    }
}
