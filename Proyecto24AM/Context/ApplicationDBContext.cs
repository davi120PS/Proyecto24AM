using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Proyecto24AM.Models.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Proyecto24AM.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public virtual DbSet<User> Usuarios { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PKRol = 1,
                    Name = "admin"
                },
                new Rol
                {
                    PKRol = 2,
                    Name = "sa"
                }
            );
            modelbuilder.Entity<User>().HasData(
                new User
                {
                    PKUser = 1,
                    Name = "David",
                    lastName = "Peña",
                    UserName = "davi120",
                    Password = "1234",
                    FKRol = 1
                },
                new User
                {
                    PKUser = 2,
                    Name = "Diego",
                    lastName = "Cortez",
                    UserName = "dieguitocraft",
                    Password = "1234",
                    FKRol = 2
                }
            );
        }
    }
}