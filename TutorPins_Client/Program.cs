using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.ComponentModel;
using TutorPins_Client;
using TutorPins_Client.Service;
using TutorPins_Client.Service.IService;
using Syncfusion.Blazor;


Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2V1hhQlJAfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5bdENiWX1Wc31TRGVb; MjY2NDg0NEAzMjMyMmUzMDJlMzBPRGZzc2RNRVB2Tm5MZVBNeGd4QlR1S3lpeGRxeXdNWHNGdVdjVWxjbWVNPQ ==; MjY2NDg0NUAzMjMyMmUzMDJlMzBRRVZ6SFduWG53Y2Z2MzR6L0l0dHQ2UENGTUFsOTBRbjRtTVJrcDBCaEkwPQ ==");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<ICourseCategoryService, CourseCategoryService>();
builder.Services.AddScoped<ICourseSubjectService, CourseSubjectService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITutorService, TutorService>();
builder.Services.AddScoped<ILocationService, LocationService>();

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
