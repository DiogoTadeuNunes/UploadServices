using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IFileRepository : IRepository<File>
    {
        IEnumerable<File> GetByPostId(int PostId);
    }
}
