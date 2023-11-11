using Microsoft.AspNetCore.Components;
using TutorPins_Client.Service.IService;
using Syncfusion.Blazor.Grids;
using TutorPins_Client.General;
using Models;
using Syncfusion.Blazor.Spinner;
using TutorPins_Client.Service;

namespace TutorPins_Client.Pages.Admin.Users
{
    public class UserListBase : ComponentBase
    {
        [Inject]
        protected IUserService userService { get; set; }
        [Inject]
        protected IGenericService genericService { get; set; }
        protected List<GeneralText> Roles { get; set; }
        protected List<GeneralText> UserStatus { get; set; }
        protected IEnumerable<UserDetailDto> Users { get; set; } = new List<UserDetailDto>();
        IEnumerable<TutorDto> Tutors { get; set; } = new List<TutorDto>();
        protected SfGrid<UserDetailDto> userGrid { get; set; }
        protected SfSpinner SpinnerObj;
        protected override async Task OnInitializedAsync()
        {           
           
            Roles=genericService.GetRoles();
            UserStatus = genericService.GetUserStatus();
            await LoadUsers();
            await SpinnerObj.HideAsync();
        }
        private async Task LoadUsers()
        {
            Users = await userService.GetUsers();
        }
        public async void ActionBeginHandler(ActionEventArgs<UserDetailDto> Args)
        {
            if (Args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                if(Args.Action=="Add")
                {
                    var newUser = await userService.CreateUser(Args.Data); //await Task.Delay(1);
                    if(newUser != null)
                    {
                        Users.Append(newUser);
                        //await LoadUsers();
                        //await userGrid.Refresh();
                    }
                }
            }
        }
        public void OnCommandClicked(CommandClickEventArgs<UserDetailDto> Args)
        {
            
        }
    }
}
