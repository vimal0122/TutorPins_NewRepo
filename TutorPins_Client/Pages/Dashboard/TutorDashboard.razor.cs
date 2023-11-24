﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Models;
using Syncfusion.Blazor.Layouts;
using Syncfusion.Blazor;
using TutorPins_Client.Service.IService;
using Syncfusion.Blazor.Grids;
using TutorPins_Client.Authentication;
using TutorPins_Client.Service;
using Syncfusion.Blazor.Popups;
using TutorPins_Client.General;
using DataAccess.Data;

namespace TutorPins_Client.Pages.Dashboard
{
    public class TutorDashboardBase : ComponentBase
    {

        [Inject]
        HttpClient Http { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IGenericService genericService { get; set; }
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        [Inject]
        IDashboardService dashboardService { get; set; }
        [CascadingParameter]
        protected Task<AuthenticationState> authenticationState { get; set; }

		[Inject] AuthenticationStateProvider authStateProvider { get; set; }
        [Inject] ITutorService tutorService { get; set; }
		protected SfDialog StatusDialog;
		public bool statusInfoDialogflag = true;

		protected SfDashboardLayout dashboardObject;
        protected Theme Theme { get; set; }
        protected double[] Spacing = new double[] { 15, 15 };
        protected double Ratio = 160 / 100;
        protected string[] palettes = new string[] { "#61EFCD", "#CDDE1F", "#FEC200", "#CA765A", "#2485FA", "#F57D7D", "#C152D2",
    "#8854D9", "#3D4EB8", "#00BCD7","#4472c4", "#ed7d31", "#ffc000", "#70ad47", "#5b9bd5", "#c1c1c1", "#6f6fe2", "#e269ae", "#9e480e", "#997300" };

        protected spTutorDashboardCountDto dashboadCount { get; set; } = new spTutorDashboardCountDto();
		protected SfGrid<spGetTuitionByTutorAndStatusDto> Grid;
		public List<spGetTuitionByTutorAndStatusDto> SubjectDetails = new List<spGetTuitionByTutorAndStatusDto>();
		protected List<GeneralText> MatchStatusList = new List<GeneralText>();
		protected string SelectedMatchStatusId;
		protected string MatchRemarks;
		protected int SelectedSubjectId;
		protected override async Task OnInitializedAsync()
        {
           // await base.OnInitializedAsync();
            var authState = await authenticationState;
            dashboadCount = await dashboardService.GetTutorDashboardCounts(authState.User.Identity.Name);
			MatchStatusList = genericService.GetMatchStatusValues();

		}
		protected async Task GetTuitions(string statusValue)
		{
			var customAuthStateProvider = (CustomAuthenticationStateProvider)authStateProvider;
			var token = await customAuthStateProvider.GetToken();
			FilterTutionRequest request = new FilterTutionRequest { TutorId = 17, StatusId = 5 };
			switch (statusValue)
			{
				case "M":
					request.StatusId = 5;
					var x = await tutorService.GetTuitionByTutorAndStatus(request);
					SubjectDetails = x.ToList();
					break;
			}

		}
		public void StatusClosed()
		{
			statusInfoDialogflag = true;

		}
		protected async Task UpdateStatus(spGetTuitionByTutorAndStatusDto pos)
		{
			if (statusInfoDialogflag)
			{				
				string[] lstStrings = new string[] { Convert.ToString((int)MatchStatusValues.Accepted), Convert.ToString((int)MatchStatusValues.Rejected) };
				MatchStatusList = MatchStatusList.Where(x => lstStrings.Contains(x.Id)).ToList();
				await StatusDialog.ShowAsync();
				statusInfoDialogflag = false;
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
	}
}
