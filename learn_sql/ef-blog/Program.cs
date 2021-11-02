using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace ef_blog
{

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine)
                .UseSnakeCaseNamingConvention()
                .UseNpgsql("Host=127.0.0.1;Username=blog_app;Password=secret;Database=blog");
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    class Program
    {
        public static void Main()
        {
            
        }
    }
}
