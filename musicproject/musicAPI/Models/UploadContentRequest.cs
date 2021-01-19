using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Models
{
    public class UploadContentRequest
    {
        public string Content { get; set; }
        public string FileName { get; set; }
    }
}
