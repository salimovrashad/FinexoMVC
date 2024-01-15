using FinexoMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FinexoMVC.Context
{
    public class FinexoDbContext : IdentityDbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public FinexoDbContext(DbContextOptions opt) : base (opt)
        {
        }
    }
}
