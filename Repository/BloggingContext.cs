using System.Data.Entity;

namespace Repository
{
    public partial class BloggingContext : DbContext, IBloggingContext
    {
        public BloggingContext() : base("name=BloggingContext")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
