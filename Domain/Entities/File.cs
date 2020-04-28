using System.Collections.Generic;

namespace Domain.Entities
{
    public class File
    {
        public File() { }

        public File(string name, string session, Post post)
        {
            Name = name;
            Session = session;
            Post = post;
        }

        public int Id { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Session { get; set; }

        public Post Post { get; set; }
    }
}
