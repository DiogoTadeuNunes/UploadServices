namespace Application.ViewModel
{
    public class UploadViewModel
    {
        public UploadViewModel() { }

        public UploadViewModel(string path, string fileName, string extension)
        {
            this.path = path;
            this.fileName = fileName;
            this.extension = extension;
        }

        public string path { get; set; }
        public string fileName { get; set; }
        public string extension { get; set; }
    }
}
