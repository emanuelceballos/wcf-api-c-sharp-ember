using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<Blog> BlogRepository { get; }
        IGenericRepository<Post> PostRepository { get; }
        void Save();
    }
}
