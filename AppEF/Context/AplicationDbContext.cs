using Microsoft.EntityFrameworkCore;
using EFProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Context
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext() => Database.EnsureCreated(); // Проверка и создание бд, если она отсутствует

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Объект -> свойство -> метод который настраивает св-во
            modelBuilder.Entity<User>().Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.Name)
                .HasMaxLength(100)
                .HasColumnName("FirstName");
        }
    }
}
