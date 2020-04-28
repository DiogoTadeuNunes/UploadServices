using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Post
    {
        public Post() { }

        public Post(string projectKey, string title, string content)
        {
            ProjectKey = projectKey;
            Title = title;
            Content = content;
            Files = new HashSet<File>();
        }

        public Post(int id, DateTime createdAt, string projectKey, string title, string content)
        {
            Id = id;
            CreatedAt = createdAt;
            ProjectKey = projectKey;
            Title = title;
            Content = content;
            Files = new HashSet<File>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ProjectKey { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual IEnumerable<File> Files { get; set; }
    }
}
