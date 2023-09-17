using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using TutorPins_Client.Service.IService;
using TutorPins_Client.Service;
using Models;
using TutorPins_Client.General;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Inputs;
using System.Net.Http.Json;
using Syncfusion.Blazor.Notifications;

namespace TutorPins_Client.Pages.Public
{
    public class RegisterTutorBase : ComponentBase
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
        ITutorService tutorService { get; set; }
        [Inject]
        ICourseCategoryService courseCategoryService { get; set; }
        [Inject]
        ICourseService courseService { get; set; }
        [Inject]
        ICourseSubjectService courseSubjectService { get; set; }
        [Inject] 
        ILocationService locationService { get; set; }
        protected string Title { get; set; } = "Create";
        protected TutorDto TutorModel { get; set; } = new TutorDto();
        public string ModalDisplay = "none;";
        public string ModalClass = "";
        public string TutorOtherLocations;
        public bool ShowBackdrop = false;
        public DateTime? DOBValue { get; set; } = null;

        private string CategoryId = string.Empty;
        private string LevelId = string.Empty;
        private string SubjectId = string.Empty;
        public int SelectedHighestQualification;

        private string CategoryName = string.Empty;
        private string LevelName = string.Empty;
        private string SubjectName = string.Empty;
        private string HourlyRate = string.Empty;
        string imagePath = string.Empty;


        string courseCategoryId { get; set; }
        public DateTime MinDate { get; set; } = new DateTime(DateTime.Now.Year - 85, 1, 01);
        public DateTime MaxDate { get; set; } = new DateTime(DateTime.Now.Year - 10, 12, 31);

        public List<TutorSubjectDto> StoreSubjectDetails = new List<TutorSubjectDto>();
        public List<TutorLocationDto> StoreLocationDetails = new List<TutorLocationDto>();
        public List<TutorQualificationDto> StoreQualificationDetails = new List<TutorQualificationDto>();

        protected TutorSubjectDto tutorSubject;
        protected ImageFileDto filesBase64 = new ImageFileDto();

        protected List<CourseCategoryDto> courseCategoryList = new List<CourseCategoryDto>();
        protected List<LocationDto> locationList = new List<LocationDto>();
        protected List<CourseDto> courseList = new List<CourseDto>();
        protected List<CourseSubjectDto> courseSubjectList = new List<CourseSubjectDto>();
        protected List<QualificationDto> defaultQualificationList = new List<QualificationDto>();
        public string[] SelectedLocations { get; set; } = new string[] { };
        public string[] SelectedSubjects { get; set; } = new string[] { };

        int i = 0;
        public List<string> selectedLevels = new List<string>();
        protected List<GeneralText> Genders = new List<GeneralText>();
        protected List<GeneralText> Race = new List<GeneralText>();
        protected List<GeneralText> Category = new List<GeneralText>();
        protected List<GeneralText> TutorMode = new List<GeneralText>();

        protected SfToast ToastObj;
        protected string ToastPosition = "Center";
        protected string ToastContent = "Tutor Registered Successfully.";
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(2000);
            IEnumerable<CourseCategoryDto> courseCategories = await courseCategoryService.GetCourseCategories();
            courseCategoryList = courseCategories.ToList();
            IEnumerable<LocationDto> locations = await courseCategoryService.GetAllLocations();
            locationList = locations.ToList();

            IEnumerable<QualificationDto> defaultQualifications = await courseCategoryService.GetAllQualifications();
            defaultQualificationList = defaultQualifications.ToList();

            IEnumerable<CourseSubjectDto> courseSubjects = await courseSubjectService.GetCourseSubjects();
            courseSubjectList = courseSubjects.ToList();

