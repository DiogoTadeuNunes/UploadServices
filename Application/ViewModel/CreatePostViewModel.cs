using System;
using System.Collections.Generic;

namespace Application.ViewModel
{
    public class CreatePostViewModel
    {
        public CreatePostViewModel() { }

        public CreatePostViewModel(int id, DateTime createdAt, string projectKey, string title, string content, IEnumerable<CreatePostFiles> files)
        {
            this.id = id;
            this.createdAt = createdAt;
            this.projectKey = projectKey;
            this.title = title;
            this.content = content;
            this.files = files;
        }

        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public string projectKey { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public IEnumerable<CreatePostFiles> files { get; set; }

        public class CreatePostFiles
        {
            public CreatePostFiles() { }

            public CreatePostFiles(string name, string session)
            {
                this.name = name;
                this.session = session;
            }

            public string name { get; set; }
            public string session { get; set; }
        }
    }
}
