using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace CodeFirstExistingDatabaseSampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork work = new UnitOfWork();
            
            var blogs = work.BlogRepository.Get(null, b => b.OrderBy(f => f.Name), "Posts");
            foreach(Blog blog in blogs)
            {
                Console.WriteLine(blog.Name);

                foreach (Post post in blog.Posts)
                {
                    Console.WriteLine("\t" + post.Title);
                }
            }

            Console.ReadLine();
        }
        
    }
}
