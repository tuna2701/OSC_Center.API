﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;


namespace Library.DataModel.DTO
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
