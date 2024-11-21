using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }   
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<UserToken>  UserTokens { get; set; }

    }
}
