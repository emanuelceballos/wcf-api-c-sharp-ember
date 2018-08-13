using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private BloggingContext context = new BloggingContext();
        private IGenericRepository<Blog> blogRepository;
        private IGenericRepository<Post> postRepository;
        private bool disposed = false;

        public IGenericRepository<Blog> BlogRepository
        {
            get
            {
                if (this.blogRepository == null)
                {
                    this.blogRepository = new GenericRepository<Blog>(context);
                }
                return blogRepository;
            }
        }

        public IGenericRepository<Post> PostRepository
        {
            get
            {
                if (this.postRepository == null)
                {
                    this.postRepository = new GenericRepository<Post>(context);
                }
                return postRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
