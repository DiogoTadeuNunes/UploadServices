using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> ListByProjectKey(string projectKey, DateTime CreatedAt);

        Post GetById(int Id, string projectKey);
    }
}
