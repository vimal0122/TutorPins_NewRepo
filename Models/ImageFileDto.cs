using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ImageFileDto
    {
        public string base64data { get; set; }
        public string contentType { get; set; }
        public string fileName { get; set; }
    }
}
