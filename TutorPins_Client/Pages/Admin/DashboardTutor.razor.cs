using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Layouts;
using Syncfusion.Blazor;
using TutorPins_Client.Service.IService;
using Models;
using Microsoft.AspNetCore.Components.Authorization;
using TutorPins_Client.Authentication;

namespace TutorPins_Client.Pages.Admin
{
    public class DashboardTutorBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IGenericService genericSerice { get; set; }
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        [Inject]
        IDashboardService dashboardService { get; set; }
        [CascadingParameter]
        protected Task<AuthenticationState> authenticationState { get; set; }
        

        protected SfDashboardLayout dashboardObject;
        protected Theme Theme { get; set; }
        protected double[] Spacing = new double[] { 15, 15 };
        protected double Ratio = 160 / 100;
        protected string[] palettes = new string[] { "#61EFCD", "#CDDE1F", "#FEC200", "#CA765A", "#2485FA", "#F57D7D", "#C152D2",
    "#8854D9", "#3D4EB8", "#00BCD7","#4472c4", "#ed7d31", "#ffc000", "#70ad47", "#5b9bd5", "#c1c1c1", "#6f6fe2", "#e269ae", "#9e480e", "#997300" };

        protected spTutorDashboardCountDto dashboadCount { get; set; } = new spTutorDashboardCountDto();
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var authState = await authenticationState;
            dashboadCount = await dashboardService.GetTutorDashboardCounts(authState.User.Identity.Name);
            
        }
    }
}
