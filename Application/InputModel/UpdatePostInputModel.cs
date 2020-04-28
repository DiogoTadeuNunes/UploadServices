namespace Application.InputModel
{
    public class UpdatePostInputModel
    {
        public UpdatePostInputModel() { }

        public UpdatePostInputModel(int id, string title, string content)
        {
            this.id = id;
            this.title = title;
            this.content = content;
        }

        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
    }
}