            Genders = genericSerice.GetGenders();
            Race = genericSerice.GetRaces();
            Category = genericSerice.GetCategories();
            TutorMode = genericSerice.GetTutorModes();
        }
        public void CheckboxClicked(ChangeEventArgs e)
        {
            selectedLevels.Add(e.Value as string);
        }
        public void SaveSubjectData()
        {
            try
            {

                TutorSubjectDto tutorSubject = new TutorSubjectDto();
                ModalDisplay = "none;";

                foreach (string s in SelectedSubjects)
                {
                    tutorSubject = new TutorSubjectDto();

                    var t = courseSubjectList.Where(t => t.Id == Convert.ToInt32(s)).FirstOrDefault();
                    tutorSubject.CategoryName = t.Course.CourseCategory.CategoryName;
                    tutorSubject.CourseName = t.Course.CourseName;
                    tutorSubject.SubjectName = t.SubjectFullName;
                    tutorSubject.SubjectId = Convert.ToInt32(t.Id);
                    tutorSubject.TutorRate = Convert.ToString(tutorSubject.TutorRateValue);
                    tutorSubject.SubjectFullName = t.SubjectFullName;

                    StoreSubjectDetails.Add(tutorSubject);
                    ModalDisplay = "block;";
                }
            }
            catch (Exception ex)
            {

            }

            CategoryId = LevelId = SubjectId = HourlyRate = CategoryName = LevelName = SubjectName = string.Empty;
        }
        public void SaveLocationData()
        {
            try
            {
                TutorLocationDto tutorLocation = new TutorLocationDto();
                //tutorSubject.Id = ++i;
                //string[] subjects = SubjectId.Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in SelectedLocations)
                {
                    tutorLocation = new TutorLocationDto();

                    var t = locationList.Where(t => t.Id == Convert.ToInt32(s)).FirstOrDefault();
                    tutorLocation.LocationId = t.Id.ToString();


                    StoreLocationDetails.Add(tutorLocation);
                }
            }
            catch (Exception ex)
            {

            }

            CategoryId = LevelId = SubjectId = HourlyRate = CategoryName = LevelName = SubjectName = string.Empty;
        }
        public void SaveQualificationData()
        {
            try
            {
                TutorQualificationDto tutorQualification = new TutorQualificationDto();
                //tutorSubject.Id = ++i;
                //string[] subjects = SubjectId.Split(',', StringSplitOptions.RemoveEmptyEntries);


                tutorQualification = new TutorQualificationDto();

                var t = defaultQualificationList.Where(t => t.Id == SelectedHighestQualification).FirstOrDefault();
                tutorQualification.QualificationId = t.Id;


                StoreQualificationDetails.Add(tutorQualification);

            }
            catch (Exception ex)
            {

            }

            CategoryId = LevelId = SubjectId = HourlyRate = CategoryName = LevelName = SubjectName = string.Empty;
        }
        protected async Task Save()
        {
            //SaveSubjectData();
            SaveLocationData();
            SaveQualificationData();
            TutorModel.TutorSubjects = StoreSubjectDetails;
            TutorModel.TutorLocations = StoreLocationDetails;
            TutorModel.TutorQualifications = StoreQualificationDetails;
            TutorModel.OtherLocation = TutorOtherLocations;
            TutorModel.TutorDOB = DOBValue;
            TutorModel.TutorStatus = TutorModel.TutorStatus==null? "Registered" : TutorModel.TutorStatus;
            TutorModel.TutorName = string.Format("{0} {1}", TutorModel.FirstName, TutorModel.LastName);
            var response = await tutorService.CreateTutor(TutorModel);
            if (response)
            {
                //NavigationManager.NavigateTo("tutors");
                await this.ToastObj.ShowAsync();
            }
        }
        
        public void deleteSubject(TutorSubjectDto deleteinfo)
        {
            StoreSubjectDetails.Remove(deleteinfo);
        }
        
        /*
        public void Open()
        {
            ModalDisplay = "block;";
            ModalClass = "Show";
            ShowBackdrop = true;
            StateHasChanged();
        }
        public void Close()
        {
            ModalDisplay = "none";
            ModalClass = "";
            ShowBackdrop = false;
            StateHasChanged();
        }
        protected async void CourseCategoryClicked(ChangeEventArgs courseCategoryEvent)
        {
            courseList.Clear();

            CategoryId = courseCategoryEvent.Value.ToString();
            IEnumerable<CourseDto> courses = await courseService.GetCoursesByCategory(CategoryId);
            CategoryName = courses.FirstOrDefault().CourseCategory.CategoryName;
            courseList = courses.ToList();

            this.StateHasChanged();
        }
        protected async void CourseClicked(ChangeEventArgs courseCategoryEvent)
        {
            courseSubjectList.Clear();

            var obj = courseCategoryEvent.Value;
            string[] arr = Array.ConvertAll((object[])obj, Convert.ToString);
            var LevelId = string.Join(",", arr);
            IEnumerable<CourseSubjectDto> courseSubjects = await courseSubjectService.GetSubjectsByCourse(LevelId);
            LevelName = courseSubjects.FirstOrDefault().Course.CourseName;
            courseSubjectList = courseSubjects.ToList();


            this.StateHasChanged();
        }
        protected async void SubjectClicked(ChangeEventArgs courseCategoryEvent)
        {
            await Task.Delay(1);
            var obj = courseCategoryEvent.Value;
            string[] arr = Array.ConvertAll((object[])obj, Convert.ToString);
            SubjectId = string.Join(",", arr);
            //SubjectId = courseCategoryEvent.Value.ToString();
            //SubjectName = courseSubjectList.Where(t=>t.Id==Convert.ToInt32(SubjectId)).FirstOrDefault().SubjectName;       
            this.StateHasChanged();
        }

        */
        protected async Task OnChange(UploadChangeEventArgs args)
        {
            await Task.Delay(1);
            try
            {

                foreach (var file in args.Files)
                {
                    // string rootpath = AppContext.BaseDirectory.Replace("bin\\Debug\\net6.0\\", "");
                    //  path = Path.GetFullPath("wwwroot\\uploads\\") + file.FileInfo.Name; //System.IO.Path.Combine(rootpath, Guid.NewGuid().ToString() + "_" + file.FileInfo.Name);
                    // FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
                    //  file.File.OpenReadStream(long.MaxValue).CopyTo(filestream);
                    // filestream.Close();
                    // path =  file.FileInfo.Name;
                    MemoryStream memoryStream = new MemoryStream();
                    using var fileStream = file.File.OpenReadStream(long.MaxValue);
                    await fileStream.CopyToAsync(memoryStream);
                    byte[] bytes = memoryStream.ToArray();

                    //var resizedFile = await file.File.RequestImageFileAsync(file.FileInfo.MimeContentType, 640, 480); // resize the image file
                    var formContent = new MultipartFormDataContent
                {
                { new StreamContent(file.File.OpenReadStream(file.File.Size)), "upload", file.File.Name },
                { new StringContent(file.File.ContentType), "content-type" }
                };
                    imagePath = Path.GetRandomFileName() + "_" + file.FileInfo.Name;
                    filesBase64 = new ImageFileDto { base64data = Convert.ToBase64String(bytes), contentType = file.File.ContentType, fileName = imagePath }; // convert to a base64 string!!
                }
                TutorModel.TutorImage = imagePath;
                await Http.PostAsJsonAsync<ImageFileDto>("/api/ImageData", filesBase64, System.Threading.CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void SubjectChangeHandler(MultiSelectChangeEventArgs<string[]> args)
        {
            StoreSubjectDetails.Clear();
            SaveSubjectData();
        }
    }
}
