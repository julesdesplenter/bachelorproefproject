﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Models
{
    public class UploadFileRequest
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
