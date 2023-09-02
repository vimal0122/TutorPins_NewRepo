using BusinessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Security.AccessControl;

namespace TutorPins_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageDataController : ControllerBase
    {        
        private IWebHostEnvironment hostingEnv;
        private readonly ITutorRepository _Repository;

        public ImageDataController(IWebHostEnvironment env, ITutorRepository tutorRepository)
        {
            this.hostingEnv = env;
            _Repository = tutorRepository;
        }
        [HttpPost]
        public async Task Post([FromBody] ImageFileDto file)
        {
            
                var buf = Convert.FromBase64String(file.base64data);
                string imagePath = Path.Combine(hostingEnv.ContentRootPath, "UploadedImages");
                await System.IO.File.WriteAllBytesAsync(imagePath + System.IO.Path.DirectorySeparatorChar +  file.fileName, buf);
            
        }
        [HttpGet("{id}")]
        public FileStreamResult Get(string id)
        {
            
            string imagePath = Path.Combine(hostingEnv.ContentRootPath, "UploadedImages", id);
            var stream = new FileStream(imagePath, FileMode.Open);
            return new FileStreamResult(stream, "image/png");

            //var stream = new FileStream(Directory.GetCurrentDirectory() + "\\wwwroot\\UploadedImages\\" + id, FileMode.Open);
            //return new FileStreamResult(stream, "image/png");

        }
        
    }
}
