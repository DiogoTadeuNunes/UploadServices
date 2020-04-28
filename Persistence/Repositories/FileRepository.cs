using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Repositories
{
    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(FileServerContext context) : base(context) { }

        public IEnumerable<File> GetByPostId(int PostId)
        {
            return Query(wh => wh.PostId == PostId)
                .Include(x => x.Post)
                .ToArray();
        }
    }
}
