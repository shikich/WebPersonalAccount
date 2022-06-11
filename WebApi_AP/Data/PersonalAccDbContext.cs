using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApi_AP.Data
{
    public partial class PersonalAccDbContext : DbContext
    {
        public PersonalAccDbContext()
        {
        }

        public PersonalAccDbContext(DbContextOptions<PersonalAccDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OneGroup> OneGroups { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonalAccount> PersonalAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Db connection string");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OneGroup>().HasKey(
                t => new { t.IdGroup }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
