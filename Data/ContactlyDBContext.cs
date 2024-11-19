using Contactly.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contactly.Data
{
    public class ContactlyDBContext : DbContext
    {
        public ContactlyDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contacts> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>().HasData(
                new Contacts {Id=1,ContactName="Shruti",Email="shruti@gmail.com",Phone="8617383816",Favorite=true},
                 new Contacts { Id = 2, ContactName = "Sujal", Email = "sujal@gmail.com", Phone = "8617383823", Favorite = true },
                  new Contacts { Id = 3,ContactName = "Rohit", Email = "rohit@gmail.com", Phone = "8617336786", Favorite = true }
                );
        }

    }
    
}
