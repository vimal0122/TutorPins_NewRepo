using Microsoft.AspNetCore.Components;
using Models;
using System;

namespace TutorPins_Client.Pages.GenericComponents
{
    public class TutorDetailsBase : ComponentBase
    {
        [Parameter]
        public TutorDto TutorObject { get; set; }
        [Inject]
        protected Microsoft.AspNetCore.Components.NavigationManager UriHelper { get; set; }
        [Inject]
        protected IConfiguration Configuration { get; set; }
    }
}
