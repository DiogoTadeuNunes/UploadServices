using System;
using System.Collections.Generic;

namespace Application.ViewModel
{
    public class ListPostsViewModel
    {
        public ListPostsViewModel() { }

        public ListPostsViewModel(int id, DateTime createdAt, string projectKey, string title, string content, IEnumerable<ListPostFiles> files)
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
        public IEnumerable<ListPostFiles> files { get; set; }

        public class ListPostFiles
        {
            public ListPostFiles() { }

            public ListPostFiles(string name, string session)
            {
                this.name = name;
                this.session = session;
            }

            public string name { get; set; }
            public string session { get; set; }
        }
    }
}
