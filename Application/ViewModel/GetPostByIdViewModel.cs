using System;
using System.Collections.Generic;

namespace Application.ViewModel
{
    public class GetPostByIdViewModel
    {
        public GetPostByIdViewModel() { }

        public GetPostByIdViewModel(int id, DateTime createdAt, string projectKey, string title, string content)
        {
            this.id = id;
            this.createdAt = createdAt;
            this.projectKey = projectKey;
            this.title = title;
            this.content = content;
        }

        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public string projectKey { get; set; }
        public string title { get; set; }
        public string content { get; set; }
    }
}
