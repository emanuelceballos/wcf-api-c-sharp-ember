using System.Data.Entity;

namespace Repository
{
    public interface IBloggingContext
    {
        DbSet<Blog> Blogs { get; set; }
        DbSet<Post> Posts { get; set; }
    }
}
