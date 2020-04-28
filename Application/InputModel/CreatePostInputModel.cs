using System;
using System.Collections.Generic;

namespace Application.InputModel
{
    public class CreatePostInputModel
    {
        public CreatePostInputModel() { }

        public CreatePostInputModel(string projectKey, string title, string content, IEnumerable<CreatePostFiles> files)
        {
            this.projectKey = projectKey;
            this.title = title;
            this.content = content;
            this.files = files;
        }

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
