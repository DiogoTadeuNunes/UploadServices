using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(FileServerContext context) : base(context) { }

        public IEnumerable<Post> ListByProjectKey(string projectKey, DateTime CreatedAt)
        {
            return Query(wh => wh.ProjectKey == projectKey &&  wh.CreatedAt >= CreatedAt)
                .Include(x => x.Files)
                .OrderByDescending(x => x.Id)
                .ToArray();
        }

        public Post GetById(int Id, string projectKey)
        {
            return Query(wh => wh.Id == Id && wh.ProjectKey == projectKey)
                .Include(x => x.Files)
                .FirstOrDefault();
        }
    }
}
