using Microsoft.EntityFrameworkCore;
using Proyecto24AM.Models.Entities;

namespace Proyecto24AM.Context
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public virtual DbSet<User> Usuarios { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Book> Libros { get; set; }
    }
    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<User>().HasData(
            new User
            {
                PKUser = 1,
                Name = "Test",
                lastName = "Test",
                UserName = "Test",
                Password = "Test"
            }
            );
    }
}