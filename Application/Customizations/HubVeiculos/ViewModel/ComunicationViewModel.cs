using System;

namespace Application.Customizations.HubVeiculos.ViewModel
{
    public class ComunicationViewModel
    {
        public ComunicationViewModel() { }

        public ComunicationViewModel(string title, string content, DateTime createdAt)
        {
            this.title = title;
            this.content = content;
            this.createdAt = createdAt;
        }

        public string imageURL { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string video { get; set; }
        public string audio { get; set; }
        public DateTime createdAt { get; set; }
    }
}
