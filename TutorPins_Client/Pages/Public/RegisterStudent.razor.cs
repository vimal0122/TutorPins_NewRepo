using DataAccess.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Models;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Notifications;
using System.Linq;
using TutorPins_Client.General;
using TutorPins_Client.Service;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Pages.Public
{
    public class RegisterStudentBase : ComponentBase
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
        IStudentService studentService { get; set; }        
        [Inject]
        ICourseService courseService { get; set; }
        [Inject]
        ICourseCategoryService courseCategoryService { get; set; }
        [Inject]
        ICourseSubjectService courseSubjectService { get; set; }
        protected StudentDto StudentModel { get; set; } = new StudentDto();
        public string[] SelectedSubjects { get; set; } = new string[] { };
        public string ModalDisplay = "none;";
        public DateTime? DOSValue { get; set; } = null;
		protected EditContext editContext;
		//public int ApproxBudget { get; set; } = 10;

		public List<StudentSubjectDto> StoreSubjectDetails = new List<StudentSubjectDto>();
        protected List<CourseSubjectDto> courseSubjectList = new List<CourseSubjectDto>();
        public List<StudentLocationDto> StoreLocationDetails = new List<StudentLocationDto>();

        protected List<CourseCategoryDto> CourseCategoryList = new List<CourseCategoryDto>();
        protected List<TutorCategoryDto> TutorCategoryList = new List<TutorCategoryDto>();
        protected List<GeneralText> Genders = new List<GeneralText>();
        protected List<GeneralText> Race = new List<GeneralText>();
        protected List<GeneralText> TutorCategory = new List<GeneralText>();
        protected List<GeneralText> TutorMode = new List<GeneralText>();
        protected List<LocationDto> locationList = new List<LocationDto>();

        public DateTime MinDate { get; set; } = DateTime.Now.AddDays(1);

        protected SfToast ToastObj;
        protected string ToastPosition = "Center";
        protected string ToastContent = "Student Registered Successfully.";

        public string SelectedCourseCategory;
        public string SelectedLocation;
        public string StudentOtherLocations;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
			editContext = new EditContext(StudentModel);
			IEnumerable<CourseCategoryDto> courseCategories = await courseCategoryService.GetCourseCategories();
            CourseCategoryList = courseCategories.ToList();

            this.StateHasChanged();

            IEnumerable<LocationDto> locations = await courseCategoryService.GetAllLocations();
            locationList = locations.ToList();

            Genders = genericSerice.GetGenders();
            Race = genericSerice.GetRaces();
            
            TutorMode = genericSerice.GetTutorModes();
        }
        protected async Task Save()
        {
            SaveLocationData();
            StudentModel.StudentSubjects = StoreSubjectDetails;
            StudentModel.StudentLocations = StoreLocationDetails;
            StudentModel.EarliestStartDate = DOSValue;
            StudentModel.OtherLocation = StudentOtherLocations;
            StudentModel.MatchStatus = string.Format("{0}/{1}", 0, StoreSubjectDetails.Count());
            var response = await studentService.CreateStudent(StudentModel);
            if (response)
            {
                //NavigationManager.NavigateTo("students");
                await this.ToastObj.ShowAsync();
            }
        }
        
        protected void SubjectChangeHandler(MultiSelectChangeEventArgs<string[]> args)
        {
            StoreSubjectDetails.Clear();
            SaveSubjectData();
        }
        public void SaveSubjectData()
        {
            try
            {

                ModalDisplay = "none;";
                StudentSubjectDto studentSubject = new StudentSubjectDto();
                //tutorSubject.Id = ++i;
                //string[] subjects = SubjectId.Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in SelectedSubjects)
                {
                    studentSubject = new StudentSubjectDto();

                    var t = courseSubjectList.Where(t => t.Id == Convert.ToInt32(s)).FirstOrDefault();
                    studentSubject.CategoryName = t.Course.CourseCategory.CategoryName;
                    studentSubject.CourseName = t.Course.CourseName;
                    studentSubject.SubjectName = t.SubjectFullName;
                    studentSubject.SubjectId = Convert.ToInt32(t.Id);
                    studentSubject.SubjectFullName = t.SubjectFullName;
                    studentSubject.CreatedDate = DateTime.Now;
                    studentSubject.TutorMatchStatus = "Requested";
                    //studentSubject.DurationPerWeek = HourlyRate;

                    StoreSubjectDetails.Add(studentSubject);
                    ModalDisplay = "block;";
                }
            }
            catch (Exception ex)
            {

            }


        }
        public void SaveLocationData()
        {
            try
            {
                StudentLocationDto studentLocation = new StudentLocationDto();
                
                    studentLocation = new StudentLocationDto();

                    studentLocation.LocationId = locationList.Where(t => t.Id == Convert.ToInt32(SelectedLocation)).FirstOrDefault().Id;                   

                    StoreLocationDetails.Add(studentLocation);                
            }
            catch (Exception ex)
            {

            }
            
        }

        public async void OnCourseCategoryChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, CourseCategoryDto> args)
        {
            var courseCategoryId = args.ItemData.Id;
            List<GeneralText> tempTutorCategory = new List<GeneralText>();
            IEnumerable<TutorCategoryDto> tutorCategories = await courseCategoryService.GetTutorCategories(args.ItemData.Id.ToString());

            if(tutorCategories.Any())
            {
                GeneralText generalText ;
                //TutorCategory.Clear();
                foreach (var item in tutorCategories)
                {
                    generalText = new GeneralText();
                    generalText.Name = item.TutorCategoryName;
                    generalText.Id = item.Id.ToString();
                    tempTutorCategory.Add(generalText);
                }
            }
            else
            {
                TutorCategory = genericSerice.GetCategories();
            }
            IEnumerable<CourseSubjectDto> courseSubjects = await courseSubjectService.GetSubjectsByCourseCategory(args.ItemData.Id.ToString());
            courseSubjectList = courseSubjects.ToList();
            var noPreference = new GeneralText { Id = "-1", Name = "No Preference" };
            tempTutorCategory.Add(noPreference);
            TutorCategory = tempTutorCategory;
            
            this.StateHasChanged();

        }
    }
}
