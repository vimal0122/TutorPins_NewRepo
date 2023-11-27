using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TutorPins_Client.Service.IService;
using System;
using Models;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Spinner;
using TutorPins_Client.Service;

namespace TutorPins_Client.Pages.Admin.Tutors
{
	public class FeedbackListBase : ComponentBase
	{
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        [Inject]
        ITutorService tutorService { get; set; }
        [Inject]
        IGenericService genericService { get; set; }
        protected IEnumerable<spGetAllFeedbackDto> feedbacks { get; set; } = new List<spGetAllFeedbackDto>();
        public spGetAllFeedbackDto RowDetails { get; set; }
        public bool IsVisible { get; set; } = false;
        protected string Xvalue = "center";
        protected string Yvalue = "center";

        protected SfSpinner SpinnerObj;
        protected SfGrid<spGetAllFeedbackDto> Grid;
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1000);
            await LoadFeedbacks();
            await SpinnerObj.HideAsync();

        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await SpinnerObj.ShowAsync();
            }
        }
        protected async Task LoadFeedbacks()
        {
            feedbacks = await tutorService.GetAllFeedbacks("0");
        }
        protected async void OnCommandClicked(CommandClickEventArgs<spGetAllFeedbackDto> args)
        {
            RowDetails = args.RowData;            
            IsVisible = true;
            TutorFeedbackDto dto = new TutorFeedbackDto { Id=RowDetails.Id, Comments=RowDetails.Comments, CreatedBy=RowDetails.CreatedBy.ToString(), CreatedDate=RowDetails.CreatedDate, HasRead=true, TutorId=RowDetails.TutorId  };
            var t = await tutorService.UpdateFeedback(RowDetails.Id, dto);
        }
    }
}
