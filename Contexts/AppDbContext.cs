using Azure.Core.Pipeline;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Configurations;
using WebApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Contexts
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // For Pictures 
            modelBuilder.Entity<Residence_Pictures>()
        .HasOne(p => p.Residence)
        .WithMany(r => r.Pictures)
        .HasForeignKey(p => p.ResidenceId);
            // For Pictures Composite Key
            modelBuilder.Entity<Residence_Pictures>()
            .HasKey(p => new { p.ResidenceId, p.Url });

            // Composite key for Book
            modelBuilder.Entity<Booking>()
                .HasKey(b => new { b.UserId, b.ResidenceId, b.Contract_Id });

            // Relationships
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(o => o.Booking)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Residence>()
           .HasOne(r => r.User)       // Residence has one User
           .WithMany(o => o.Residences) // Owner has many Residences
           .HasForeignKey(r => r.UserId); // Foreign key is OwnerId

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(t => t.Booking)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Residence)
                .WithMany(r => r.Booking)
                .HasForeignKey(b => b.ResidenceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Contract)
                .WithMany(c => c.Booking)
                .HasForeignKey(b => b.Contract_Id)
                .OnDelete(DeleteBehavior.NoAction);

           //Classes Configurations
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new ResidenceConfigurations());
            modelBuilder.ApplyConfiguration(new ContractConfigurations());


        }
     
        public DbSet<Booking> Books { get; set; }        // For the Book relation
        public DbSet<User> Users { get; set; }      // For Users
        public DbSet<Residence> Residences { get; set; }  // For Residences
        public DbSet<Contract> Contracts { get; set; }    // For Contracts
        public DbSet<Residence_Pictures> Pictures { get; set; }
    }
}
