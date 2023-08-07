using LibraryApp.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Test.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //entities
        public DbSet<User> User { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BorrowBooks> BorrowBooks { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Book>();
            modelBuilder.Entity<BorrowBooks>();
        }

    }
}

