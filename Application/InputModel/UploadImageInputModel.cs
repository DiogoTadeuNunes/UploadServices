using System;

namespace Application.InputModel
{
    public class UploadImageInputModel
    {
        public string base64 { get; set; }
        public Guid? name { get; set; }
    }
}
